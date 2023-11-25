using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace global_enterprise.Entities
{
    public class Registro
    {
        [Key]
        public int IdRegistro { get; set; }
        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }
        [Required]
        [MaxLength(11)]
        public string Vacina { get; set; }
        [Required]
        [MaxLength(11)]
        public string Unidade { get; set; }

        // Função de busca de registros por CPF
        public static void BuscarRegistrosPorCPF(string cpf)
        {
            // Inicializa a lista de registros (pode ser substituída por uma lógica de banco de dados real)
            List<Registro> registros = new List<Registro>
            {
                new Registro { IdRegistro = 1, CPF = "12345678901", Vacina = "Corona", Unidade = "HospitalX" }
                // Adicione mais registros conforme necessário
            };

            // Utiliza LINQ para filtrar os registros com base no CPF
            var registrosEncontrados = registros.Where(r => r.CPF.Equals(cpf)).ToList();

            // Exibe os registros encontrados na console
            foreach (var registro in registrosEncontrados)
            {
                Console.WriteLine($"ID: {registro.IdRegistro}, CPF: {registro.CPF}, Vacina: {registro.Vacina}, Unidade: {registro.Unidade}");
            }
        }
    }
}
