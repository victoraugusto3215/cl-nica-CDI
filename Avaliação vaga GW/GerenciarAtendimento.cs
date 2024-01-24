using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação_vaga_GW
{
    static class GerenciarAtendimento
    {
        public static List<Atendimento> ListAtendimento = new List<Atendimento>();
        // Submenu Atendimento
        public static void menu()
        {
            Console.WriteLine("Digite a opção escolhida:");
            Console.WriteLine("1 - Cadastrar Atendimento");
            Console.WriteLine("2 - Listar Atendimento por Data");
            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Opção inválida!");
                return;
            }
            switch(opcao)
            {
                case 1:
                    CadastrarAtendimento();
                    break;
                case 2:
                    Buscar();
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        }

        public static void CadastrarAtendimento()
        {
            Console.WriteLine("Procure pelo paciente pelo nome, CPF ou pela Data de Nascimento:  ");
            Paciente pacienteBusca = GerenciarPaciente.Buscar(Console.ReadLine());
            if(pacienteBusca != null)
            {
                Console.WriteLine("Paciente: " + pacienteBusca.GetNome());
                Console.WriteLine("Digite a data do Atendimento: ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataAtendimento))
                {
                    Console.WriteLine("Data inválida!");
                    return;
                }
                Console.WriteLine("Procedimentos disponíveis: ");
                GerenciarProcedimento.Buscar();
                Console.WriteLine("Digite o codigo do procedimento: ");
                string codigo = Console.ReadLine();
                Procedimentos procedimento = GerenciarProcedimento.Buscar(codigo);// Médoto Buscar procura e retorna código do Procedimendo
                bool verifica = GerenciarProcedimento.validaProcedimento(dataAtendimento,procedimento,pacienteBusca);
                if(verifica == true)
                {
                    Atendimento atendimento = new Atendimento(pacienteBusca, dataAtendimento, procedimento);
                    ListAtendimento.Add(atendimento);
                    Console.WriteLine("Atendimento Realizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não é possivel realizar o agendamento");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Paciente não encontrado!");
                Console.WriteLine("Aperte Enter para cadastrar o Paciente");
                Console.ReadLine();
                GerenciarPaciente.CadastrarCliente();
            }            
        }

        public static void Buscar() // Método lista os atendimentos de uma determinada data
        {
            Console.WriteLine("Qual data deseja consultar?");
            string data = Console.ReadLine();
            foreach (Atendimento atendimento in ListAtendimento)
            {
                if(atendimento.GetData().ToString("dd/MM/yyyy") == data)
                {
                    Console.WriteLine("Paciente: " + atendimento.GetPaciente().GetNome());
                    Console.WriteLine("Data: " + atendimento.GetData().ToString("dd/MM/yyyy"));
                    Console.WriteLine("Procedimento: " + atendimento.GetProcedimento().GetNome());
                    Console.WriteLine();
                }
            }
        }
        // O metodo VerificarAtendimento, verifica o historico de atendimentos dos últimos 3 messes,
        // para verificar para se o usuario pode ou nao realizar a Tomografia 
        public static bool VerificarAtendimento(DateTime data,Paciente paciente,string codigoObstetrica, string codigoProstata)
        {
            DateTime DataLimite = data.AddMonths(-3);
            foreach(Atendimento atendimento in ListAtendimento)
            {
               if(atendimento.GetPaciente().GetCPF() == paciente.GetCPF() && atendimento.GetProcedimento().GetCodigo() == codigoObstetrica || atendimento.GetProcedimento().GetCodigo() == codigoProstata && atendimento.GetData() >= DataLimite)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
