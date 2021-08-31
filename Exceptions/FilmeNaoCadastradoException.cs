using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_api.Exceptions
{
    public class FilmeNaoCadastradoException : Exception
    {
        public FilmeNaoCadastradoException() : base("O Filme não existe no banco de dados!")
        {

        }
    }
}
