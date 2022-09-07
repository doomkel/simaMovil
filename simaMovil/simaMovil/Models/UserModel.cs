
using System;
using System.Collections.Generic;
using System.Text;

namespace simaMovil.Models
{
    public class UserModel
    {
        
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public UserModel() { }
        public UserModel(string Usuario, string Clave)
        {
            this.Usuario = Usuario;
            this.Clave = Clave;
        }
       

    }
}
