using System;
using System.Collections.Generic;
using System.Text;

namespace simaMovil.Models
{
    internal class RepVtaMesModel
    {
        public decimal? Tienda { get; set; }
        public string Nombre { get; set; }
        public decimal Pzas { get; set; }
        public decimal VentaAct { get; set; }
        public decimal VentaAP { get; set; }
        public decimal Dif { get; set; }
        public decimal Ptje { get; set; }
        public decimal Meta { get; set; }
        public decimal PtjeMeta { get; set; }
    }
}
