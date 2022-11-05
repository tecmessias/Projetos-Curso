
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaMVCEF.Models
{
    public partial class Leitor
    {
        public Leitor()
        {
            Requisicoes = new HashSet<Requisicoes>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nome { get; set; }
        [Column("endereco")]
        [StringLength(50)]
        [Unicode(false)]
        public string Endereco { get; set; }

        [InverseProperty("IdLeitorNavigation")]
        public virtual ICollection<Requisicoes> Requisicoes { get; set; }
    }
}