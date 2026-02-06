using System;
using System.Threading;

namespace Cliente
{
    public class Program
    {
        private const string PROTOCOLO = "http";
        private const string DOMINIO = "localhost";
        private const int PORTA = 3090;

        public static void Main(string[] args)
        {
            Console.WriteLine("::::::::::::::::::");
            Console.WriteLine($":::: {ClienteHttp.IDENTIFICADOR} :::::");
            Console.WriteLine("::::::::::::::::::\n");

            Console.WriteLine("Pressione ENTER para encerrar...\n");

            // TODO: Uso do objeto ClienteHttp para efetuar requisições para o servidor

            Console.ReadKey();

            // TODO: [Instância de ClienteHttp].Encerrar();

            Console.ReadKey();
        }

        private static string ObterCaminho()
        {
            return $"{PROTOCOLO}://{DOMINIO}:{PORTA}/";
        }
    }
}
