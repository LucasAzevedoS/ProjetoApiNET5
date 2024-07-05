using System;

namespace ProjetoApiNET5.Models
{
    public class usuarios
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public int idade { get; set; }
        public DateTime dt_cadastro { get; set; }
    }
}
