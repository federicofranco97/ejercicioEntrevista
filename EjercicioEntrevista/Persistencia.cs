using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EjercicioEntrevista
{
    class Persistencia
    {
        public Persistencia() { }
        String rutaPersonas = "C:\\Users\\Public\\PersonasGuardadas\\Personas.txt";
        String rutaRelaciones = "C:\\Users\\Public\\PersonasGuardadas\\Relaciones.txt";

        public void guardarPersonas(List<String> list)
        {
            File.Create(@rutaPersonas).Close();
            File.WriteAllLines(@rutaPersonas, list);
        }

        public void guardarRelaciones(List<String> list)
        {
            File.Create(@rutaRelaciones).Close();
            File.WriteAllLines(@rutaRelaciones, list);
        }
        
        public List<Persona> traerPersonas()
        {
            List<Persona> listAux = new List<Persona>();
            String text;
            var fileStream = new FileStream(rutaPersonas, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            String[] aux = text.Split('*');
            foreach (String s in aux)
            {
                if (s.Equals(" ")) break;
                String s2 = s.Replace(" ","");
                String []aux2 = s2.Split('-');
                if (aux2.Length != 4) break;
                Persona p = new Persona(aux2[0], aux2[1], aux2[2], Convert.ToBoolean(aux2[3].ToLower()));
                listAux.Add(p);
            }
            return listAux;
        }

        public String traerRelaciones()
        {
            string contents = File.ReadAllText(@rutaRelaciones);
            return contents;
        }

        public void cargarTest()
        {
            String data = "Marcos-Perez-12/09/1987-false";
            String data2 = "Damian-Perez-07/09/1997-true";
            List<String> list = new List<String>();
            list.Add(data);
            list.Add(data2);
            guardarPersonas(list);
        }
    }
}
