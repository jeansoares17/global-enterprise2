using System.ComponentModel.DataAnnotations;
namespace global_enterprise.Entities;

public class Empresa
{
    [Key]
    public int IdEmpresa { get; set; }
    [Required]
    [MaxLength (14)]
    public string CNPJ { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    [Required]
    public DateTime DataInicio { get; set; }
    [Required]
    [MaxLength(100)]
    public string Login { get; set; }
    [Required]
    [MaxLength(8)]
    public string Senha { get; set; }
    [Required]
    public string RazaoSocial { get; set; }
    [Required]
    [MaxLength(20)]
    public string Telefone { get; set; }
}

