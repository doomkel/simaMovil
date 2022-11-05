using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace simaMovil.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value;
                OnPropertyChanged();
            }
        }

        private string clave; 
        public string Clave
        {
            get { return clave; }
            set { clave = value;
                OnPropertyChanged();
            }
        }


        public int Perfil { get; set; }


        private bool isbusy;
        public bool IsBusy
        {
            get { return isbusy; }
            set { isbusy = value;
                OnPropertyChanged();
            }
        }



    }
}
