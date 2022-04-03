using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab2
{
    public partial class InsertarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/inicio.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Server=tcp:hads22-09.database.windows.net,1433;Initial Catalog=hads22-09;Persist Security Info=False;User ID=mcontreras009@ikasle.ehu.eus@hads22-09;Password=Hadsbrymau09;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            String consulta = "select * from TareaGenerica";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "tareasgenericas");
            DataTable dataTable = new DataTable();

            dataTable = dataSet.Tables["tareasgenericas"];

            DataRow dr = dataTable.NewRow();
            dr["codigo"] = TextBox1.Text;
            dr["descripcion"] = TextBox2.Text;
            dr["codAsig"] = DropDownList1.SelectedValue;
            dr["hEstimadas"] = TextBox3.Text; 
            dr["explotacion"] = 0;
            dr["tipoTarea"] = DropDownList2.SelectedValue;

            dataTable.Rows.Add(dr);
            dataAdapter.Update(dataSet, "tareasgenericas");

            dataTable.AcceptChanges();
            dataSet.AcceptChanges();
            Label8.Text = "Tarea insertada correctamente!";
            Label8.Visible = true;

        }
    }
}