﻿using ControleCustos.Dominio;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Models
{
    public class ControleRecursoModel
    {
        public int IdRecurso { get; set; }

        public int IdProjeto { get; set; }

        public string NomeProjeto { get; set; }

        public string NomeRecurso { get; set; }

        [Required]
        [DisplayName("Data de início")]
        public DateTime DataInicio { get; set; }

        [Required]
        [DisplayName("Data de fim")]
        public DateTime DataFim { get; set; }

        public ControleRecursoModel(Recurso recurso, Projeto projeto, DateTime dataInicio, DateTime dataFim)
        {
            this.IdRecurso = recurso.Id;
            this.IdProjeto = projeto.Id;
            this.NomeRecurso = recurso.Nome;
            this.NomeProjeto = projeto.Nome;
            this.DataInicio = dataInicio;
            this.DataFim = dataFim;
        }

        public ControleRecursoModel() { }
    }
}