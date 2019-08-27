namespace EverisAPI.Models
{
    public class Estoque
    {
        public int id { get; set; }
        public Produto produto { get; set; }
        public Empresa empresa { get; set; }
        public int quantidade { get; set; }
    }
}