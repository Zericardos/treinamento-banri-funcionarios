using System;
using System.Data;
using System.Globalization;
using System.Text;

namespace Bergs.Pxc.Pxcbtoxn
{
    /// <summary>
    /// Ferramenta de conversão de códigos de idiomas
    /// </summary>
    public static class Feconid
    {
        private const int B_27 = 27;

        /// <summary>
        /// Método para converter código ISO combinado para código numérico
        /// </summary>
        /// <param name="iso">Código ISO combinado</param>
        /// <returns>Código numérico</returns>
        public static int IsoToCodigo(string iso)
        {
            if (string.IsNullOrEmpty(iso))
                throw new ArgumentException("código combinado ISO não pode ser nulo ou vazio.");

            var parts = iso.Split('-');
            if (parts.Length != 2)
                throw new ArgumentException("Formato inválido do código combinado ISO. Deve ser 'll-PP' ou 'lll-PP'.");

            string idioma = parts[0].ToLower();
            string pais = parts[1].ToUpper();

            if (idioma.Length < 2 || idioma.Length > 3)
                throw new ArgumentException("Idioma deve ter 2 a 3 caracteres.");

            if (pais.Length != 2)
                throw new ArgumentException("País deve ter 2 caracteres.");

            int idiomaLength = idioma.Length;

            int codigo = idiomaLength;

            foreach (var caractere in idioma)
                codigo = codigo * B_27 + CaractereToNumero(caractere);

            foreach (var ch in pais)
                codigo = codigo * B_27 + CaractereToNumero(ch);

            return codigo;
        }

        /// <summary>
        /// Método para converter código numérico p0ara código ISO combinado
        /// </summary>
        /// <param name="codigo">Código numérico</param>
        /// <returns>Código ISO combinado</returns>
        public static string CodigoToIso(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Código numérico inválido.");

            var iso = new StringBuilder();

            while (codigo > 0)
            {
                int remainder = codigo % B_27;

                iso.Insert(0, NumeroToCaractere(remainder));

                codigo = codigo / B_27;
            }

            if (iso.Length < 3)
                throw new Exception("Número inválido de caracteres para conversão.");

            int idiomaLength = CaractereToNumero(iso[0]);
            if (idiomaLength < 2 || idiomaLength > 3)
                throw new ArgumentException("Idioma deve ter 2 a 3 caracteres.");

            string idioma = iso.ToString(1, idiomaLength).ToLower();

            string pais = iso.ToString(1 + idiomaLength, iso.Length - 1 - idiomaLength).ToUpper();

            return $"{idioma}-{pais}";
        }

        private static int CaractereToNumero(char caractere)
        {
            caractere = char.ToUpper(caractere);

            if (caractere < 'A' || caractere > 'Z')
                throw new ArgumentException($"Caractere {caractere} inválido.");

            return caractere - 'A' + 1;
        }

        private static char NumeroToCaractere(int numero)
        {
            if (numero < 1 || numero > 26)
                throw new ArgumentException($"Número {numero} inválido.");

            return (char)('A' + numero - 1);
        }
    }

    /// <summary>
    /// Utilitários para objetos BD da camada Q
    /// </summary>
    public static class BDUtils
    {
        /// <summary>
        /// Constante contendo a cláusula a ser chamada quando se quer uma atribuição de data e hora atuais em um campo dentro do contexto da base de dados
        /// </summary>
        public const string BD_CURRENT_TIMESTAMP = "CURRENT_TIMESTAMP";

        /// <summary>
        /// Método para checar se uma propriedade tem configuração de parâmetros equivalentes a de um valor numérico com casas decimais
        /// </summary>
        /// <param name="tipo">Tipo de parâmetro</param>
        /// <param name="casasDecimais">Número de casas decimais do parâmetro</param>
        /// <returns></returns>
        public static bool IsParametroPontoFlutuante(DbType tipo, byte casasDecimais)
        {
            if (tipo == DbType.DateTime)
                return false;

            return casasDecimais > 0;
        }

        /// <summary>
        /// Método para converter propriedades numéricas com casas decimais para parâmetros compatíveis da base de dados
        /// </summary>
        /// <returns></returns>
        public static string FormatarParametroPontoFlutuante(object conteudo, byte casasDecimais)
        {
            return string.Format(CultureInfo.InvariantCulture, $"{{0:F{casasDecimais}}}", conteudo);
        }
    }
}
