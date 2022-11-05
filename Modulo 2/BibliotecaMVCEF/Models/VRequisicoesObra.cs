
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaMVCEF.Models
{
    //[Keyless]
    public partial class VRequisicoesObra
    {
        [Column("nome")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nome { get; set; }
        [Column("titulo")]
        [StringLength(50)]
        [Unicode(false)]
        public string Titulo { get; set; }

      
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
    }
}