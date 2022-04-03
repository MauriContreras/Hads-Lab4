using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace lab2
{
    public partial class InstanciarTarea : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection("Server=tcp:hads22-09.database.windows.net,1433;Initial Catalog=hads22-09;Persist Security Info=False;User ID=mcontreras009@ikasle.ehu.eus@hads22-09;Password=Hadsbrymau09;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            textBoxUsuario.Text = (String)Session["email"];
            textBoxTarea.Text = Request.QueryString["codigo"].Trim('\'');
            textBoxHorasE.Text = Request.QueryString["horase"].Trim('\'');

            if (Page.IsPostBack)
            {
                //En caso de que no sea la primera vez que hayamos cargado la página, recuperamos el dataset de la variable session
                dataSet = (DataSet)Session["datasetinstanciar"];
                dataAdapter = (SqlDataAdapter)Session["datadapterinstanciar"];
            }
            else
            {
                String consulta = "select * from EstudianteTarea where email = '"+Session["email"]+"' ";

                //Creamos un data adapter a partir de la conexión y la consulta sql que hemos definido
                SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, conexion);
                Session["datadapterinstanciar"] = dataAdapter;

                //El builder permite automatizar los comandos necesarios para con conciliar los cambios realizados en un dataset con la DB de sql con la que nos hemos conectado, como update, delete 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                //Traemos el contenidos de la consulta sql al data y los guardamos en una tabla
                dataAdapter.Fill(dataSet, "EstudianteT");
                Session["datasetinstanciar"] = dataSet;

                //Guardamos en el datable la información que hemos cargado en memoria en la tabla Asignatura de nuestro dataset
                dataTable = dataSet.Tables["EstudianteT"];
                Session["datatablesession"]=dataTable;

                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void textBoxHorasE_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String email = (String)Session["email"];
            String codigo = Request.QueryString["codigo"].Trim('\'');
            String horas = Request.QueryString["horase"].Trim('\'');
            String horasr = textBoxHorasR.Text;

            //creas un datarow pero es necesario especificar un datatable de un dataset
            DataTable dt = (DataTable)Session["datatablesession"];

            String filtro = "codTarea = '"+codigo+"' ";
            DataView dataviewcomprobar = new DataView(dt);
            dataviewcomprobar.RowFilter = filtro;
            int numerof = dataviewcomprobar.Count;
            if (numerof == 0)
            {
                      
                
                    DataRow dr = dt.NewRow();
                    dr["email"] = email;
                    dr["codTarea"] = codigo;
                    dr["hEstimadas"] = horas;
                    dr["hReales"] = horasr;
                    dt.Rows.Add(dr);
                    dataSet = (DataSet)Session["datasetinstanciar"];
                    SqlDataAdapter dataAdapter = (SqlDataAdapter)Session["datadapterinstanciar"];
                    dataAdapter.Update(dataSet, "EstudianteT");
                    
                    dt.AcceptChanges();
                    dataSet.AcceptChanges();
                    labelconfirmacion.Text = "La tarea se ha instanciado correctamente";
                    labelconfirmacion.Visible = true;

                    //Actualizar tabla
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                
            } else
            {
                labelconfirmacion.Text = "La tarea ya ha sido instanciada con anterioridad";
                labelconfirmacion.Visible = true;
            }
        }

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/inicio.aspx");
        }
    }
}