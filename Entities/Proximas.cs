using System.ComponentModel.DataAnnotations;

namespace global_enterprise.Entities
{
    public class Proximas
    {
        [Key]
        public int IdRegistroProximas { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        [MaxLength(200)]
        public string NomeVacina { get; set; }
        [Required]
        [MaxLength(100)]
        public string FaixaEtaria { get; set; }
        [MaxLength(400)]
        public string Recomendacoes { get; set; }
    }
}
