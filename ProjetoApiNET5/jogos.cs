using System;

namespace ProjetoApiNET5
{
    public class jogos
    {
        public int Id { get; set; }
        public int Id_usuario { get; set; }
        public string nome { get; set; }
        public int avalicacao { get; set; }
        public bool status { get; set; }
        public DateTime dt_create { get; set; }
    }
}
