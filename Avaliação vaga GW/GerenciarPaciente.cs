
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação_vaga_GW
{   
     static class GerenciarPaciente
    {
        public static List<Paciente> ListPaciente = new List<Paciente>();
        public static void menu()
        {
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Cadastrar Paciente");
            Console.WriteLine("2 - Listar Paciente");
            Console.WriteLine("3 - Sair");
            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Opção inválida!");
                return;
            }

            switch (opcaoPaciente)
            {
                case 1:
                    CadastrarCliente();
                    break;
                case 2:
                    Buscar();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        }

        public static void CadastrarCliente()
        {
            Console.WriteLine("Digite o nome: *");
            string nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido!");
                return;
            }
            Console.WriteLine("Digite o nome da mãe: ");
            string nomeMae = Console.ReadLine();
            Console.WriteLine("Digite a data de Nascimento: *");
            
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataNascimento))
            {
                Console.WriteLine("Data de Nascimento inválida!");
                return;
            }
            if (DateTime.Now.Year - dataNascimento.Year < 12)
            {
                Console.WriteLine("A clínica só atende pacientes acima de 12 anos");
                return;
            }
            Console.WriteLine("Digite o Sexo: M/F: *");
            if (!char.TryParse(Console.ReadLine(), out char sexo) || (sexo != 'M' && sexo != 'F'))
            {
                Console.WriteLine("Sexo inválido!");
                return;
            }
            Console.WriteLine("Digite o CPF: *");
            
            if (!int.TryParse(Console.ReadLine(), out int cpf) || cpf.ToString().Length != 11)
            {
                Console.WriteLine("CPF inválido!");
                return;
            }

            if(Buscar(cpf.ToString())!=null) // Realiza a busca na Lista de Paciente pelo CPF
            {
                Console.WriteLine("Paciente já cadastrado");
                return;
            }

            Paciente paciente = new Paciente(nome,nomeMae,dataNascimento,sexo,cpf);
            ListPaciente.Add(paciente);
            Console.WriteLine("Paciente cadastrado com sucesso!");
        }

        public static void Buscar()
        {
            Console.WriteLine("Pacientes Cadastrados: ");
            Console.WriteLine();
            foreach(Paciente paciente in ListPaciente)
            {
                Console.Write("Nome: " + paciente.GetNome());
                Console.Write(" Data de Nascimento: " + paciente.GetData().ToString("dd/MM/yyyy"));
                Console.WriteLine("\n");
            }
        }

        public static Paciente Buscar(String procura)
        {

                foreach (Paciente paciente in ListPaciente)
                {
                    if (paciente.GetNome() == procura || paciente.GetCPF() == Convert.ToInt32(procura) || paciente.GetData().ToString("dd/MM/yyyy") == procura)
                    {
                        return paciente;
                    }
                }
                return null;
            }
        }
    }

