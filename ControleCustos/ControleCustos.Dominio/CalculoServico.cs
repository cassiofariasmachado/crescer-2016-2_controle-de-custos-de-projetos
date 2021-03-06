﻿using ControleCustos.Dominio.Interface;
using System;
using System.Collections.Generic;

namespace ControleCustos.Dominio
{
    public class CalculoServico
    {
        private const int QUANTIDADE_DIAS_DO_MES = 30;

        IControleRecursoRepositorio controleRecursoRepositorio;

        public CalculoServico(IControleRecursoRepositorio controleRecursoRepositorio)
        {
            this.controleRecursoRepositorio = controleRecursoRepositorio;
        }

        public decimal CalcularCustoTotalAte(Projeto projeto, DateTime data)
        {
            decimal custoTotal = 0;
            IList<ControleRecurso> listaControleRecurso = controleRecursoRepositorio.Listar(projeto);
            foreach (var controleRecurso in listaControleRecurso)
            {
                // Verifica se recurso está nesse período
                DateTime dataFim = data < controleRecurso.DataFim ? data : controleRecurso.DataFim;
                if (data < controleRecurso.DataInicio) { continue; }
                custoTotal += this.CalcularCustoTotalDoRecursoEntre(controleRecurso.Recurso, controleRecurso.DataInicio, dataFim);
            }
            return custoTotal;
        }

        public decimal CalcularCustoPatrimonioTotalAte(Projeto projeto, DateTime data)
        {
            decimal custoTotal = 0;
            IList<ControleRecurso> listaControleRecurso = controleRecursoRepositorio.ListarPatrimonio(projeto);
            foreach (var controleRecurso in listaControleRecurso)
            {
                // Verifica se recurso está nesse período
                DateTime dataFim = data < controleRecurso.DataFim ? data : controleRecurso.DataFim;
                if (data < controleRecurso.DataInicio) { continue; }
                custoTotal += this.CalcularCustoTotalDoRecursoEntre(controleRecurso.Recurso, controleRecurso.DataInicio, dataFim);
            }
            return custoTotal;
        }

        public decimal CalcularCustoCompartilhadoTotalAte(Projeto projeto, DateTime data)
        {
            decimal custoTotal = 0;
            IList<ControleRecurso> listaControleRecurso = controleRecursoRepositorio.ListarCompartilhado(projeto);
            foreach (var controleRecurso in listaControleRecurso)
            {
                // Verifica se recurso está nesse período
                DateTime dataFim = data < controleRecurso.DataFim ? data : controleRecurso.DataFim;
                if (data < controleRecurso.DataInicio) { continue; }
                custoTotal += this.CalcularCustoTotalDoRecursoEntre(controleRecurso.Recurso, controleRecurso.DataInicio, dataFim);
            }
            return custoTotal;
        }

        public decimal CalcularCustoServicoTotalAte(Projeto projeto, DateTime data)
        {
            decimal custoTotal = 0;
            IList<ControleRecurso> listaControleRecurso = controleRecursoRepositorio.ListarServico(projeto);
            foreach (var controleRecurso in listaControleRecurso)
            {
                // Verifica se recurso está nesse período
                DateTime dataFim = data < controleRecurso.DataFim ? data : controleRecurso.DataFim;
                if (data < controleRecurso.DataInicio) { continue; }
                custoTotal += this.CalcularCustoTotalDoRecursoEntre(controleRecurso.Recurso, controleRecurso.DataInicio, dataFim);
            }
            return custoTotal;
        }

        public decimal CalcularCustoPercentual(Projeto projeto, DateTime data)
        {
            decimal custoTotal = this.CalcularCustoTotalAte(projeto, data);
            // Se faturamento for zero, retorna zero se não existir custo e 100 se existir
            if (projeto.FaturamentoPrevisto == 0) {
                if (custoTotal > 0)
                    return 100;
                else
                    return 0;
            }
            // custoPercentual = custoTotal * 100 / FaturamentoPrevisto
            return custoTotal * 100 / projeto.FaturamentoPrevisto;
        }

        public decimal CalcularCustoMensal(Projeto projeto, int mes, int ano)
        {
            decimal custoTotal = 0;

            DateTime primeiroDiaDoMes = new DateTime(ano, mes, 1);
            DateTime ultimoDiaDoMes = primeiroDiaDoMes.AddMonths(1).AddDays(-1).AddTicks(-1);
            IList<ControleRecurso> listaControleRecurso = controleRecursoRepositorio.Listar(projeto, primeiroDiaDoMes, ultimoDiaDoMes);

            foreach (var controleRecurso in listaControleRecurso)
            {
                // Verifica se recurso não acaba na metade do mês
                DateTime dataInicio = controleRecurso.DataInicio > primeiroDiaDoMes ? controleRecurso.DataInicio : primeiroDiaDoMes;
                DateTime dataFim = controleRecurso.DataFim < ultimoDiaDoMes ? controleRecurso.DataFim : ultimoDiaDoMes;
                custoTotal += this.CalcularCustoTotalDoRecursoEntre(controleRecurso.Recurso, controleRecurso.DataInicio, dataFim);
            }

            return custoTotal;
        }

        public decimal CalcularCustoTotalDoRecursoEntre(Recurso recurso, DateTime dataInicio, DateTime dataFim)
        {
            decimal custoPorDia = recurso.ValorMensal / QUANTIDADE_DIAS_DO_MES;
            var diferencaDatas = dataFim - dataInicio;
            decimal quantidadeDias = (decimal)diferencaDatas.TotalDays;
            decimal custoTotalDoRecurso = custoPorDia * quantidadeDias;
            return custoTotalDoRecurso;
        }
    }
}
