using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpCrudFinal
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerificarSesion();
                lblUsuario.Text = "Bienvenido "+ Session["Usuario"].ToString();
            }
        }

        private void VerificarSesion()
        {
            if(Session["Usuario"] == null)
            {
                Response.Redirect("~/Paginas/Login");
            }
        }

        protected void btnMiBoton_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Session.Abandon();

            Response.Redirect("~/Paginas/Login.aspx");
        }
    }
}