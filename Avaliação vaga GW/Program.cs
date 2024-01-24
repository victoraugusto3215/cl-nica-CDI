using System;

namespace Avaliação_vaga_GW
{
    class Program
    {
        static void Main(string[] args)
        {
            // Os procedimentos são inicializados com valores predefinidos para o bom funcionamento do sistema.
            // Embora a criação dinâmica não tenha sido solicitada, essa funcionalidade foi adicionada no GerenciarProcemento
       
            Procedimentos raioX = new Procedimentos("Raios – X de Tórax em PA", TimeSpan.FromHours(1.5), "RAIO_X124");
            Procedimentos Obstétrica = new Procedimentos("Ultrassonografia Obstétrica", TimeSpan.FromHours(2.5), "OBTETRICA_");
            Procedimentos Prostata = new Procedimentos("Ultrassonografia de Próstata", TimeSpan.FromMinutes(0.20), "PROSTADA_1");
            Procedimentos Tomografia = new Procedimentos("Tomografia", TimeSpan.FromHours(1.5), "TOMOGRA_12");
            GerenciarProcedimento.ListProcedimentos.Add(raioX);
            GerenciarProcedimento.ListProcedimentos.Add(Obstétrica);
            GerenciarProcedimento.ListProcedimentos.Add(Prostata);
            GerenciarProcedimento.ListProcedimentos.Add(Tomografia);

            // Um menu foi projetado com opções que redirecionam para submenus,
            // proporcionando facilidade, praticidade e possiveis confusões ao usuário.
            int opcao = 0;
            do
            {
                Console.WriteLine("Clinica CDI");
                Console.WriteLine("Digite a opção desejada");
                Console.WriteLine("1 - Paciente");
                Console.WriteLine("2 - Atendimento");
                Console.WriteLine("3 - Procedimento");
                Console.WriteLine("4 - Sair");
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                // Redireciona para os smenus com base na opção escolhida
                // Foi criados classes estaticas para o gerenciamento de cada funcionaliadade
                switch (opcao)
                {
                    case 1:
                        GerenciarPaciente.menu();
                        break;

                    case 2:
                        GerenciarAtendimento.menu();
                        break;
                    case 3:
                        GerenciarProcedimento.menu();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            } while (opcao != 4);
        }
    }
}
