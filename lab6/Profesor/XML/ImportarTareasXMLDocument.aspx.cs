using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
namespace lab2
{
    public partial class ImportarTareasXMLDocument : System.Web.UI.Page
    {


        DataSet dataSetAsig = new DataSet();
        DataTable dataTableAsig = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
               

                if (Page.IsPostBack)
                {

                    //En caso de que no sea la primera vez que hayamos cargado la página, recuperamos el dataset de la variable session
                    dataSetAsig = (DataSet)Session["datasetAsig"];
                }
                else
                {
                    SqlConnection conexion = new SqlConnection("Server=tcp:hads22-09.database.windows.net,1433;Initial Catalog=hads22-09;Persist Security Info=False;User ID=mcontreras009@ikasle.ehu.eus@hads22-09;Password=Hadsbrymau09;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");

                    String consultaAsig = "SELECT * FROM GrupoClase INNER JOIN ProfesorGrupo ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo";
                    SqlDataAdapter dataAdapterAsig = new SqlDataAdapter(consultaAsig, conexion);
                    SqlCommandBuilder commandBuilderAsig = new SqlCommandBuilder(dataAdapterAsig);
                    dataAdapterAsig.Fill(dataSetAsig, "Tareas");
                    dataTableAsig = dataSetAsig.Tables["Tareas"];

                    String filtroAsig = "email='" + Session["email"] + "'";
                    DataView dataviewAsig = new DataView(dataTableAsig);
                    dataviewAsig.RowFilter = filtroAsig;
                    DataTable dataTableFiltradaAsig = new DataTable();

                    dataTableFiltradaAsig = dataviewAsig.ToTable();

                    //Guardamos en la sesión los datos que se van a reutilizar
                    Session["datasetAsig"] = dataSetAsig;


                    DropDownList1.DataTextField = "codigoAsig";
                    DropDownList1.DataSource = dataTableFiltradaAsig;
                    DropDownList1.DataBind();


                    if (File.Exists(Server.MapPath("~/App_Data/" + DropDownList1.SelectedValue + ".xml")))
                    {
                        Label4.Visible = false;
                        Xml1.DocumentSource = Server.MapPath("~/App_Data/" + DropDownList1.SelectedValue + ".xml");
                        Xml1.TransformSource = Server.MapPath("~/App_Data/VerTablaTareas.xsl");
                    } else
                    {
                        Label4.Visible = true;
                        Label4.Text = "Error! No existe el fichero: " + DropDownList1.SelectedValue + ".xml" ;
                    }


                }
            }
            catch(Exception)
            {

                Label4.Visible = true;
                Label4.Text = "Error! No existen ficheros a importar";

            }

        }

       

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

            try
            {
                if (File.Exists(Server.MapPath("~/App_Data/" + DropDownList1.SelectedValue + ".xml")))
                {
                    Label4.Visible = false;
                    Xml1.DocumentSource = Server.MapPath("~/App_Data/" + DropDownList1.SelectedValue + ".xml");
                    Xml1.TransformSource = Server.MapPath("~/App_Data/VerTablaTareas.xsl");
                }
                else
                {
                    Label4.Visible = true;
                    Label4.Text = "Error! No existe el fichero: " + DropDownList1.SelectedValue + ".xml";
                }
            }
            catch (Exception)
            {
                Label4.Visible = true;
                Label4.Text = "Error! No existen ficheros a importar";
            }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XmlDocument docxml = new XmlDocument();
            docxml.Load(Server.MapPath("~/App_Data/" + DropDownList1.SelectedValue + ".xml"));

            SqlConnection conexion = new SqlConnection("Server=tcp:hads22-09.database.windows.net,1433;Initial Catalog=hads22-09;Persist Security Info=False;User ID=mcontreras009@ikasle.ehu.eus@hads22-09;Password=Hadsbrymau09;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            String consulta = "select * from TareaGenerica";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataSet, "Tareas");
            dataTable = dataSet.Tables["Tareas"];


            try
            {
                XmlNodeList nodolista;
                nodolista = docxml.GetElementsByTagName("tarea");
                for (int i = 0; i < nodolista.Count; i++)
                {
                    DataRow dr = dataTable.NewRow();
                    dr["codigo"] = nodolista[i].Attributes[0].ChildNodes[0].Value;
                    dr["descripcion"] = nodolista[i].ChildNodes[0].ChildNodes[0].Value;
                    dr["codAsig"] = DropDownList1.SelectedValue;
                    dr["hEstimadas"] = nodolista[i].ChildNodes[1].ChildNodes[0].Value;
                    dr["explotacion"] = nodolista[i].ChildNodes[3].ChildNodes[0].Value;
                    dr["tipoTarea"] = nodolista[i].ChildNodes[2].ChildNodes[0].Value;
                    dataTable.Rows.Add(dr);

                }
                dataAdapter.Update(dataSet, "Tareas");

                dataTable.AcceptChanges();
                dataSet.AcceptChanges();
                Label4.Visible = true;
                Label4.Text = "tareas importadas correctamente";
            }
            catch(SqlException)
            {
                Label4.Visible = true;
                Label4.Text = "tareas ya importadas";

            }
            








        }

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/inicio.aspx");
        }
    }
}