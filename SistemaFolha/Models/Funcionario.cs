using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFolha.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(15)]
        public string CPF { get; set; }

        [Required]
        public DateTime DataNasc { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public DateTime? DataAdmissao { get; set; }

        [Required]
        [MaxLength(50)]
        public string Instituicao { get; set; }

        [Required]
        public int Agencia { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContaCorrente { get; set; }

        public ICollection<Ferias> Ferias { get; set; } = new List<Ferias>();
        public ICollection<HorasTrabalhadas> HorasTrabalhadas { get; set; } =  new List<HorasTrabalhadas>();
        public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    }
}
