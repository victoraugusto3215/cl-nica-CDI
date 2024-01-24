using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação_vaga_GW
{
    static class GerenciarProcedimento
    {
        public static List<Procedimentos> ListProcedimentos = new List<Procedimentos>();
        public static void menu()
        {
            Console.WriteLine("Digite a opção escolhida: ");
            Console.WriteLine("1 - Cadastrar Procedimento");
            Console.WriteLine("2 - Quantidade de procedimentos realizados por período");
            Console.WriteLine("3 - Duração de Procedimento por período");
            
            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Opção inválida!");
                return;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarProcedimento();
                    break;
                case 2:
                    QuantProcedimentoPeriodo();
                    break;
                case 3:
                    DuracaoProcedimentoPeriodo();
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        }

        // O metodo CadastrarProcedimento cadastra novos Procedimentos, mesmo que essa funcionalidade
        // não foi solicitada, e os Procedimentos foram previamente criados, há essa opção caso o usuario deseje futuramente
        public static void CadastrarProcedimento()
        {
            Console.WriteLine("Digite o nome do Procedimento: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite as horas de duração: ");
            int horas = Convert.ToInt32(Console.ReadLine());

            if (horas < 0 || horas > 23)
            {
                Console.WriteLine("Horas inválidas!");
                return;
            }

            Console.WriteLine("Digite os minutos de duração: ");
            int minutos = Convert.ToInt32(Console.ReadLine());
            if (minutos < 0 || minutos > 59)
            {
                Console.WriteLine("Minutos inválidos!");
                return;
            }

            TimeSpan tempo = new TimeSpan(horas, minutos, 0);
            Console.WriteLine("Digite o código do procedimento: ");
            string codigo = Console.ReadLine();

            if(codigo.Length<10)
            {
                Console.WriteLine("Código Inválido, digite um código que contém 10 caracteres!");
                return;
            }
            Procedimentos procedimento = new Procedimentos(nome, tempo, codigo);
            ListProcedimentos.Add(procedimento);
        }

        // O metodo lista todos os procedimentos cadastrados
        public static void Buscar()
        {
            foreach(Procedimentos procediemnto in ListProcedimentos)
            {
                Console.Write("Procedimento: " + procediemnto.GetNome() + " Código: " + procediemnto.GetCodigo());
                Console.WriteLine();
            }
        }

        // A sobrecarga do metodo Buscar, procura o procedimento cadastrado pelo codigo,
        // caso seja encontrado, retona o procedimento
        public static Procedimentos Buscar(string codigo)
        {
            foreach (Procedimentos procediemento in ListProcedimentos)
            {
                if(procediemento.GetCodigo() == codigo)
                {
                    return procediemento;
                }
            }
            return null;
        }
        // O metodo QuantProcedimentoPeriodo, busca a quantidade de procedimento realizada pelo Perido selecionado
        public static void QuantProcedimentoPeriodo()
        {
            Console.WriteLine("Digite uma data de inicio: ");
            DateTime DataInicio = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite uma data final: ");
            DateTime DataFim = Convert.ToDateTime(Console.ReadLine());

            int QuantRaioX = 0;
            int QuantObstetrica = 0;
            int QuantProstata = 0;
            int QuantTamografia = 0;
            int TotalPocedimentos = 0;
            foreach(Atendimento atendimento in GerenciarAtendimento.ListAtendimento)
            {
                if (atendimento.GetData() >= DataInicio && atendimento.GetData() <= DataFim)
                {
                    if(atendimento.GetProcedimento().GetCodigo() == "RAIO_X124")
                    {
                        QuantRaioX++;
                    }
                    else if(atendimento.GetProcedimento().GetCodigo() == "OBTETRICA_")
                    {
                        QuantObstetrica++;
                    }
                    else if(atendimento.GetProcedimento().GetCodigo() == "PROSTADA_1")
                    {
                        QuantProstata++;
                    }
                    else
                    {
                        QuantTamografia++;
                    }

                    TotalPocedimentos++;
                }
            }
            Console.WriteLine("Período: " + DataInicio.ToString("dd/MM/yyyy") + " à " + DataFim.ToString("dd/MM/yyyy") + ":");
            Console.WriteLine("Quantidade de Raios – X de Tórax em PA realizado: " + QuantRaioX);
            Console.WriteLine("Quantidade de Ultrassonografia Obstétrica: realizado: " + QuantObstetrica);
            Console.WriteLine("Quantidade de Ultrassonografia de Próstata realizado: " + QuantProstata);
            Console.WriteLine("Quantidade de Tomografia realizado: " + QuantTamografia);
            Console.WriteLine("O Total de Procedimentos realizados no período de " + DataInicio.ToString("dd/MM/yyyy") + " à " + DataFim.ToString("dd/MM/yyyy") + " foi " + TotalPocedimentos);
        }

        // O metodo  DuracaoProcedimentoPeriodo() verifica a duração de tempo de um ou todos procedimentos.
        // Esse metodo mesmo que faça diversas interações com o GerenciarAtendimendo,
        // como interações com a Lista de Atedimento, o metodo DuracaoProcedimentoPeriodo se trata dos procedimento.
        public static void DuracaoProcedimentoPeriodo()
        {
            Console.WriteLine("Digite uma data de inicio: ");
            DateTime DataInicio = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite uma data final: ");
            DateTime DataFim = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite o código do Procedimento que deseja-se saber a duração total, ou aperte Enter para vê a duração total dos procedimentos: ");
            string codigo = Console.ReadLine();
            
            TimeSpan tempoTotal = new TimeSpan(0);

            if(codigo != "") // Verifica se o usuario digitou algum código, caso tenha digitado faz a busca da duração somente no procedimento correspodente ao codigo
            { 
                foreach (Atendimento atendimento in GerenciarAtendimento.ListAtendimento)
                {
                    if (atendimento.GetProcedimento().GetCodigo() == codigo && atendimento.GetData() >= DataInicio && atendimento.GetData() <= DataFim)
                    {
                        tempoTotal += atendimento.GetProcedimento().GetDuracao();
                    }
                }
                Console.WriteLine("A Duração Total do procedimento no periódo selecionado foi" + tempoTotal);
            }
            else // Caso o usuario não tenha digitado nenhum codigo ele busca a duração de todos os procedimentos realizados
            {
                TimeSpan DuracaoRaio = new TimeSpan(0);
                TimeSpan DuracaoObtetrica = new TimeSpan(0);
                TimeSpan DuracaoProstata = new TimeSpan(0);
                TimeSpan DuracacoTomografia = new TimeSpan(0);
                foreach (Atendimento atendimento in GerenciarAtendimento.ListAtendimento)
                {
                    if(atendimento.GetData() >= DataInicio && atendimento.GetData() <= DataFim)
                    {
                        if (atendimento.GetProcedimento().GetCodigo() == "RAIO_X124")
                        {
                            DuracaoRaio += atendimento.GetProcedimento().GetDuracao();
                        }
                        else if (atendimento.GetProcedimento().GetCodigo() == "OBTETRICA_")
                        {
                            DuracaoObtetrica += atendimento.GetProcedimento().GetDuracao();
                        }
                        else if (atendimento.GetProcedimento().GetCodigo() == "PROSTADA_1")
                        {
                            DuracaoProstata += atendimento.GetProcedimento().GetDuracao();
                        }
                        else
                        {
                            DuracacoTomografia += atendimento.GetProcedimento().GetDuracao();
                        }
                    }
                    tempoTotal += atendimento.GetProcedimento().GetDuracao();
                    Console.WriteLine("Período: " + DataInicio.ToString("dd/MM/yyyy") + " à " + DataFim.ToString("dd/MM/yyyy") + ":");
                    Console.WriteLine("Duração do Raios – X de Tórax em PA: " + DuracaoRaio);
                    Console.WriteLine("Duração do Ultrassonografia Obstétrica: " + DuracaoObtetrica);
                    Console.WriteLine("Duração do Ultrassonografia de Próstata: " + DuracaoProstata);
                    Console.WriteLine("Duração do Tomografia: " + DuracacoTomografia);
                    Console.WriteLine("A Duração de Procedimentos realizados no período de " + DataInicio.ToString("dd/MM/yyyy") + " à " + DataFim.ToString("dd/MM/yyyy") + " foi " + tempoTotal);
                }
                Console.WriteLine();
            }      
        }

        // Método validaProcedimento válida se o Paciente pode ou não agendar o atendimento, com base nas exigencias de cada procedimendo
        public static bool validaProcedimento(DateTime data, Procedimentos procedimento, Paciente paciente)
        {
            if(procedimento.GetCodigo() == "RAIO_X124")
            {
                return true;
            }
            else if(procedimento.GetCodigo() == "OBTETRICA_" && paciente.GetSexo() == 'F' && paciente.GetIdade() < 60)
            {
                return true;
            }
            else if(procedimento.GetCodigo() == "PROSTADA_1" && paciente.GetSexo() == 'M')
            {
                return true;
            }
            else if(procedimento.GetCodigo() == "TOMOGRA_12" && !GerenciarAtendimento.VerificarAtendimento(data,paciente, "OBTETRICA_", "PROSTADA_1"))
            {
                // O método GerenciarAtendimento.VerificarAtendimento() verifica se o Paciente realizou o procedimento de Tomografia ou Prostata nos ultimos 3 messes
                return true;
            }
            return false;
        }        
    }
}
