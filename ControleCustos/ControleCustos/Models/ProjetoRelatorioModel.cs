﻿using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class ProjetoRelatorioModel
    {
        public string Cliente { get; set; }

        public string Projeto { get; set; }

        public string Gerente { get; set; }

        public decimal CustoTotal { get; set; }

        public decimal CustoMesCorrente { get; set; }

        public decimal FaturamentoPrevisto { get; set; }

        public SituacaoProjeto Situacao { get; set; }

        public ProjetoRelatorioModel() { }

        public ProjetoRelatorioModel(Projeto projeto, decimal custoTotal, decimal custoMesCorrente)
        {
            this.Cliente = projeto.Cliente;
            this.Projeto = projeto.Nome;
            this.Gerente = projeto.Gerente.Nome;
            this.Situacao = projeto.Situacao;
            this.CustoTotal = custoTotal;
            this.CustoMesCorrente = custoMesCorrente;
            this.FaturamentoPrevisto = projeto.FaturamentoPrevisto;
        }
    }
}