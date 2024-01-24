using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação_vaga_GW
{
    class Paciente
    {
        private string Nome;
        private string NomeMae;
        private DateTime DataNascimento;
        private char Sexo;
        private int CPF;

        public Paciente(String nome, String nomeMae, DateTime dataNascimento, char sexo, int cpf)
        {
            this.Nome = nome;
            this.NomeMae = nomeMae;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.CPF = cpf;
        }

        public void SetNome(String nome)
        {
            this.Nome = nome;
        }

        public string GetNome()
        {
            return this.Nome;
        }

        public void SetNomeMae(string nomeMae)
        {
            this.NomeMae = nomeMae;
        }

        public string GetMae()
        {
            return this.NomeMae;
        }

        public void SetNascimento(DateTime data)
        {
            this.DataNascimento = data;
        }

        public DateTime GetData()
        {
            return this.DataNascimento;
        }

        public void SetSexo(char sexo)
        {
            this.Sexo = sexo;
        }

        public char GetSexo()
        {
            return this.Sexo;
        }

        public void SetCPF(int cpf)
        {
            this.CPF = cpf;
        }
        public int GetCPF()
        {
            return this.CPF;
        }

        public int GetIdade()
        {
            return DateTime.Now.Year - DataNascimento.Year;
        }
    }
}
