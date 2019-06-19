using System;

namespace EjercicioEntrevista
{
    class Persona
    {
        private String FirstName;
        private String Surname;
        private String Dob;//date of birth
        private Boolean MaritalStatus;// if true married, otherwise single.
        private int id;
        private int pareja;
        private Operaciones ops = new Operaciones();
        
        /**
         * Constructor con parametros
         */
        public Persona(string firstName, string surname, string dob, bool maritalStatus,int pareja)
        {
            FirstName = firstName;
            Surname = surname;
            Dob = dob;
            MaritalStatus = maritalStatus;
            this.pareja = pareja;
        }

        public Persona(string firstName, string surname, string dob, bool maritalStatus)
        {
            FirstName = firstName;
            Surname = surname;
            Dob = dob;
            MaritalStatus = maritalStatus;
            this.pareja = -2;
        }
            /**
             * Constructor por defecto
             */
            public Persona() { }
        
        /**
         * Override de equals para poder comparar personas.
         */
        public override bool Equals(object obj)
        {
            var persona = obj as Persona;
            return persona != null &&
                   FirstName.Trim() == persona.FirstName.Trim() &&
                   Surname == persona.Surname &&
                   Dob == persona.Dob &&
                   MaritalStatus == persona.MaritalStatus;
        }

        /**
         * Getter / setter for FirstName
         */
        public String _FirstName {
            get
            {
                return this.FirstName;
            }
            set
            {
                this.FirstName = value;
            }
        }

        public int _pareja
        {
            get
            {
                return this.pareja;
            }
            set
            {
                this.pareja = value;
            }
        }

        /**
         * Getter / setter for Surname
         */
        public String _Surname
        {
            get
            {
                return this.Surname;
            }
            set
            {
                this.Surname = value;
            }
        }

        /**
         * Getter / setter for Date of birth
         */
        public String _Dob
        {
            get
            {
                return this.Dob;
            }
            set
            {
                this.Dob = value;
            }
        }

        /**
         * Getter / setter for Marital Status
         */
        public Boolean _MaritalStatus
        {
            get
            {
                return this.MaritalStatus;
            }
            set
            {
                this.MaritalStatus = value;
            }
        }

        public int _id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public override string ToString()
        {
            String stat;
            if (_MaritalStatus) stat = "Married";
            else stat = "Single";
            return "\nName: " + _FirstName.Trim() + "\nSurname: " + _Surname + "\nBorn in: " + _Dob + "\nMarital Status: " +stat+"\nEstimated Age: "+ops.CalcularEdad(this);
        }
    }
}
