using System;
using System.Collections.Generic;

namespace EjercicioEntrevista
{
    class Operaciones
    {
        List<Persona> listPersona = new List<Persona>();

        public void eliminarPersona()
        {
            int numero;
            Console.WriteLine("Type the person number you want to delete: ");
            while (!validarDelete(numero=Convert.ToInt32(Console.ReadLine())))
            {
                Console.WriteLine("Invalid parameter");
            }
            if (listPersona[numero]._MaritalStatus)
            {
                int pareja=listPersona[numero]._pareja;
                listPersona[pareja]._pareja = -2;
            }
            listPersona.RemoveAt(numero);
            Console.WriteLine("\nUser removed succesfully!\n");
            asignarId();
        }

        public Boolean validarDelete(int numero)
        {
            return numero >= 0 && numero < listPersona.Count;
        }

        public void mostrarPersonas()
        {
            Console.WriteLine("************");
            foreach(Persona p in listPersona)
            {
                String parejaNombre = "";
                if (p._pareja != -2)
                {
                    parejaNombre = (listPersona[p._id+p._pareja]._FirstName).Trim();
                }
                else parejaNombre = "None in record";
                Console.WriteLine(p.ToString()+"\nNumber: "+p._id + "\nPareja: "+ parejaNombre);
                
            }
            Console.WriteLine("************");
        }

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

        public void asignarData(List<Persona> list)
        {
            listPersona.AddRange(list);
            asignarId();
        }

        public void asignarId()
        {
            for (int i = 0; i < listPersona.Count; i++)
            {
                listPersona[i]._id = i;
            }
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
                    "therefore cannot be created.\n");
                return;
            }

            if (!autorizarMenor(fechaNac))
            {
                Console.WriteLine("Your parents do not authorize the creation of this profile.");
                return;
            }
            Boolean casado = pedirMaritalStatus();
            Persona p = new Persona(nombre, apellido, fechaNac, casado);
            p._id = listPersona.Count;
            listPersona.Add(p);
            Console.WriteLine("\nUser added succesfully!\n");
            if (casado)
            {
                p._pareja = 1;
                cargarRelacion();
            }
        }

        /**
         * Metodo que pide y valida los datos para crear una persona, y si es menor de 16 descarta la data.
         * Si es menor que 18 pide confirmacion
         * */
        public void cargarRelacion()
        {
            Console.WriteLine("\nPlease add partner\n");
            String nombre = pedirNombre();
            String apellido = pedirApellido();
            String fechaNac = pedirFechaNac();
            if (blockearMenores(fechaNac))
            {
                Console.WriteLine("The user you are trying to create is under the age of 16, \n" +
                    "therefore cannot be created.\n");
                return;
            }

            if (!autorizarMenor(fechaNac))
            {
                Console.WriteLine("Your parents do not authorize the creation of this profile.");
                return;
            }
            Boolean casado = true;
            Persona p =new Persona(nombre, apellido, fechaNac, casado);
            p._id = -1;
            listPersona.Add(p);
            Console.WriteLine("\nRelacion added succesfully!\n");
        }

        /**
         * Metodo que convierte la lista de personas en una lista de strings
         */
        public List<String> convertirPersonas()
        {
            List<String> listAux = new List<String>();
            foreach(Persona p in listPersona)
            {
                String aux = p._FirstName + "?" + p._Surname + "?" + p._Dob + "?" + p._MaritalStatus+"?"+p._pareja+"*\n";
                listAux.Add(aux);
            }
            return listAux;
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
                Console.WriteLine("Invalid format or date!");
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
            if (Convert.ToInt32(aux[0]) > 31 || Convert.ToInt32(aux[0]) <1) return false;
            if (Convert.ToInt32(aux[1]) > 12 || Convert.ToInt32(aux[0]) < 1) return false;
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

        public void personasCargadas(List<Persona> list)
        {
            listPersona.AddRange(list);
        }
    }
}
