// 1. Preparando hook do servidor para trabalhar com `GET`, `POST`, `PUT` e `DELETE`

using PseudoFramework.ServidorUtils;
using PseudoFramework.SharedUtils;
using System;
using System.Linq;

namespace Servidor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var servidor = new ServidorHttp(ConectorHttp.ObterCaminho());

            Console.WriteLine(":::::::::::::::::");
            Console.WriteLine($":::: {ServidorHttp.IDENTIFICADOR} :::");
            Console.WriteLine(":::::::::::::::::\n");

            Console.WriteLine("Pressione ENTER para encerrar...\n");

            servidor.ProcessarHook =
                (verbo, caminho, json) => InterceptarRequisicao(verbo, caminho, json);

            servidor.Iniciar();

            Console.ReadKey();

            servidor.Encerrar();

            Console.ReadKey();
        }

        private static Saudacao InterceptarRequisicao(string verboHttp, string caminho, string json)
        {
            switch (verboHttp)
            {
                case "GET":
                    return InterceptarGet();

                case "POST":
                    return InterceptarPost(json);

                case "PUT":
                    return InterceptarPut(json);

                case "DELETE":
                    return InterceptarDelete();

                default:
                    return null;
            }
        }

        private static Saudacao InterceptarGet()
        {
            var saudacaoServidor = new Saudacao()
            {
                Cumprimento = "Olá",
                NumeroCumprimentos = 1,
                PronomeTratamento = "Sr.",
                Nome = "Cliente",
            };

            return saudacaoServidor;
        }

        private static Saudacao InterceptarPost(string json)
        {
            var saudacaoCliente = ConversorJson.Desserializar<Saudacao>(json);

            string cumprimentos = string.Concat(Enumerable.Repeat(saudacaoCliente.Cumprimento + " ", saudacaoCliente.NumeroCumprimentos));

            string saudacaoClienteExpressao = $"{cumprimentos}{saudacaoCliente.PronomeTratamento} {saudacaoCliente.Nome}!";

            Console.WriteLine($"\n\n{saudacaoClienteExpressao} \n");

            var saudacaoServidor = new Saudacao()
            {
                Cumprimento = "Olá",
                NumeroCumprimentos = 1,
                PronomeTratamento = "Sr.",
                Nome = "Cliente",
            };

            return saudacaoServidor;
        }

        private static Saudacao InterceptarPut(string json)
        {
            var saudacaoCliente = ConversorJson.Desserializar<Saudacao>(json);

            string cumprimentos = string.Concat(Enumerable.Repeat(saudacaoCliente.Cumprimento + " ", saudacaoCliente.NumeroCumprimentos));

            string saudacaoClienteExpressao = $"{cumprimentos}{saudacaoCliente.PronomeTratamento} {saudacaoCliente.Nome}!";

            Console.WriteLine($"\n\n{saudacaoClienteExpressao} \n");

            var saudacaoServidor = new Saudacao()
            {
                Cumprimento = "Olá",
                NumeroCumprimentos = 1,
                PronomeTratamento = "Sr.",
                Nome = "Cliente",
            };

            return saudacaoServidor;
        }

        private static Saudacao InterceptarDelete()
        {
            var saudacaoServidor = new Saudacao()
            {
                Cumprimento = "Olá",
                NumeroCumprimentos = 1,
                PronomeTratamento = "Sr.",
                Nome = "Cliente",
            };

            return saudacaoServidor;
        }
    }
}
