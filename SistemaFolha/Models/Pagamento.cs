using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFolha.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }

        [Required]
        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }

        public DateTime DataPagamento { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorPago { get; set; }
    }
}

