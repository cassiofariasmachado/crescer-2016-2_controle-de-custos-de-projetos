﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCustos.Dominio.Interface
{
    public interface IControleRecursoRepositorio
    {
        ControleRecurso Buscar(int id);
        IList<ControleRecurso> Listar(Projeto projeto);
        IList<ControleRecurso> Listar(Projeto projeto, DateTime dataInicio, DateTime dataFim);
        void Inserir(ControleRecurso controleRecurso);
        void Atualizar(ControleRecurso controleRecurso);
    }
}
