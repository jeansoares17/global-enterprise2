using System.ComponentModel.DataAnnotations;
namespace global_enterprise.Entities;

public class Anteriores
{
    [Key]
    public int IdRegistroAnteriores { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    [MaxLength (200)]
    public string NomeVacina { get; set; }
    [Required]
    [MaxLength(100)]
    public string FaixaEtaria { get; set; }
}
