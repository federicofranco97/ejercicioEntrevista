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
        private const String add="1" ;
        private const String view="2";
        private const String modify="3";
        private const String delete="4";
        private const String exit = "5";

        public Program()
        {
           
        }

        public void menuPrincipal()
        {
            Console.WriteLine("Welcome to the main menu");
            Console.WriteLine("Please select your action:");
            String options = "1-Add a Person\n2-View all\n3-Modify a Person\n4-Delete a person\n5-Exit\n\n";
            Console.WriteLine(options);
            String op = Console.ReadLine();
            switch (op)
            {
                case add:
                    ops.cargarPersona();
                    menuPrincipal();
                    break;
                case view:
                    ops.mostrarPersonas();
                    menuPrincipal();
                    break;
                case modify:
                    menuPrincipal();
                    break;
                case delete:
                    menuPrincipal();
                    break;
                case exit:
                    Environment.Exit(0);
                    break;
                default:
                    menuPrincipal();
                    break;
            }
        }
        static void Main(string[] args)
        {
            var prog = new Program();
            prog.menuPrincipal();
        }
    }
}
