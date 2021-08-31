using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_api.InputModel
{
    public class FilmeInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2,ErrorMessage ="O Titulo do filme deve conter entre 2 a 100 caracteres")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100,MinimumLength =4,ErrorMessage ="O nome do Diretor deve conter entre 4 e 100 caracteres")]
        public string Diretor { get; set; }

        [Required]
        [Range(1,5000,ErrorMessage ="O Valor do filme deve ser entre 1 e 5000 reais")]
        public double Valor { get; set; }
    }
}
