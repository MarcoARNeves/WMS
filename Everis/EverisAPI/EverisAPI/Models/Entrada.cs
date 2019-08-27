namespace EverisAPI.Models
{
    public class Entrada
    {
        public int id { get; set; }
        public Produto produto { get; set; }
        public Empresa empresa { get; set; }
        public int quantidade { get; set; }
        public int idEmpresa { get; set; }
        public int idProduto { get; set; }
    }
}