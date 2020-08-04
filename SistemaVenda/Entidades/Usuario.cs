﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Entidades
{
    public class Usuario
    {
        [Key]
        public int? Codigo { get; set; } /* ? pq o int pode receber nulo pois no banco o codigo ta como autoincrement*/
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
