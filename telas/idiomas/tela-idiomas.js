(function () {
    const ROTA = '/idiomas';

    Roteador.telas.registrarInicializador(MAPA_TELAS['idiomas'], inicializar);

    ClienteHttp.api.configurar(3090);
    
    const idiomaEmEdicao = {
        id: null
    };

    function inicializar() {
        document
            .getElementById('btn-listar')
            .addEventListener('click', listarIdiomas);
        
        document
            .getElementById('btn-novo')
            .addEventListener('click', 
                function () { 
                    detalharIdioma(); 
                }
            );

        document
            .getElementById('btn-salvar')
            .addEventListener('click', salvar);
        
        document
            .getElementById('btn-cancelar')
            .addEventListener('click', listarIdiomas);

        listarIdiomas();
    }

    function listarIdiomas() {
        ClienteHttp.api
            .get(ROTA)
            .then(function (listaIdiomas) {
                renderizarListaIdiomas(listaIdiomas);

                ativarView('view-lista');
            })
            .catch(function (excecao) {
                console.error('Ocorreu um erro ao listar idiomas: ' + excecao);
            });
    }

    function renderizarListaIdiomas(listaIdiomas) {
        const tabela = document.getElementById('tabela-idiomas');
        
        tabela.innerHTML = '';

        listaIdiomas.forEach(function (idioma) {
            const linhaTabela = document.createElement('tr');

            linhaTabela.appendChild(criarCelulaDados(idioma.Id));
            linhaTabela.appendChild(criarCelulaDados(idioma.CodigoIsoCombinado));
            linhaTabela.appendChild(criarCelulaDados(idioma.Descricao));
            linhaTabela.appendChild(criarCelulaDados(idioma.UsuarioUltimaAlteracao));
            linhaTabela.appendChild(criarCelulaDados(idioma.DataUltimaAlteracao));

            const celulaAcoes = document.createElement('td');

            celulaAcoes.appendChild(
                criarBotaoAcao('Editar (PUT)', null, 
                    function () { 
                        detalharIdioma(idioma.Id);
                    }
                )
            );
            celulaAcoes.appendChild(
                criarBotaoAcao('Excluir (DELETE)', 'danger', 
                    function () {
                        excluir(idioma.Id);
                    }
                )
            );

            celulaAcoes.classList.add('acoes');
            
            linhaTabela.appendChild(celulaAcoes);

            tabela.appendChild(linhaTabela);
        });
    }

    function detalharIdioma(idIdioma) {
        limparFormulario();
        
        const tituloFormulario = document.getElementById('titulo-formulario')

        if (!idIdioma) {
            idiomaEmEdicao.id = null;
            
            tituloFormulario.innerText = 'Incluir Novo Idioma';

            ativarView('view-formulario');

            return;
        }

        ClienteHttp.api
            .get(ROTA + '/' + idIdioma)
            .then(function (idioma) {
                idiomaEmEdicao.id = idioma.Id;
                
                preencherDetalhesIdioma(idioma);

                tituloFormulario.innerText = 'Alterar Idioma ' + idioma.CodigoIsoCombinado;

                ativarView('view-formulario');
            })
            .catch(function (excecao) {
                console.error('Ocorreu um erro ao consultar o idioma ' + idIdioma + ': ' + excecao);
            });
    }

    function preencherDetalhesIdioma(idioma) {
        document.getElementById('CodigoIsoCombinado').value = idioma.CodigoIsoCombinado;
        document.getElementById('Descricao').value = idioma.Descricao;
    }

    function ativarView(idView) {
        const sinalizadorViewAtiva = 'ativo';
        
        document
            .querySelectorAll('#conteudo-idiomas .view')
            .forEach(function (elemento) {
                elemento.classList.remove(sinalizadorViewAtiva);
            });

        document
            .getElementById(idView)
            .classList.add(sinalizadorViewAtiva);
    }
    
    function salvar() {
        const idiomaDto = {
            CodigoIsoCombinado: document.getElementById('CodigoIsoCombinado').value,
            Descricao: document.getElementById('Descricao').value
        };

        const requisicao = idiomaEmEdicao.id
            ? ClienteHttp.api.put(ROTA + '/' + idiomaEmEdicao.id, idiomaDto)
            : ClienteHttp.api.post(ROTA, idiomaDto);

        requisicao
            .then(function () {
                listarIdiomas();
            })
            .catch(function (excecao) {
                if (idiomaEmEdicao.id)
                    console.error('Ocorreu um erro ao tentar atualizar o idioma ' + idIdioma + ': ' + excecao);
                else
                    console.error('Ocorreu um erro ao tentar incluir um novo idioma: ' + excecao);
            });
    }

    function excluir(idIdioma) {
        if (!confirm('Deseja realmente remover este idioma?'))
            return;
        
        ClienteHttp.api
            .delete(ROTA + '/' + idIdioma)
            .then(function () {
                listarIdiomas();
            })
            .catch(function (excecao) {
                console.error('Ocorreu um erro ao tentar excluir o idioma ' + idIdioma + ': ' + excecao);
            });
    }

    function limparFormulario() {
        document.getElementById('CodigoIsoCombinado').value = '';
        document.getElementById('Descricao').value = '';
    }

    function criarCelulaDados(dados) {
        const celulaDados = document.createElement('td');

        celulaDados.textContent = dados;

        return celulaDados;
    }

    function criarBotaoAcao(texto, classe, acaoClick) {
        const botao = document.createElement('button');

        botao.type = 'button';

        botao.textContent = texto;

        botao.addEventListener('click', acaoClick);

        if (classe)
            botao.classList.add(classe);

        return botao;
    }

})();
