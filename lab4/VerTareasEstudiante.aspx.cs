using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace lab2
{
    public partial class VerTareasEstudiante : System.Web.UI.Page
    {
        //Se crea la conexión con la DB que vamos a operar
        SqlConnection conexion = new SqlConnection("Server=tcp:hads22-09.database.windows.net,1433;Initial Catalog=hads22-09;Persist Security Info=False;User ID=mcontreras009@ikasle.ehu.eus@hads22-09;Password=Hadsbrymau09;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
      
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();
        DataSet dataSetTareas = new DataSet();
        DataTable dataTableTareas = new DataTable();
        DataTable dataTableFiltradaTareas = new DataTable();
        DataView dataviewTareas;

        //DataRow dataRow = new DataRow();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/inicio.aspx");
            }


            if (Page.IsPostBack)
            {
                //En caso de que no sea la primera vez que hayamos cargado la página, recuperamos el dataset de la variable session
                dataSet = (DataSet)Session["dataset"];
                dataSetTareas = (DataSet)Session["datasetTareas"];
            }
            else
            {
              
                String consulta = "select * from GrupoClase INNER JOIN EstudianteGrupo ON GrupoClase.codigo=EstudianteGrupo.grupo";

                //Creamos un data adapter a partir de la conexión y la consulta sql que hemos definido
                SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, conexion);

                //El builder permite automatizar los comandos necesarios para con conciliar los cambios realizados en un dataset con la DB de sql con la que nos hemos conectado, como update, delete 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                //Traemos el contenidos de la consulta sql al data y los guardamos en una tabla
                dataAdapter.Fill(dataSet, "AsignaturasLogueado");

                //Guardamos en el datable la información que hemos cargado en memoria en la tabla Asignatura de nuestro dataset
                dataTable = dataSet.Tables["AsignaturasLogueado"];
                
                
                DataTable dataTableFiltrada = new DataTable();
                String filtro = "email='" + Session["email"].ToString() + "'";
                DataView dataview = new DataView(dataTable);
                dataview.RowFilter = filtro;
                dataTableFiltrada = dataview.ToTable();

                //Guardamos en la sesión los datos que se van a reutilizar
                Session["dataset"] = dataSet;
                Session["adapter"] = dataAdapter;
                Session["tabla"] = dataTableFiltrada;

             

                //no sabemos porque, pero es necesario poner el DataTextField
                DropDownList1.DataTextField = "codigoAsig";
                DropDownList1.DataSource = dataTableFiltrada;
                DropDownList1.DataBind();


                //---------------------------------------------------------------------------------


                String consultaTareas = "select * from TareaGenerica TG INNER JOIN GrupoClase GC ON TG.codAsig = GC.codigoAsig INNER JOIN EstudianteGrupo EG ON GC.codigo = EG.grupo WHERE TG.explotacion=1 AND EG.email = '" + Session["email"].ToString() + "' AND TG.codigo NOT IN (SELECT CodTarea FROM EstudianteTarea WHERE email='" + Session["email"] + "')";
                SqlDataAdapter dataAdapterTareas = new SqlDataAdapter(consultaTareas, conexion);
                SqlCommandBuilder commandBuilderTareas = new SqlCommandBuilder(dataAdapterTareas);
                dataAdapterTareas.Fill(dataSetTareas, "Tareas");
                dataTableTareas = dataSetTareas.Tables["Tareas"];

               String filtroTareas = "codAsig = '" + DropDownList1.SelectedValue + "'";
                dataviewTareas = new DataView(dataTableTareas);
               dataviewTareas.RowFilter = filtroTareas;
                
                dataTableFiltradaTareas = dataviewTareas.ToTable(false, "codigo", "descripcion", "hEstimadas", "tipoTarea");

                GridView1.DataSource = dataTableFiltradaTareas;
                GridView1.DataBind();

                if (dataTableFiltradaTareas.Rows.Count==0)
                {
                    Label3.Visible = true;
                    Label3.Text = "NO HAY TAREAS SEÑOR";
                }
                else
                {
                    Label3.Visible = false;

                }

                Session["datasetTareas"] = dataSetTareas;

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTableTareas = dataSetTareas.Tables["tareas"];

            String filtroTareas = "codAsig = '" + DropDownList1.SelectedValue + "'";
            DataView dataviewTareas = new DataView(dataTableTareas);
            dataviewTareas.RowFilter = filtroTareas;
            DataTable dataTableFiltradaTareas = new DataTable();
            dataTableFiltradaTareas = dataviewTareas.ToTable(false, "codigo", "descripcion", "hEstimadas", "tipoTarea");

            GridView1.DataSource = dataTableFiltradaTareas;
            GridView1.DataBind();


            if (dataTableFiltradaTareas.Rows.Count == 0)
            {
                Label3.Visible = true;
                Label3.Text = "NO HAY TAREAS SEÑOR";
            }
            else
            {
                Label3.Visible = false;

            }

        }



        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/inicio.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTableTareas = dataSetTareas.Tables["tareas"];

            //Response.Redirect("~/InstanciarTarea.aspx?codigo='" + dataTableTareas.Rows(GridView1.SelectedIndex).Item(1));

            TableCellCollection row = GridView1.SelectedRow.Cells;
            String codigo = GridView1.SelectedRow.Cells[1].Text;
            String horase = GridView1.SelectedRow.Cells[3].Text;
            Response.Redirect("~/InstanciarTarea.aspx?codigo='"+codigo+ "'&dr=row&horase='"+horase+"'");
        }
    }
}