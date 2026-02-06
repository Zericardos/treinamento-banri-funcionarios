using C1_DAL.DAOs;
using C1_DAL.Models;
using C2_BLL.DTOs;
using C2_BLL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace C2_BLL.Servicos
{
    public class IdiomaServico
    {
        private static readonly IdiomaDao _dao = new IdiomaDao();

        public IEnumerable<IdiomaDto> ListarIdiomas()
        {
            return _dao
                .Listar()
                .Select(idiomaModel => new IdiomaDto
                {
                    Id = idiomaModel.Id,
                    CodigoIsoCombinado = Feconid.CodigoToIso(idiomaModel.Id),
                    Descricao = idiomaModel.Descricao,
                    UsuarioUltimaAlteracao = idiomaModel.UsuarioUltimaAlteracao,
                    DataHoraUltimaAlteracao = idiomaModel.DataHoraUltimaAlteracao
                });
        }

        public IdiomaDto ConsultarIdioma(string id)
        {
            return ConsultarIdioma(Convert.ToInt32(id));
        }

        public IdiomaDto ConsultarIdioma(int id)
        {
            var idiomaModelUnico = _dao
                .Listar()
                .FirstOrDefault(idiomaModel => idiomaModel.Id == id);

            if (idiomaModelUnico == null)
                return null;

            return new IdiomaDto
            {
                Id = idiomaModelUnico.Id,
                CodigoIsoCombinado = Feconid.CodigoToIso(idiomaModelUnico.Id),
                Descricao = idiomaModelUnico.Descricao,
                UsuarioUltimaAlteracao = idiomaModelUnico.UsuarioUltimaAlteracao,
                DataHoraUltimaAlteracao = idiomaModelUnico.DataHoraUltimaAlteracao
            };
        }

        public int? IncluirIdioma(IdiomaDto idiomaDto)
        {
            idiomaDto.Id = Feconid.IsoToCodigo(idiomaDto.CodigoIsoCombinado);

            var idiomaDtoConsultado = ConsultarIdioma(idiomaDto.Id);

            if (idiomaDtoConsultado != null)
                return null;

            var idiomaModelIncluir = new IdiomaModel
            {
                Id = idiomaDto.Id,
                Descricao = idiomaDto.Descricao
            };

            var idiomaModelIncluido = _dao.Incluir(idiomaModelIncluir);

            if (idiomaModelIncluido == null)
                return 0;

            return idiomaModelIncluido.Id;
        }

        public bool? AlterarIdioma(IdiomaDto idiomaDto)
        {
            var idiomaDtoConsultado = ConsultarIdioma(idiomaDto.Id);

            if (idiomaDtoConsultado == null)
                return null;

            var idiomaModelAlterar = new IdiomaModel
            {
                Descricao = idiomaDto.Descricao,
                UsuarioUltimaAlteracao = idiomaDto.UsuarioUltimaAlteracao,
                DataHoraUltimaAlteracao = DateTime.Now
            };

            return _dao.Alterar(idiomaModel => idiomaModel.Id == idiomaDtoConsultado.Id, idiomaModelAlterar);
        }

        public bool? RemoverIdioma(string id)
        {
            var idiomaDtoConsultado = ConsultarIdioma(id);

            if (idiomaDtoConsultado == null)
                return null;

            return _dao.Remover(idiomaModel => idiomaModel.Id == idiomaDtoConsultado.Id);
        }
    }
}
