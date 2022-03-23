using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace lab2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection("Server=tcp:hads22-09.database.windows.net,1433;Initial Catalog=hads22-09;Persist Security Info=False;User ID=mcontreras009@ikasle.ehu.eus@hads22-09;Password=Hadsbrymau09;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        SqlDataAdapter dataAdapter = new SqlDataAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack==false)
            {
                BotonImportar.Enabled = false;
            } else
            {
                BotonImportar.Enabled = true;
            }
        }

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/inicio.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Server.MapPath --> https://www.dotnetperls.com/mappath
            if (DropDownList1.Text == " " )
            {
                BotonImportar.Enabled = false;
            } else
            {
                BotonImportar.Enabled = true;
                //Para especificar el origen de datos de la información
                //En este caso dado que el archivo xml varia, concatenamos el valor seleccionado con la extension.xml
                Xml1.DocumentSource = Server.MapPath("~/App_Data/" +DropDownList1.Text+".xml");
                //Para especificar el documento por el cual se tiene que validar(xsl) el xml que traemos
                Xml1.TransformSource = Server.MapPath("~/App_Data/VerTablaTareas.xsl");
            }
        }

        protected void BotonImportar_Click(object sender, EventArgs e)
        {

        }
    }
}