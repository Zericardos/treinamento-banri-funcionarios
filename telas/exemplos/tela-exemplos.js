(function () {
    const ROTA = '/exemplos';

    Roteador.telas.registrarInicializador(MAPA_TELAS['exemplos'], inicializar);

    ClienteHttp.api.configurar(3090);

    const exemploEmEdicao = {
        id: null
    };

    function inicializar() {

        console.log('Tela ' + MAPA_TELAS['exemplos'] + ' inicializada!');
        document
            .getElementById('btn-listar')
            .addEventListener('click', listarExemplos);
        
        document
            .getElementById('btn-novo')
            .addEventListener('click', 
                function () { 
                    detalharExemplo(); 
                }
            );

        document
            .getElementById('btn-salvar')
            .addEventListener('click', salvar);
        
        document
            .getElementById('btn-cancelar')
            .addEventListener('click', listarExemplos);

        listarExemplos();
    }

    function listarExemplos() {
        ClienteHttp.api
            .get(ROTA)
            .then(function (listaExemplos) {
                renderizarListaExemplos(listaExemplos);

                ativarView('view-lista');
            })
            .catch(function (excecao) {
                console.error('Ocorreu um erro ao listar exemplos: ' + excecao);
            });
    }

    function renderizarListaExemplos(listaExemplos) {
        const tabela = document.getElementById('tabela-exemplos');
        
        tabela.innerHTML = '';

        listaExemplos.forEach(function (exemplo) {
            const linhaTabela = document.createElement('tr');

            linhaTabela.appendChild(criarCelulaDados(exemplo.Id));
            linhaTabela.appendChild(criarCelulaDados(exemplo.Caracteristica1));
            linhaTabela.appendChild(criarCelulaDados(exemplo.Caracteristica2));
            linhaTabela.appendChild(criarCelulaDados(exemplo.Caracteristica3));
            linhaTabela.appendChild(criarCelulaDados(exemplo.Caracteristica4));

            const celulaAcoes = document.createElement('td');

            celulaAcoes.appendChild(
                criarBotaoAcao('Editar (PUT)', null, 
                    function () { 
                        detalharExemplo(exemplo.Id);
                    }
                )
            );
            celulaAcoes.appendChild(
                criarBotaoAcao('Excluir (DELETE)', 'danger', 
                    function () {
                        excluir(exemplo.Id);
                    }
                )
            );

            celulaAcoes.classList.add('acoes');
            
            linhaTabela.appendChild(celulaAcoes);

            tabela.appendChild(linhaTabela);
        });
    }

    function detalharExemplo(idExemplo) {
        limparFormulario();
        
        const tituloFormulario = document.getElementById('titulo-formulario')

        if (!idExemplo) {
            exemploEmEdicao.id = null;
            
            tituloFormulario.innerText = 'Incluir Novo Exemplo';

            ativarView('view-formulario');

            return;
        }

        ClienteHttp.api
            .get(ROTA + '/' + idExemplo)
            .then(function (exemplo) {
                exemploEmEdicao.id = exemplo.Id;
                
                preencherDetalhesExemplo(exemplo);

                tituloFormulario.innerText = 'Alterar Exemplo ' + exemplo.Caracteristica1;

                ativarView('view-formulario');
            })
            .catch(function (excecao) {
                console.error('Ocorreu um erro ao consultar o exemplo ' + idExemplo + ': ' + excecao);
            });
    }

    function preencherDetalhesExemplo(exemplo) {
        document.getElementById('caracteristica-1').value = exemplo.Caracteristica1;
        document.getElementById('caracteristica-2').value = exemplo.Caracteristica2;
        document.getElementById('caracteristica-3').checked = exemplo.Caracteristica3;
        document.getElementById('caracteristica-4').value = exemplo.Caracteristica4;
    }

    function ativarView(idView) {
        const sinalizadorViewAtiva = 'ativo';
        
        document
            .querySelectorAll('#conteudo-exemplos .view')
            .forEach(function (elemento) {
                elemento.classList.remove(sinalizadorViewAtiva);
            });

        document
            .getElementById(idView)
            .classList.add(sinalizadorViewAtiva);
    }
    
    function salvar() {
        const exemploDto = {
            caracteristica1: document.getElementById('caracteristica-1').value,
            caracteristica2: Number(document.getElementById('caracteristica-2').value),
            caracteristica3: document.getElementById('caracteristica-3').checked,
            caracteristica4: Number(document.getElementById('caracteristica-4').value)
        };

        const requisicao = exemploEmEdicao.id
            ? ClienteHttp.api.put(ROTA + '/' + exemploEmEdicao.id, exemploDto)
            : ClienteHttp.api.post(ROTA, exemploDto);

        requisicao
            .then(function () {
                listarExemplos();
            })
            .catch(function (excecao) {
                if (exemploEmEdicao.id)
                    console.error('Ocorreu um erro ao tentar atualizar o exemplo ' + idExemplo + ': ' + excecao);
                else
                    console.error('Ocorreu um erro ao tentar incluir um novo exemplo: ' + excecao);
            });
    }

    function excluir(idExemplo) {
        if (!confirm('Deseja realmente remover este exemplo?'))
            return;
        
        ClienteHttp.api
            .delete(ROTA + '/' + idExemplo)
            .then(function () {
                listarExemplos();
            })
            .catch(function (excecao) {
                console.error('Ocorreu um erro ao tentar excluir o exemplo ' + idExemplo + ': ' + excecao);
            });
    }

    function limparFormulario() {
        document.getElementById('caracteristica-1').value = '';
        document.getElementById('caracteristica-2').value = '';
        document.getElementById('caracteristica-3').checked = false;
        document.getElementById('caracteristica-4').value = '';
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
