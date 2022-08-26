
using System;
using System.Collections.Generic;
using System.Text;

namespace simaMovil.Models
{
    public class User
    {
        
        //public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public User() { }
        public User(string Usuario, string Clave)
        {
            this.Usuario = Usuario;
            this.Clave = Clave;
        }

        public bool CheckInformation()
        {
            if (!this.Usuario.Equals("") && !this.Clave.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
