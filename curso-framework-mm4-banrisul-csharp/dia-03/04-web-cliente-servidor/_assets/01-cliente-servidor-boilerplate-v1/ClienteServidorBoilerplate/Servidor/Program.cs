using System;

namespace Servidor
{
    public class Program
    {
        private const string PROTOCOLO = "http";
        private const string DOMINIO = "localhost";
        private const int PORTA = 3090;

        public static void Main(string[] args)
        {
            Console.WriteLine(":::::::::::::::::");
            Console.WriteLine($":::: {ServidorHttp.IDENTIFICADOR} :::");
            Console.WriteLine(":::::::::::::::::\n");

            Console.WriteLine("Pressione ENTER para encerrar...\n");

            // TODO: Uso do objeto ServidorHttp para disponibilizar o servidor para recepção de requisições de clientes

            Console.ReadKey();

            // TODO: [Instância de ServidorHttp].Encerrar();

            Console.ReadKey();
        }

        private static string ObterCaminho()
        {
            return $"{PROTOCOLO}://{DOMINIO}:{PORTA}/";
        }
    }
}
