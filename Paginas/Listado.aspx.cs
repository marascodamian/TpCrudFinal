using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpCrudFinal.Datos;
using TpCrudFinal.EF;

namespace TpCrudFinal
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowEmpleados();
                LoadDepartamentos();
            }
                
        }

        private void ShowEmpleados(int? filtroDepto = null, int? filtroEstado = null)
        {
            using (DBCrudPrograEntities db = new DBCrudPrograEntities())
            {
                List<Empleado> empleados;

                bool estadoActivo = Convert.ToBoolean(filtroEstado);

                if (filtroDepto.HasValue)
                {
                    if (filtroEstado.HasValue)
                    {
                        empleados = db.Empleado
                            .Where(e => e.Departamento.IdDepartamento == filtroDepto.Value && e.Activo == estadoActivo)
                            .AsNoTracking()
                            .ToList();
                    }
                    else
                    {
                        empleados = db.Empleado
                            .Where(e => e.Departamento.IdDepartamento == filtroDepto.Value)
                            .AsNoTracking()
                            .ToList();
                    }
                }
                else
                {
                    if (filtroEstado.HasValue)
                    {
                        empleados = db.Empleado
                            .Where(e => e.Activo == estadoActivo)
                            .AsNoTracking()
                            .ToList();
                    }
                    else
                    {
                        empleados = db.Empleado.AsNoTracking().ToList();
                    }
                }

                GvEmpleados.DataSource = empleados;
                GvEmpleados.DataBind();
            }
        }
        protected Empleado GetEmpleadoById(int id)
        {
            using (DBCrudPrograEntities db = new DBCrudPrograEntities())
            {
                Empleado empleado = db.Empleado.Find(id);

                return empleado;
            }
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Formulario.aspx?idEmpleado=0");
        }
        protected void Editar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idEmpleado = btn.CommandArgument.ToString();

            Response.Redirect($"~/Paginas/Formulario.aspx?idEmpleado={idEmpleado}");
        }
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idEmpleado = btn.CommandArgument.ToString();

            using (DBCrudPrograEntities db = new DBCrudPrograEntities())
            {
                Empleado empleado = db.Empleado.Find(Convert.ToInt32(idEmpleado));

                if (empleado == null)
                {

                }
                else
                {
                    db.Empleado.Remove(empleado);
                    db.SaveChanges();
                }
            }
            
            ShowEmpleados();
        }
        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            int ? filtroDepto = null;
            int ? filtroEstado = null;

            if (String.IsNullOrEmpty(ddlDepartamento.SelectedValue.ToString()))
            {
                if (ddlEstado.SelectedIndex == 0)
                    ShowEmpleados(filtroDepto, filtroEstado);
                else   
                    ShowEmpleados(filtroDepto,Convert.ToInt16(ddlEstado.SelectedItem.Value));
            }
            else
            {
                if (ddlEstado.SelectedIndex == 0)
                    ShowEmpleados(Convert.ToInt32(ddlDepartamento.SelectedValue), filtroEstado);
                else
                    ShowEmpleados(Convert.ToInt32(ddlDepartamento.SelectedValue), Convert.ToInt16(ddlEstado.SelectedItem.Value));
            }

        }
        private void LoadDepartamentos(string idDepartamento = null)
        {
            using (DBCrudPrograEntities db = new DBCrudPrograEntities())
            {
                List<Departamento> listaDepartamentos = db.Departamento.AsNoTracking().ToList();

                ddlDepartamento.DataTextField = "Nombre";
                ddlDepartamento.DataValueField = "idDepartamento";

                ddlDepartamento.DataSource = listaDepartamentos;
                ddlDepartamento.DataBind();

                if (idDepartamento != null)
                {
                    ddlDepartamento.SelectedValue = idDepartamento;
                }
                else
                {
                    ddlDepartamento.Items.Insert(0, new ListItem("Seleccione un departamento", ""));
                }
            }
        }
    }
}