using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_api.ViewModel
{
    public class FilmeViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public double Valor { get; set; }

    }
}
