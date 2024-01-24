using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação_vaga_GW
{
    class Atendimento
    {
        private Paciente Paciente;
        private DateTime Data;
        private Procedimentos Procedimento;

        public Atendimento(Paciente paciente, DateTime data, Procedimentos procedimento)
        {
            this.Paciente = paciente;
            this.Data = data;
            this.Procedimento = procedimento;
        }

        public void SetPaciente(Paciente paciente)
        {
            this.Paciente = paciente;
        }

        public Paciente GetPaciente()
        {
            return this.Paciente;
        }

        public void SetData(DateTime data)
        {
            this.Data = data;
        }

        public DateTime GetData()
        {
            return this.Data;
        }

        public void SetProcedimento(Procedimentos procedimento)
        {
            this.Procedimento = procedimento;
        }

        public Procedimentos GetProcedimento()
        {
            return this.Procedimento;
        }
    }


}
