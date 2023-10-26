using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SistemaFolha.Models
{
    public class Ferias
    {
        public int FeriasId { get; set; }

        [Required]
        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataInicioFerias { get; set; }

        [Required]
        public DateTime DataFimFerias { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorFerias { get; set; }
    }
}
