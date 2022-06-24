using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace usuario.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}