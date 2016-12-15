﻿using ControleCustos.Dominio.Recurso.Classe;
using ControleCustos.Dominio.Projeto.Enum;
using ControleCustos.Dominio.UsuarioDominio.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCustos.Dominio.Projeto
{
    public class Projeto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public Usuario Gerente { get; set; }

        [Required]
        public string Cliente { get; set; }

        [Required]
        public string Tecnologia { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFinalPrevista { get; set; }

        public DateTime DataFinalRealizada { get; set; }

        [Required]
        public double FaturamentoPrevisto { get; set; }

        public double FaturamentoRealizado { get; set; }

        [Required]
        public int NumeroDeProfissionais { get; set; }

        [Required]
        public SituacaoProjeto Situacao { get; set; }

        [Required]
        public ICollection<Recurso.Classe.Recurso> Recursos { get; set; }

        public Projeto ()
        {
            this.Recursos = new List<Recurso.Classe.Recurso>();
        }
    }
}
