﻿using System.ComponentModel.DataAnnotations.Schema;

namespace teste_cliente.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public int IdCandidatoFoto { get; set; }
        [ForeignKey("IdCandidatoFoto")]
        public virtual Candidato Candidato { get; set; }
        public byte[]? FotoPerfil { get; set; }
    }
}
