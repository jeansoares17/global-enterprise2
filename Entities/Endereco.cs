using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace global_enterprise.Entities
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }

        [MaxLength(8)]
        public string CEP { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(80)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }
    }
}
