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
        List<Persona> listPersona = new List<Persona>();

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


        /**
         * Metodo que pide y valida los datos para crear una persona, y si es menor de 16 descarta la data.
         * Si es menor que 18 pide confirmacion
         * */
        public void cargarPersona()
        {
            String nombre = pedirNombre();
            String apellido = pedirApellido();
            String fechaNac = pedirFechaNac();
            if (blockearMenores(fechaNac))
            {
                Console.WriteLine("The user you are trying to create is under the age of 16, \n" +
                    "therefore cannot be created.");
                return;
            }

            if (!autorizarMenor(fechaNac))
            {
                Console.WriteLine("Your parents do not authorize the creation of this profile.");
                return;
            }
            Boolean casado = pedirMaritalStatus();
            listPersona.Add(new Persona(nombre, apellido, fechaNac, casado));
            Console.WriteLine();
            Console.WriteLine("User added succesfully!");
            Console.WriteLine(listPersona.Last().ToString());
            Console.WriteLine();
        }

        /**
         * Metodo que pide el estado marital
         * */
        public Boolean pedirMaritalStatus()
        {
            Console.WriteLine("Insert marital status, true if married or false if single");
            String casado;
            while (!validarCasado(casado = Console.ReadLine()))
            {
                Console.WriteLine("Invalid input!");
            }

            return Convert.ToBoolean(casado);
        }

        public Boolean validarCasado(String casado)
        {
            if (casado.Equals("true") || casado.Equals("false")) return true;
            return false;
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
            if (fechaNac[0].Equals(" ")) return false;
            if (fechaNac.Length != 10) return false;
            //Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");
            String[] aux = fechaNac.Split('/');
            if (aux[0].Length != 2 || aux[1].Length != 2 || aux[2].Length != 4) return false;
            foreach(char c in aux[0])
            {
                if (!Char.IsDigit(c)) return false;
            }
            foreach (char c in aux[1])
            {
                if (!Char.IsDigit(c)) return false;
            }
            foreach (char c in aux[2])
            {
                if (!Char.IsDigit(c)) return false;
            }
            if (Convert.ToInt32(aux[0]) > 31) return false;
            if (Convert.ToInt32(aux[1]) > 12) return false;
            if (Convert.ToInt32(aux[2]) > 2019) return false;
            if (Convert.ToInt32(aux[2]) < 1900) return false;
            return true;
        }


        /**
         * Metodo que valida el nombre ingresado
         * */
        public Boolean validarNombre(String nombre)
        {

            if (Char.IsDigit(nombre[0])) return false;
            if (nombre[0].Equals(' ')) return false;
            foreach (char c in nombre)
            {
                if (!c.Equals(' '))
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

        public Boolean autorizarMenor(String fechaNac)
        {
            int edad = CalcularEdad(fechaNac);
            if (edad < 18)
            {
                Console.WriteLine("The user you are trying to create is underage, do your parents confirm?\ny/n");
                String answer;
                if (!validarAns(answer = Console.ReadLine()))
                {
                    Console.WriteLine("Invalid input!");
                }
                return answer.Equals("y") || answer.Equals('y');
            }
            return true;
        }

        public Boolean validarAns(String ans)
        {
            if (ans.Equals("y") || ans.Equals("n")) return true;
            return false;
        }
    }
}
