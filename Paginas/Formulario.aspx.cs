using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using TpCrudFinal.Datos;
using TpCrudFinal.EF;

namespace TpCrudFinal
{
    public partial class Index : System.Web.UI.Page
    {
        private static int idEmpleado = 0;
        EmpleadoAdmin empleadoAdmin = new EmpleadoAdmin(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idEmpleado"] != null)
                {
                    idEmpleado = Convert.ToInt32(Request.QueryString["idEmpleado"].ToString());

                    if (idEmpleado != 0)
                    {
                        lblTitulo.Text = "Editar Empleado";
                        btnSubmit.Text = "Modificar";
                        Empleado empleadoBase = empleadoAdmin.GetEmpleadoById(idEmpleado);
                        txtNombre.Text = empleadoBase.Nombre;
                        txtApellido.Text = empleadoBase.Apellido;
                        txtEmail.Text = empleadoBase.Email;
                        txtFechaNac.Text = empleadoBase.FechaNacimiento.ToString("yyyy-MM-dd", new CultureInfo("es-AR"));
                        txtPuesto.Text = empleadoBase.Puesto;
                        txtSueldo.Text = empleadoBase.Sueldo.ToString("0");
                        txtFechaContrato.Text = empleadoBase.FechaContrato.ToString("yyyy-MM-dd", new CultureInfo("es-AR"));
                        RblEstado.SelectedValue = empleadoBase.Activo ? "1" : "0";
                        LoadDepartamentos();
                        ddlDepartamento.SelectedValue = empleadoBase.Departamento.IdDepartamento.ToString();
                        
                        Page.DataBind();
                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo Empleado";
                        btnSubmit.Text = "Guardar";
                        LoadDepartamentos();
                   }
                }
                else
                {
                    Response.Redirect("~/Paginas/Listado.aspx");
                }
            }
        }

        private void LoadDepartamentos(string idDepartamento = "")
        {

            using (DBCrudPrograEntities db = new DBCrudPrograEntities())
            {
                List<Departamento> listaDepartamentos = db.Departamento.AsNoTracking().ToList();


                ddlDepartamento.DataTextField = "Nombre";
                ddlDepartamento.DataValueField = "idDepartamento";

                ddlDepartamento.DataSource = listaDepartamentos;
                ddlDepartamento.DataBind();

                if (idDepartamento != "")
                {
                    ddlDepartamento.SelectedValue = idDepartamento;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado()
            {
                IdEmpleado = idEmpleado,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text),
                IdDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue),
                Puesto = txtPuesto.Text,
                Sueldo = Convert.ToDecimal(txtSueldo.Text, new CultureInfo("es-AR")),
                FechaContrato = Convert.ToDateTime(txtFechaContrato.Text),
                Activo = RblEstado.SelectedItem.Value == "1" ? true : false
            };

            bool respuesta;

            if(idEmpleado == 0)
                respuesta = empleadoAdmin.SaveEmpleado(empleado);
            else
                respuesta = empleadoAdmin.EditEmpleado(empleado);

            if(respuesta)
                Response.Redirect("~/Paginas/Listado.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(),"script","alert('No se pudo realizar la operación')", true);
        }

    }
}