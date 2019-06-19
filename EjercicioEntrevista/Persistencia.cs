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

        /**
         * Guarda la lista de string en el txt de la ruta
         */
        public void guardarPersonas(List<String> list)
        {
            File.Create(@rutaPersonas).Close();
            //File.WriteAllLines(@rutaPersonas, list);
            using (StreamWriter sw = File.AppendText(rutaPersonas))
            {
                foreach (var line in list)
                {
                    sw.WriteLine(line);
                }
            }
        }

        /**
         * Lee cada linea del txt, la parsea como persona y la agrega a una lista que devuelve.
         */
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
                String s2 = s.Replace("\n","");
                String []aux2 = s2.Split('?');
                if (aux2.Length != 5) break;
                Persona p = new Persona(aux2[0], aux2[1], aux2[2], Convert.ToBoolean(aux2[3].ToLower()),Convert.ToInt32(aux2[4]));
                listAux.Add(p);
            }
            return listAux;
        }

    }
}
