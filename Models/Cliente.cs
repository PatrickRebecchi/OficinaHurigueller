using System.ComponentModel.DataAnnotations;

namespace OficinaHurigueller.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public string ModeloCarro { get; set; }
        public string Telefone { get; set; }
    }
}