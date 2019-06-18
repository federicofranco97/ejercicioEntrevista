using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EjercicioEntrevista
{
    class Operaciones
    {
        public int CalcularEdad(Persona p)
        {
            String[] splitEdad = p._Dob.Split('/');
            String []currentDate = DateTime.Today.ToString("d").Split('/');
            return Convert.ToInt32(currentDate[2])- Convert.ToInt32(splitEdad[2]);
        }

        public int CalcularEdad(String fechaNac)
        {
            String[] splitEdad = fechaNac.Split('/');
            String[] currentDate = DateTime.Today.ToString("d").Split('/');
            return Convert.ToInt32(currentDate[2]) - Convert.ToInt32(splitEdad[2]);
        }

        public void cargarPersona()
        {
            String nombre = pedirNombre();
            String apellido = pedirApellido();
            String fechaNac = pedirFechaNac();
        }

        /**
         * Metodo que pide el estado marital
         * */
        public String pedirMaritalStatus()
        {
            Console.WriteLine("Insert date of birth as shown:\n dd/mm/yyyy");
            String fechaNac;
            while (!validarFecha(fechaNac = Console.ReadLine()))
            {
                Console.WriteLine("Invalid format!");
            }
            return fechaNac;
        }

        /**
         * Metodo que pide la fecha de nacimento de la persona
         * */
        public String pedirFechaNac()
        {
            Console.WriteLine("Insert date of birth as shown:\n dd/mm/yyyy");
            String fechaNac;
            while (!validarFecha(fechaNac = Console.ReadLine()))
            {
                Console.WriteLine("Invalid format!");
            }
            return fechaNac;
        }

        /**
         * Metodo que pide el nombre de la persona
         * */
        public String pedirNombre()
        {
            Console.WriteLine("Insert new name: ");
            String nombrePersona;
            while (!validarNombre(nombrePersona = Console.ReadLine()))
            {
                Console.WriteLine("Invalid name!");
            }
            return nombrePersona;
        }

        /**
         * Metodo que pide el apellido de la persona
         * */
        public String pedirApellido()
        {
            Console.WriteLine("Insert new surname: ");
            String apellidoPersona;
            while (!validarNombre(apellidoPersona = Console.ReadLine()))
            {
                Console.WriteLine("Invalid surname!");
            }
            return apellidoPersona;
        }

        /**
         * Metodo que valida la fecha de nacimiento
         * */
        public Boolean validarFecha(String fechaNac)
        {
            try
            {
                int operacion = Convert.ToInt32(fechaNac[0]) + 5;
            }
            catch (FormatException e)
            {
                return false;
            }
            if (fechaNac[0].Equals(" ")) return false;

            var regex = @"^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$";
            var match = Regex.Match(fechaNac, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return true;
            }
            return false;
        }


        /**
         * Metodo que valida el nombre ingresado
         * */
        public Boolean validarNombre(String nombre)
        {
            try
            {
                int operacion=Convert.ToInt32(nombre[0])+5;
            }
            catch (FormatException e)
            {
                return false;
            }
            foreach (char c in nombre)
            {
                if (!c.Equals("") || !c.Equals(" "))
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Metodo que checkea si la edad es menor que 16 o si es menor de 18
         * */
        public Boolean blockearMenores(String fechaNac)
        {
            int edad = CalcularEdad(fechaNac);
            return edad < 16;
        }
    }
}
