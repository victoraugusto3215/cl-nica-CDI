using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação_vaga_GW
{
    class Procedimentos
    {
        private string Nome;
        private TimeSpan Duracao;
        private string Codigo;

        public Procedimentos(String nome, TimeSpan duracao, string codigo)
        {
            this.Nome = nome;
            this.Duracao = duracao;
            this.Codigo = codigo;
        }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public String GetNome()
        {
            return this.Nome;
        }

        public void SetCodigo(string codigo)
        {
            this.Codigo = codigo;
        }

        public String GetCodigo()
        {
            return this.Codigo;
        }

        public void SetDuracao(TimeSpan duracao)
        {
            this.Duracao = duracao;
        }
        public TimeSpan GetDuracao()
        {
            return this.Duracao;
        }
    }
}
