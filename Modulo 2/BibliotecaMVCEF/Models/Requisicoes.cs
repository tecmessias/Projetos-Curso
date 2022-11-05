using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaMVCEF.Models
{
    public partial class Requisicoes
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idObra")]
        public int? IdObra { get; set; }
        [Column("idLeitor")]
        public int? IdLeitor { get; set; }
        [Column("dataRequisicao", TypeName = "date")]
        public DateTime? DataRequisicao { get; set; }
        [Column("dataDevolucao", TypeName = "date")]
        public DateTime? DataDevolucao { get; set; }
        [Column("devolvido")]
        public bool? Devolvido { get; set; }

        [ForeignKey("IdLeitor")]
        [InverseProperty("Requisicoes")]
        public virtual Leitor IdLeitorNavigation { get; set; }
        [ForeignKey("IdObra")]
        [InverseProperty("Requisicoes")]
        public virtual Obras IdObraNavigation { get; set; }
    }
}