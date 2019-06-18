using System;

namespace EjercicioEntrevista
{
    class Program
    {
        public Operaciones ops = new Operaciones();
        public Persistencia per = new Persistencia();
        private const String add="1" ;
        private const String view="2";
        private const String modify="3";
        private const String delete="4";
        private const String exit = "5";

        /**
         * Constructor vacio para poder invocar los metodos
         */
        public Program()
        {
           
        }

        /**
         * Trae la lista de personas de la persistencia y las agrega a la lista de personas
         */
        public void levantarData()
        {
            ops.asignarData(per.traerPersonas());
        }

        /**
         * Metodo de menu principal que permite elegir que metodo se quiere ejecutar
         */
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
                    Console.WriteLine();
                    menuPrincipal();
                    break;
                case modify:
                    menuPrincipal();
                    break;
                case delete:
                    menuPrincipal();
                    break;
                case exit:
                    per.guardarPersonas(ops.convertirPersonas());
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid choice!\n");
                    menuPrincipal();
                    break;
            }
        }
        static void Main(string[] args)
        {
            var prog = new Program();
            prog.levantarData();
            prog.menuPrincipal();
            //var p = new Persistencia();
            //p.traerPersonas();
        }
    }
}
