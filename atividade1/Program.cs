

using System;
using System.Collections.Generic;
using System.Linq;
using atividade1;


namespace AppGerenciamento
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Bem vindo ao sistema");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            List<Paciente> pacientes = new List<Paciente>();
            List<string> procedimentos = new List<string>() { "1.Clareamento dental", "2.Tratamento ortodôntico","3.Implante","4.Extração","5.Enxerto gengival","6.Restauração","7.Canal" };
            while (true) {
                Console.WriteLine("Escolha uma das ações a seguir:");
                Console.WriteLine();
                Console.WriteLine("1-Cadastro de pacientes.");
                Console.WriteLine("2-Pesquisar por paciente.");
                Console.WriteLine("3-Cadastro de procedimentos.");
                Console.WriteLine("4-Realizar um atendimento.");
                Console.WriteLine("5-Sair do sistema.");

                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.WriteLine("Digite o nome do paciente: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite o cpf do paciente: ");
                    string cpf = Console.ReadLine();
                    pacientes.Add(new Paciente(nome, cpf, new List<string>()));
                    Console.WriteLine("Paciente adicionado com sucesso.");
                }
                else if (opcao == "2")
                {
                    Console.WriteLine("Digite o cpf do paciente: ");
                    string cpf = Console.ReadLine();
                    Console.WriteLine(BuscarPaciente(pacientes, cpf));
                } else if (opcao == "3")
                {
                    Console.WriteLine("Procedimentos já cadastrados no sistema");
                    foreach (var p in procedimentos)
                    {
                        Console.WriteLine(p);
                    }
                    Console.WriteLine("Digite o nome do procedimento: ");
                    string procedimento = Console.ReadLine();
                    procedimentos.Add((procedimentos.Count+1) + "." + procedimento);

                } else if(opcao == "4") 
                {
                    Console.WriteLine("Digite o cpf do paciente o qual você deseja adicionar um procedimento: ");
                    string cpf = Console.ReadLine();
                    Console.WriteLine("Escolha um código dos procedimentos a seguir que você deseja adicionar a esse paciente: ");
                    foreach (var p in procedimentos)
                    {
                        Console.WriteLine(p);
                    }
                    int indiceProcedimento = int.Parse(Console.ReadLine());
                    AdicionarProcPac(pacientes, cpf, procedimentos[indiceProcedimento - 1]);
                    Console.WriteLine("Segue abaixo a ficha do paciente: ");
                    Console.WriteLine(BuscarPaciente(pacientes, cpf));
                } else if (opcao == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Digite uma opção válida!");
                }

            }
        }

         private static string BuscarPaciente(List<Paciente> pacientes,  string cpf)
        {
            string message;
            if (pacientes.Count == 0)
            {
                message = "A lista de pacientes está vazia.";
            }
            else
            {
                Paciente result = pacientes.FirstOrDefault(p => p.CPF == cpf);
                message = "Paciente: " + result.Nome + ", CPF: " + result.CPF + ", Atendimentos: " + String.Join(", ", result.Procedimentos.ToArray());
            }
            return message;
        }

        private static void AdicionarProcPac(List<Paciente> pacientes, string cpf, string procedimento)
        {
            Paciente result = pacientes.FirstOrDefault(p => p.CPF == cpf);
            result.Procedimentos.Add(procedimento);
        }
    }
}