using System;
using System.Collections.Generic;
using System.Text;

namespace simaMovil.Dtos
{
    internal class RepVtaMesDto
    {
        public decimal? tienda { get; set; }
        public string nombre { get; set; }
        public decimal pzas { get; set; }
        public decimal venta2014 { get; set; }
        public decimal venta2013 { get; set; }
        public decimal dif { get; set; }
        public decimal ptje { get; set; }
        public decimal meta { get; set; }
        public decimal ptjeMeta { get; set; }
    }
}
