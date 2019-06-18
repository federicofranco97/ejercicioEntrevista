using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEntrevista
{
    class Program
    {
        public Operaciones ops = new Operaciones();

        static void Main(string[] args)
        {
            var p = new Persona();
            p._FirstName="Pepe";
            p._Surname = "Argento";
            p._Dob = "19/5/1980";
            p._MaritalStatus = true;
            //Console.WriteLine(p.ToString());
            var p2 = new Operaciones();
            p2.cargarPersona();
        }
    }
}
