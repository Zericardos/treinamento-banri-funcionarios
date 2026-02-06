using PseudoFramework.ServidorUtils;
using PseudoFramework.SharedUtils;
using System;

namespace Servidor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(":::::::::::::::::");
            Console.WriteLine($":::: {ServidorHttp.IDENTIFICADOR} :::");
            Console.WriteLine(":::::::::::::::::\n");

            Console.WriteLine("Pressione ENTER para encerrar...\n");
            
            var servidor = new ServidorHttp(ConectorHttp.ObterCaminho());

            // TODO: Implementar hook de POST

            servidor.Iniciar();

            Console.ReadKey();

            servidor.Encerrar();

            Console.ReadKey();
        }
    }
}
