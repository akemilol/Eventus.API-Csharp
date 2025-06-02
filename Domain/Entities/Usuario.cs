using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventus.API.Domain.Entities
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Senha")]
        public string Senha { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("CEP")]
        public string CEP { get; set; }

        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }

        public ICollection<RelatoEvento> Relatos { get; set; } = new List<RelatoEvento>();
    }
}
