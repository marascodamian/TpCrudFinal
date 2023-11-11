using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpCrudFinal.Datos;
using TpCrudFinal.Dto;

namespace TpCrudFinal.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Alias = txtUsuario.Text;
            string Pass = txtContrasena.Text;
            
            UsuarioDto usuario =  CLogin.IniciarSesion(Alias, Pass);

            if(usuario.Alias == null )
            {
                Response.Write("<script> alert(" + "'El Usuario o Contraseña no son válidos'" + ") </script>");
            }
            else
            {
                Session["Usuario"] = usuario.Alias;
                Response.Redirect("~/Paginas/Listado.aspx");
            }
        }
    }
}