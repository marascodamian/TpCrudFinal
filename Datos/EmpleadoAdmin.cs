using System;
using System.Collections.Generic;
using System.Linq;
using TpCrudFinal;
using System.Data.Entity;
using TpCrudFinal.EF;
using System.Data.Entity.Core.Common.CommandTrees;

namespace TpCrudFinal.Datos
{
    public class EmpleadoAdmin
    {
        public bool SaveEmpleado(Empleado empleado)
        {
            using (DBCrudPrograEntities db = new DBCrudPrograEntities())
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return true;
            }
        }
        public bool EditEmpleado(Empleado empleado)
        {
            using (DBCrudPrograEntities db = new DBCrudPrograEntities())
            {
                Empleado empleadoBase = db.Empleado.Find(empleado.IdEmpleado);

                empleadoBase.Nombre = empleado.Nombre;
                empleadoBase.Apellido = empleado.Apellido;
                empleadoBase.Email = empleado.Email;
                empleadoBase.FechaNacimiento = empleado.FechaNacimiento;
                empleadoBase.IdDepartamento = empleado.IdDepartamento;
                empleadoBase.Puesto = empleado.Puesto;
                empleadoBase.Sueldo = empleado.Sueldo;
                empleadoBase.FechaContrato = empleado.FechaContrato;
                empleadoBase.IdDepartamento = empleado.IdDepartamento;
                empleadoBase.Activo = empleado.Activo;

                db.SaveChanges();
                return true;
            }
        }
        public Empleado GetEmpleadoById(int id)
        {
            using (DBCrudPrograEntities db = new DBCrudPrograEntities())
            {

                Empleado empleado = db.Empleado
                     .Include(e => e.Departamento)
                     .FirstOrDefault(e => e.IdEmpleado == id);


                return empleado;
            }
        }

        public List<Empleado> GetEmpleadoByDepto(int depto)
        {
            List<Empleado> empleados = new List<Empleado>();

            using(DBCrudPrograEntities dB = new DBCrudPrograEntities())
            {
                empleados = dB.Empleado.Where(d => d.IdDepartamento == depto).ToList();

                return empleados;
            }
        }
    }
}