using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLINQ
{
    internal class ControlEmpleadosEmpresas
    {
        public List<Empresa> listaEmpresas;
        public List<Empleado> listaEmpleados;
        public ControlEmpleadosEmpresas()
        {
            listaEmpresas = new List<Empresa>();
            listaEmpleados = new List<Empleado>();

            listaEmpresas.Add(new Empresa { id=1, name= "Microsoft"});
            listaEmpresas.Add(new Empresa { id = 2, name = "Google" });
            listaEmpresas.Add(new Empresa { id = 3, name = "Apple" });

            listaEmpleados.Add(new Empleado { id= 1, name="Mai", cargo= "Cajero", EmpresaId= 1, salario= 1000.00});
        }
    }
}
