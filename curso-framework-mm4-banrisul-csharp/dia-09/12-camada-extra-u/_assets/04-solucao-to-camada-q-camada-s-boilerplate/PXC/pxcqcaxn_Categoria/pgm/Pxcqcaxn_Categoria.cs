using Bergs.Pwx.Pwxodaxn;
using Bergs.Pwx.Pwxodaxn.Excecoes;
using Bergs.Pwx.Pwxoiexn;
using Bergs.Pwx.Pwxoiexn.BD;
using Bergs.Pwx.Pwxoiexn.Mensagens;
using Bergs.Pxc.Pxcbtoxn;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bergs.Pxc.Pxcqcaxn
{
    /// <summary>
    /// Classe que possui os métodos de manipulação de dados da tabela CATEGORIA da base de dados PXC
    /// </summary>
    public class Categoria: AplicacaoDados
    {
        private static readonly string Alias = string.Empty;

        /// <summary>
        /// Método alterar referente à tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<int> Alterar(TOCategoria toCategoria)
        {
            try
            {
                ResetarControlesComando();

                Sql.Comando.Append($"UPDATE {TOCategoria.TABELA}");

                Sql.MontarCampoSet(TOCategoria.CODIGO_USUARIO, toCategoria.CodOperador);
                Sql.MontarCampoSet(TOCategoria.DESCRICAO_CATEGORIA, toCategoria.Descricao);

                Sql.MontarCampoSet(TOCategoria.DATA_HORA_ULTIMA_ALTERACAO); // SAC - Refresh para um novo token
                Sql.Comando.Append(BDUtils.BD_CURRENT_TIMESTAMP);

                Sql.MontarCampoWhere(TOCategoria.CODIGO_CATEGORIA, toCategoria.CodCategoria);

                Sql.MontarCampoWhere(TOCategoria.DATA_HORA_ULTIMA_ALTERACAO, toCategoria.UltAtualizacao); // SAC - Uso do token atual

                var registrosAfetados = AlterarDados();

                if (registrosAfetados == 0)
                    return Infra.RetornarFalha<int>(new ConcorrenciaMensagem());

                return Infra.RetornarSucesso(registrosAfetados);
            }
            catch (ChaveEstrangeiraInexistenteException exception)
            {
                return Infra.RetornarFalha<int>(new ChaveEstrangeiraInexistenteMensagem(exception));
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<int>(exception);
            }
        }

        /// <summary>
        /// Método contar referente à tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<long> Contar(TOCategoria toCategoria)
        {
            try
            {
                ResetarControlesComando();

                Sql.Comando.Append($"SELECT COUNT(*) FROM {QualificarTabela(TOCategoria.TABELA)}");

                /*
                 * Só vão ser agregados ao comando os campos abaixo do TO que estiverem em estados
                 * SETADO COM CONTEÚDO ou SETADO SEM CONTEÚDO
                 * - Lembrando dos estados possíveis: SETADO COM CONTEÚDO, NÃO SETADO e 
                 * SETADO SEM CONTEÚDO (exclusivo para campos CampoOpcional<T>)
                */
                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.CODIGO_CATEGORIA) , toCategoria.CodCategoria);
                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.DESCRICAO_CATEGORIA) ,toCategoria.Descricao);
                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.CODIGO_USUARIO) , toCategoria.CodOperador);
                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.DATA_HORA_ULTIMA_ALTERACAO) , toCategoria.UltAtualizacao);

                var quantidadeRegistros = ContarDados();

                return Infra.RetornarSucesso(quantidadeRegistros);
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<long>(exception);
            }
        }

        /// <summary>
        /// Método excluir referente à tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<int> Excluir(TOCategoria toCategoria)
        {
            try
            {
                ResetarControlesComando();

                Sql.Comando.Append($"DELETE FROM {TOCategoria.TABELA}");

                Sql.MontarCampoWhere(TOCategoria.CODIGO_CATEGORIA, toCategoria.CodCategoria);

                Sql.MontarCampoWhere(TOCategoria.DATA_HORA_ULTIMA_ALTERACAO, toCategoria.UltAtualizacao); // SAC - Uso do token atual

                var registrosAfetados = ExcluirDados();

                if (registrosAfetados == 0)
                    return Infra.RetornarFalha<int>(new ConcorrenciaMensagem());

                return Infra.RetornarSucesso(registrosAfetados);
            }
            catch (ChaveEstrangeiraReferenciadaException exception)
            {
                return Infra.RetornarFalha<int>(new ChaveEstrangeiraReferenciadaMensagem(exception));
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<int>(exception);
            }
        }

        /// <summary>
        /// Método incluir referente à tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<int> Incluir(TOCategoria toCategoria)
        {
            try
            {
                ResetarControlesComando();

                Sql.Comando.Append($"INSERT INTO {TOCategoria.TABELA} (");

                Sql.MontarCampoInsert(TOCategoria.CODIGO_CATEGORIA, toCategoria.CodCategoria);
                Sql.MontarCampoInsert(TOCategoria.DESCRICAO_CATEGORIA, toCategoria.Descricao);
                Sql.MontarCampoInsert(TOCategoria.CODIGO_USUARIO, toCategoria.CodOperador);
                
                Sql.MontarCampoInsert(TOCategoria.DATA_HORA_ULTIMA_ALTERACAO); // SAC - Inicialização do token
                Sql.Temporario.Append(BDUtils.BD_CURRENT_TIMESTAMP);

                Sql.Comando.Append(") VALUES (");
                Sql.Comando.Append(Sql.Temporario);
                Sql.Comando.Append(")");

                var registrosAfetados = IncluirDados();

                return Infra.RetornarSucesso(registrosAfetados);
            }
            catch (RegistroDuplicadoException exception)
            {
                return Infra.RetornarFalha<int>(new RegistroDuplicadoMensagem(exception));
            }
            catch (ChaveEstrangeiraInexistenteException exception)
            {
                return Infra.RetornarFalha<int>(new ChaveEstrangeiraInexistenteMensagem(exception));
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<int>(exception);
            }
        }

        /// <summary>
        /// Método listar referente à tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <param name="toPaginacao">Classe da infra-estrutura contendo as informações de paginação</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<List<TOCategoria>> Listar(TOCategoria toCategoria, TOPaginacao toPaginacao)
        {
            try
            {
                ResetarControlesComando();

                Sql.Comando.Append($"SELECT * FROM {QualificarTabela(TOCategoria.TABELA)}");

                /*
                 * Só vão ser agregados ao comando os campos abaixo do TO que estiverem em estados
                 * SETADO COM CONTEÚDO ou SETADO SEM CONTEÚDO
                 * - Lembrando dos estados possíveis: SETADO COM CONTEÚDO, NÃO SETADO e 
                 * SETADO SEM CONTEÚDO (exclusivo para campos CampoOpcional<T>)
                */
                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.CODIGO_CATEGORIA), toCategoria.CodCategoria);
                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.DESCRICAO_CATEGORIA), toCategoria.Descricao);
                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.CODIGO_USUARIO), toCategoria.CodOperador);
                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.DATA_HORA_ULTIMA_ALTERACAO), toCategoria.UltAtualizacao);

                var listaTOs = toPaginacao != null
                    ? ListarPaginaTOsCategoria(toPaginacao)
                    : ListarTodosTOsCategoria();

                return Infra.RetornarSucesso(listaTOs);
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<List<TOCategoria>>(exception);
            }
        }

        /// <summary>
        /// Método obter referente à tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<TOCategoria> Obter(TOCategoria toCategoria)
        {
            try
            {
                ResetarControlesComando();

                Sql.Comando.Append($"SELECT * FROM {QualificarTabela(TOCategoria.TABELA)}");

                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.CODIGO_CATEGORIA), toCategoria.CodCategoria);
                Sql.MontarCampoWhere(QualificarCampo(TOCategoria.DESCRICAO_CATEGORIA), toCategoria.Descricao);

                var registro = ObterDados();

                if (registro == null)
                    return Infra.RetornarFalha<TOCategoria>(new RegistroInexistenteMensagem());

                var toCategoriaConsultado = GerarTOCategoria(registro);

                return Infra.RetornarSucesso(toCategoriaConsultado);
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<TOCategoria>(exception);
            }
        }

        /// <summary>
        /// Método responsável por definir a relação entre o campo do TO e o parâmetro SQL correspondente
        /// </summary>
        /// <param name="nomeCampo">Nome do campo a ser parametrizado</param>
        /// <param name="conteudo">Conteúdo na propriedade do TO respectiva ao campo a ser parametrizado</param>
        /// <returns>Parâmetro recém-criado</returns>
        protected override Parametro CriarParametro(String nomeCampo, Object conteudo)
        {
            Parametro parametro = new Parametro();

            switch (nomeCampo)
            {
                case TOCategoria.CODIGO_CATEGORIA:
                    {
                        parametro.DbType = DbType.Int32;
                        parametro.Size = 8;
                        parametro.Precision = 8;

                        break;
                    }
                case TOCategoria.DESCRICAO_CATEGORIA:
                    {
                        parametro.DbType = DbType.String;
                        parametro.Size = 35;
                        parametro.Precision = 35;

                        break;
                    }
                case TOCategoria.CODIGO_USUARIO:
                    {
                        parametro.DbType = DbType.String;
                        parametro.Size = 6;
                        parametro.Precision = 6;

                        break;
                    }
                case TOCategoria.DATA_HORA_ULTIMA_ALTERACAO:
                    {
                        parametro.DbType = DbType.DateTime;
                        parametro.Size = 10;
                        parametro.Precision = 10;
                        parametro.Scale = 6;

                        break;
                    }
                default:
                    {
#if DEBUG // Diretiva de compilação condicional - Só vai constar na aplicação quando rodando em modo debug
                        parametro = null; // Força um erro para alertar o desenvolvedor, pois todo parâmetro deve ser tratado no switch
#endif
                        break;
                    }
            }

            parametro.Direction = ParameterDirection.Input;

            parametro.SourceColumn = nomeCampo;

            if (BDUtils.IsParametroPontoFlutuante(parametro.DbType, parametro.Scale) && conteudo != null)
                parametro.Value = BDUtils.FormatarParametroPontoFlutuante(conteudo, parametro.Scale);
            else
                parametro.Value = conteudo;

            return parametro;
        }

        /// <summary>
        /// Auxiliar que reseta/limpa os controles utilizados para a montagem dos comandos (operação de segurança)
        /// </summary>
        private void ResetarControlesComando()
        {
            Sql.Comando.Clear();

            Sql.Temporario.Clear();

            Parametros.Clear();
        }

        /// <summary>
        /// Auxiliar que controla a inserção ou não do alias SQL nos nomes de tabelas durante a montagem dos comandos
        /// </summary>
        /// <returns>Nome qualificado da tabela</returns>
        private string QualificarTabela(string nomeTabela)
        {
            return !string.IsNullOrWhiteSpace(Alias)
                ? $"{nomeTabela} {Alias}"
                : nomeTabela;
        }

        /// <summary>
        /// Auxiliar que controla a inserção ou não do alias SQL nos nomes de campo durante a montagem dos comandos
        /// </summary>
        /// <param name="nomeCampo">Nome do campo a ser qualificado</param>
        /// <returns>Nome qualificado do campo</returns>
        private string QualificarCampo(string nomeCampo)
        {
            return !string.IsNullOrWhiteSpace(Alias)
                ? $"{Alias}.{nomeCampo}"
                : nomeCampo;
        }

        /// <summary>
        /// Auxiliar que faz a listagem completa de TOs
        /// </summary>
        /// <returns>Lista completa de TOs de categoria</returns>
        private List<TOCategoria> ListarTodosTOsCategoria()
        {
            var listaCompletaTOs = new List<TOCategoria>();

            using (var listaConectada = ListarDados())
            {
                while (listaConectada.Ler())
                {
                    var toRetorno = GerarTOCategoria(listaConectada.LinhaAtual);

                    listaCompletaTOs.Add(toRetorno);
                }
            }

            return listaCompletaTOs;
        }

        /// <summary>
        /// Auxiliar que faz a listagem de TOs com base no objeto de paginação
        /// </summary>
        /// <param name="toPaginacao">Objeto com as configurações da página a ser listada</param>
        /// <returns>Lista de TOs de categoria com base na página selecionada</returns>
        private List<TOCategoria> ListarPaginaTOsCategoria(TOPaginacao toPaginacao)
        {
            var paginaTOs = new List<TOCategoria>();

            var listaDesconectada = ListarDados(toPaginacao);

            foreach (var linhaAtual in listaDesconectada.Linhas)
            {
                var toRetorno = GerarTOCategoria(linhaAtual);

                paginaTOs.Add(toRetorno);
            }

            return paginaTOs;
        }

        /// <summary>
        /// Auxiliar que efetua a criação de um novo TO de categorias com base em um registro oriundo da base de dados
        /// </summary>
        /// <param name="registro"></param>
        /// <returns>Instância de TOCategoria</returns>
        private TOCategoria GerarTOCategoria(Linha registro)
        {
            var toCategoria = new TOCategoria();

            toCategoria.PopularRetorno(registro);

            return toCategoria;
        }
    }
}
