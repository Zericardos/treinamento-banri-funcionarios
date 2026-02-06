using Bergs.Pwx.Pwxoiexn;
using Bergs.Pwx.Pwxoiexn.Mensagens;
using Bergs.Pwx.Pwxoiexn.Relatorios;
using Bergs.Pwx.Pwxoiexn.RN;
using Bergs.Pxc.Pxcbtoxn;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bergs.Pxc.Pxcscaxn
{
    /// <summary>Classe que possui as regras de negócio para o acesso da tabela CATEGORIA da base de dados PXC.</summary>
    public class Categoria: AplicacaoRegraNegocio
    {
        /// <summary>
        /// Altera registro da tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<int> Alterar(TOCategoria toCategoria) // US3 - Alteração de dados de categoria
        {
            try
            {
                if (!toCategoria.CodCategoria.FoiSetado)
                    return Infra.RetornarFalha<int>(new CategoriaMensagem(TipoCategoriaMensagem.FalhaRnValidarExistenciaCod));

                if (!toCategoria.Descricao.FoiSetado)
                    return Infra.RetornarFalha<int>(new CategoriaMensagem(TipoCategoriaMensagem.FalhaRnValidarExistenciaDescricao));

                if (!ValidarTO(toCategoria, out var listaRetornoValidacao))
                    return Infra.RetornarFalha<int>(new ObjetoInvalidoMensagem(listaRetornoValidacao));

                /*
                 * Isola o TO de filtragem da obtenção para evitar qualquer tipo de colisão com as propostas 
                 * de alteração contidas no TO principal
                */
                var resultadoConsulta = Obter(new TOCategoria() { CodCategoria = toCategoria.CodCategoria });

                if (!resultadoConsulta.OK)
                    return Infra.RetornarFalha<int>(new CategoriaMensagem(TipoCategoriaMensagem.FalhaRnConsultarCategoriaBaseDados, resultadoConsulta.Mensagem.ParaUsuario));

                toCategoria.UltAtualizacao = resultadoConsulta.Dados.UltAtualizacao; // Pega o token de atualização para SAC
                toCategoria.CodOperador = Infra.Usuario.Matricula;

                var bdCategoria = Infra.InstanciarBD<Pxcqcaxn.Categoria>();

                using (EscopoTransacional escopo = Infra.CriarEscopoTransacional())
                {
                    var resultado = bdCategoria.Alterar(toCategoria);

                    if (!resultado.OK)
                        return resultado;

                    escopo.EfetivarTransacao();

                    return Infra.RetornarSucesso(resultado.Dados, new OperacaoRealizadaMensagem("Alteração"));
                }
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<int>(exception);
            }
        }

        /// <summary>
        /// Conta quantidade de registros da tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<long> Contar(TOCategoria toCategoria) // Extra (sem US vinculada)
        {
            try
            {
                var bdCategoria = Infra.InstanciarBD<Pxcqcaxn.Categoria>();

                var resultado = bdCategoria.Contar(toCategoria);

                if (!resultado.OK)
                    return resultado;

                return Infra.RetornarSucesso(resultado.Dados, new OperacaoRealizadaMensagem());
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<long>(exception);
            }
        }

        /// <summary>
        /// Exclui registro da tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<int> Excluir(TOCategoria toCategoria) // US2 - Remoção de categoria
        {
            try
            {
                if (!toCategoria.CodCategoria.FoiSetado)
                    return Infra.RetornarFalha<int>(new CategoriaMensagem(TipoCategoriaMensagem.FalhaRnValidarExistenciaCod));

                if (!ValidarTO(toCategoria, out var listaRetornoValidacao))
                    return Infra.RetornarFalha<int>(new ObjetoInvalidoMensagem(listaRetornoValidacao));

                /*
                 * Isola o TO de filtragem da obtenção para evitar qualquer tipo de colisão com os dados 
                 * de exclusão contidos no TO principal
                */
                var resultadoConsulta = Obter(new TOCategoria() { CodCategoria = toCategoria.CodCategoria });

                if (!resultadoConsulta.OK)
                    return Infra.RetornarFalha<int>(new CategoriaMensagem(TipoCategoriaMensagem.FalhaRnConsultarCategoriaBaseDados, resultadoConsulta.Mensagem.ParaUsuario));

                toCategoria.UltAtualizacao = resultadoConsulta.Dados.UltAtualizacao; // Pega o token de atualização para SAC

                var bdCategoria = Infra.InstanciarBD<Pxcqcaxn.Categoria>();

                using (EscopoTransacional escopo = Infra.CriarEscopoTransacional())
                {
                    var resultado = bdCategoria.Excluir(toCategoria);

                    if (!resultado.OK)
                        return resultado;

                    escopo.EfetivarTransacao();

                    return Infra.RetornarSucesso(resultado.Dados, new OperacaoRealizadaMensagem("Exclusão"));
                }
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<int>(exception);
            }
        }

        /// <summary>
        /// Gera relatório da tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta e o nome do relatório gerado, ou as informações de erro</returns>
        public virtual Retorno<string> Imprimir(TOCategoria toCategoria) // Extra (sem US vinculada)
        {
            try
            {
                var resultado = Listar(toCategoria, null);

                if (!resultado.OK)
                    return Infra.RetornarFalha<List<TOCategoria>, string>(resultado);

                using (var relatorio = new RelatorioPadrao(Infra))
                {
                    relatorio.Colunas.Add(new Coluna(TOCategoria.CODIGO_CATEGORIA, 8));
                    relatorio.Colunas.Add(new Coluna(TOCategoria.DESCRICAO_CATEGORIA, 35));

                    var relatorioBuilder = new StringBuilder();

                    foreach (TOCategoria toCategoriaAtual in resultado.Dados)
                    {
                        var definicaoColunas = relatorio.Colunas;

                        relatorioBuilder.Append(
                            toCategoriaAtual
                                .CodCategoria
                                .ToString()
                                .PadRight(definicaoColunas[TOCategoria.CODIGO_CATEGORIA].Tamanho)
                        );

                        relatorioBuilder.Append(
                            toCategoriaAtual
                                .Descricao
                                .ToString()
                                .PadRight(definicaoColunas[TOCategoria.DESCRICAO_CATEGORIA].Tamanho)
                        );

                        relatorio.AdicionarLinha(relatorioBuilder.ToString());

                        relatorioBuilder.Clear();
                    }

                    return Infra.RetornarSucesso(relatorio.NomeArquivoVirtual, new OperacaoRealizadaMensagem());
                }
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<string>(exception);
            }
        }

        /// <summary>
        /// Inclui registro na tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<int> Incluir(TOCategoria toCategoria) // US1 - Inclusão de nova categoria
        {
            try
            {
                if (!toCategoria.CodCategoria.FoiSetado)
                    return Infra.RetornarFalha<int>(new CategoriaMensagem(TipoCategoriaMensagem.FalhaRnValidarExistenciaCod));

                if (!toCategoria.Descricao.FoiSetado)
                    return Infra.RetornarFalha<int>(new CategoriaMensagem(TipoCategoriaMensagem.FalhaRnValidarExistenciaDescricao));

                if (!ValidarTO(toCategoria, out var listaRetornoValidacao))
                    return Infra.RetornarFalha<int>(new ObjetoInvalidoMensagem(listaRetornoValidacao));

                var resultadoConsulta = Obter(toCategoria);

                if (!resultadoConsulta.OK && !(resultadoConsulta.Mensagem is RegistroInexistenteMensagem))
                    return Infra.RetornarFalha<int>(resultadoConsulta.Mensagem);

                if (resultadoConsulta.OK)
                    return Infra.RetornarFalha<int>(new CategoriaMensagem(TipoCategoriaMensagem.FalhaRnIncluirCategoriaJaExistente));

                toCategoria.CodOperador = Infra.Usuario.Matricula;

                var bdCategoria = Infra.InstanciarBD<Pxcqcaxn.Categoria>();

                using (EscopoTransacional escopo = Infra.CriarEscopoTransacional())
                {
                    var resultado = bdCategoria.Incluir(toCategoria);

                    if (!resultado.OK)
                        return resultado;

                    escopo.EfetivarTransacao();

                    return Infra.RetornarSucesso(resultado.Dados, new OperacaoRealizadaMensagem("Inclusão"));
                }
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<int>(exception);
            }
        }

        /// <summary>
        /// Lista registros da tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <param name="toPaginacao">Classe da infra-estrutura contendo as informações de paginação</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<List<TOCategoria>> Listar(TOCategoria toCategoria, TOPaginacao toPaginacao)  // US4 - Listagem de categorias
        {
            try
            {
                var bdCategoria = Infra.InstanciarBD<Pxcqcaxn.Categoria>();

                var resultado = bdCategoria.Listar(toCategoria, toPaginacao);

                if (!resultado.OK)
                    return resultado;

                return Infra.RetornarSucesso(resultado.Dados, new OperacaoRealizadaMensagem());
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<List<TOCategoria>>(exception);
            }
        }

        /// <summary>
        /// Obtém registro da tabela CATEGORIA
        /// </summary>
        /// <param name="toCategoria">Transfer Object de entrada referente à tabela CATEGORIA</param>
        /// <returns>Classe de retorno contendo as informações de resposta ou as informações de erro</returns>
        public virtual Retorno<TOCategoria> Obter(TOCategoria toCategoria) // US5 - Consulta de categoria por código ou descrição
        {
            try
            {
                if (!toCategoria.CodCategoria.FoiSetado && !toCategoria.Descricao.FoiSetado)
                    return Infra.RetornarFalha<TOCategoria>(new CategoriaMensagem(TipoCategoriaMensagem.FalhaRnValidarExistenciaCodOuDescricao));

                if (!ValidarTO(toCategoria, out var listaRetornoValidacao))
                    return Infra.RetornarFalha<TOCategoria>(new ObjetoInvalidoMensagem(listaRetornoValidacao));

                var bdCategoria = Infra.InstanciarBD<Pxcqcaxn.Categoria>();

                var resultado = bdCategoria.Obter(toCategoria);

                if (!resultado.OK)
                    return resultado;

                return Infra.RetornarSucesso(resultado.Dados, new OperacaoRealizadaMensagem());
            }
            catch (Exception exception)
            {
                return Infra.TratarExcecao<TOCategoria>(exception);
            }
        }
    }
}
