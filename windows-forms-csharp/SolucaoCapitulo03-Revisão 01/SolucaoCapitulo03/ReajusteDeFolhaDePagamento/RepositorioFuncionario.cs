﻿using System.Collections.Generic;
using System.ComponentModel;

namespace ReajusteDeFolhaDePagamento
{
    public class RepositorioFuncionario
    {
        private IList<Funcionario> funcionarios = new BindingList<Funcionario>();

        public void Inserir(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
        }

        public IList<Funcionario> ObterTodos()
        {
            return this.funcionarios;
        }
    }
}
