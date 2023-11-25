using System.ComponentModel.DataAnnotations;
namespace global_enterprise.Entities;

public class StatusVacina
{
    [Key]
    public int IdStatus { get; set; }
    [Required]
    [MaxLength(20)]
    public string TipoStatus { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    [Range(1, 999999)]
    public int NumeroLote { get; set; }

    public void AlterarStatus(string novoTipoStatus, DateTime novaData, int novoNumeroLote)
    {
        // Verifica se os novos valores são válidos antes de realizar a alteração
        if (ValidarNovosValores(novoTipoStatus, novaData, novoNumeroLote))
        {
            // Atualiza os valores apenas se forem válidos
            TipoStatus = novoTipoStatus;
            Data = novaData;
            NumeroLote = novoNumeroLote;

            Console.WriteLine("Status da vacina alterado com sucesso!");
        }
        else
        {
            Console.WriteLine("Não foi possível alterar o status da vacina. Novos valores inválidos.");
        }
    }

    private bool ValidarNovosValores(string novoTipoStatus, DateTime novaData, int novoNumeroLote)
    {
        if (string.IsNullOrWhiteSpace(novoTipoStatus) || novoNumeroLote <= 0)
        {
            return false;
        }
        return true;
    }
}
