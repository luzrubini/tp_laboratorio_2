﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPrincipales
{
    public class TrackingIDRepetidoException : Exception
    {

        public TrackingIDRepetidoException(string mensaje) : base(mensaje) { }
        public TrackingIDRepetidoException(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}
