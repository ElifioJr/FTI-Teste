﻿
using Dapper.Contrib.Extensions;

namespace Teste_API.Entidade
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int idusuario { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public string senha { get; set; }
        public string idade { get; set; }
        public string email { get; set; }
    }
}