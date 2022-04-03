using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace lab2
{
    public partial class ExportarTareas : System.Web.UI.Page
    {


        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();
        DataTable dataTableFiltrada = new DataTable();
        DataView dataview;
        DataSet dataSetAsig = new DataSet();
        DataTable dataTableAsig = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["email"] == null)
            {
                Response.Redirect("~/inicio.aspx");
            }

            if (Page.IsPostBack)
            {
                //En caso de que no sea la primera vez que hayamos cargado la página, recuperamos el dataset de la variable session
                dataSetAsig = (DataSet)Session["datasetAsig"];
                dataSet = (DataSet)Session["dataSet"];
            }
            else
            {


                // ------------------------------DROPDOWNLIST1 - ASIGNATURAS PROFESOR LOGUEADO------------------------------

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

                // ---------------------------------------------------------------------------------------------------------------



                String consulta = "select * from TareaGenerica";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, conexion);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataSet, "Tareas");
                dataTable = dataSet.Tables["Tareas"];

                String filtro = "codAsig='" + DropDownList1.SelectedValue + "'";
                dataview = new DataView(dataTable);
                dataview.RowFilter = filtro;
                dataTableFiltrada = dataview.ToTable(false, "codigo", "descripcion", "hEstimadas", "Explotacion", "tipoTarea");

                Session["dataset"] = dataSet;
                DataSet datasetFiltrado = new DataSet();
                datasetFiltrado.Tables.Add(dataTableFiltrada);
                Session["datasetFiltrado"] = datasetFiltrado;


                GridView1.DataSource = dataTableFiltrada;
                GridView1.DataBind();



            }








        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable = dataSet.Tables["Tareas"];
            String filtroTareas = "codAsig = '" + DropDownList1.SelectedValue + "'";
            DataView dataview = new DataView(dataTable);
            dataview.RowFilter = filtroTareas;
            DataTable dataTableFiltrada = new DataTable();
            dataTableFiltrada = dataview.ToTable(false, "codigo", "descripcion", "hEstimadas", "Explotacion", "tipoTarea");

            GridView1.DataSource = dataTableFiltrada;
            GridView1.DataBind();

            DataSet datasetFiltrado = new DataSet();
            datasetFiltrado.Tables.Add(dataTableFiltrada);
            Session["datasetFiltrado"] = datasetFiltrado;

        }

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/inicio.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            try
            {
                DataSet dataset = (DataSet)Session["datasetFiltrado"];
                dataset.DataSetName = "tareas";
                dataset.Tables[0].TableName = "tarea";
                dataset.Tables[0].Columns[0].ColumnMapping = MappingType.Attribute;
                dataset.Tables[0].Columns[2].ColumnName = "hestimadas";
                dataset.Tables[0].Columns[4].ColumnName = "tipotarea";
                dataset.Tables[0].Columns[3].SetOrdinal(dataset.Tables[0].Columns.Count - 1);

                dataset.Tables[0].WriteXml(Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml"));


                Label4.Visible = true;
                Label4.Text = "XML creado con exito: " + DropDownList1.SelectedValue + ".xml";
            }
            catch (Exception ex)
            {
                Label4.Visible = true;
                Label4.Text = ex.ToString();
            }
        }

    }

}

