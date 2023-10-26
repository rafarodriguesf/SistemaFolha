using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFolha.Models
{
    public class HorasTrabalhadas
    {
        public int HorasTrabalhadasId { get; set; }

        [Required]
        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }

        public DateTime DataHorasTrabalhadas { get; set; }

        [StringLength(5)]
        public string HoraEntradaHorasTrabalhadas { get; set; }

        [StringLength(5)]
        public string HoraSaidaHorasTrabalhadas { get; set; }
    }
}
