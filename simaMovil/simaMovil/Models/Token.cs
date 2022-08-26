using System;
using System.Collections.Generic;
using System.Text;

namespace simaMovil.Models
{
    internal class Token
    {
        public string TokenText { get; set; }
        public string Type { get; set; }
        public DateTime Expiration { get; set; }


    }
}
