using PseudoFramework.ClienteUtils;
using System;
using System.Threading;

namespace Cliente
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("::::::::::::::::::");
            Console.WriteLine($":::: {ClienteHttp.IDENTIFICADOR} :::::");
            Console.WriteLine("::::::::::::::::::\n");

            Console.WriteLine("Pressione ENTER para encerrar...\n");

            var cliente = new ClienteHttp();

            // TODO: Implementar um POST

            Console.ReadKey();

            cliente.Encerrar();

            Console.ReadKey();
        }
    }
}
