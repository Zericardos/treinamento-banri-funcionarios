// 1. Transformando o cliente em um frontend

using System;

namespace Cliente
{
    public class Program
    {
        private const string PROTOCOLO = "http";
        private const string DOMINIO = "localhost";
        private const int PORTA = 3090;

        public static void Main(string[] args)
        {
            var cliente = new ClienteHttp();

            Console.WriteLine("::::::::::::::::::");
            Console.WriteLine($":::: {ClienteHttp.IDENTIFICADOR} :::::");
            Console.WriteLine("::::::::::::::::::");

            Console.WriteLine();

            while (true)
            {
                ExibirOpcoes();

                var opcao = ObterOpcao();

                if (opcao == "S")
                    break;

                Console.WriteLine();

                var resposta = ExecutarOpcao(cliente, opcao);

                if (!string.IsNullOrWhiteSpace(resposta))
                {
                    Console.WriteLine($"Resposta: {resposta}");

                    Console.WriteLine();
                }
            }

            cliente.Encerrar();

            Console.ReadKey();
        }

        private static void ExibirOpcoes()
        {
            Console.WriteLine("1 - GET");
            Console.WriteLine("2 - POST");
            Console.WriteLine("3 - PUT");
            Console.WriteLine("4 - DELETE");
            Console.WriteLine("S - Sair");
        }

        private static string ObterOpcao()
        {
            Console.Write("Selecione a ação: ");

            return Console.ReadLine().Trim().ToUpper();
        }

        private static string ExecutarOpcao(ClienteHttp cliente, string opcao)
        {
            var caminho = ObterCaminho();

            switch (opcao)
            {
                case "1":
                    return cliente.EnviarGet(caminho);

                case "2":
                    return cliente.EnviarPost(caminho, SolicitarMensagem());

                case "3":
                    return cliente.EnviarPut(caminho, SolicitarMensagem());

                case "4":
                    return cliente.EnviarDelete(caminho);

                default:
                    Console.WriteLine("Opção inválida.");

                    Console.WriteLine();
                    
                    return null;
            }
        }

        private static string ObterCaminho()
        {
            return $"{PROTOCOLO}://{DOMINIO}:{PORTA}/";
        }

        private static string SolicitarMensagem()
        {
            Console.Write("Digite a mensagem a ser enviada na requisição: ");

            var mensagem = Console.ReadLine().Trim();

            Console.WriteLine();

            return mensagem;
        }
    }
}
