    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab2
{
    public partial class Alumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/inicio.aspx");
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {


        }

       

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VerTareasEstudiante.aspx"); 
        }

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/inicio.aspx");
        }
    }
}