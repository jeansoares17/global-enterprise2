using System.ComponentModel.DataAnnotations;
namespace global_enterprise.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class Usuario
{
    [Key]
    public int IdCadastro { get; set; }
    [Required]
    [MaxLength(300)]
    public string Nome { get; set; }
    [Required]
    [MaxLength(80)]
    public string Nacionalidade { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    [MaxLength(11)]
    public string CPF { get; set; }
    [MaxLength(15)]
    public string SUS { get; set; }
    [Required]
    [MaxLength(100)]
    public string Login { get; set; }
    [Required]
    [MaxLength(8)]
    public string Senha { get; set; }
}
