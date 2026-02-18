(function () {
    const ROTA = '/categorias';

    Roteador.telas.registrarInicializador(MAPA_TELAS['categorias'], inicializar);
    
    ClienteHttp.api.configurar(3090);

    const categoriaEmEdicao = {
        id: null
    };

    function inicializar() {
        console.log('Tela ' + MAPA_TELAS['categorias'] + ' inicializada!');
        document
            .getElementById('btn-listar')
            .addEventListener('click', listarCategorias);
        
        document
            .getElementById('btn-novo')
            .addEventListener('click', 
                function () { 
                    detalharCategoria(); 
                }
            );

        document
            .getElementById('btn-salvar')
            .addEventListener('click', salvar);
        
        document
            .getElementById('btn-cancelar')
            .addEventListener('click', listarCategorias);

        listarCategorias();
    }

    function listarCategorias() {
        ClienteHttp.api
            .get(ROTA)
            .then(function (listaCategorias) {
                renderizarListaCategorias(listaCategorias);

                ativarView('view-lista');
            })
            .catch(function (excecao) {
                console.error('Ocorreu um erro ao listar categorias: ' + excecao);
            });
    }

    function renderizarListaCategorias(listaCategorias) {
        const tabela = document.getElementById('tabela-categorias');
        
        tabela.innerHTML = '';

        listaCategorias.forEach(function (categoria) { // Para cada categoria, cria uma nova linha na tabela
            const linhaTabela = document.createElement('tr'); //cria <tr></tr>

            linhaTabela.appendChild(criarCelulaDados(categoria.Id));
            linhaTabela.appendChild(criarCelulaDados(categoria.Descricao));
            linhaTabela.appendChild(criarCelulaDados(categoria.UsuarioUltimaAlteracao));
            linhaTabela.appendChild(criarCelulaDados(categoria.DataUltimaAlteracao));

            const celulaAcoes = document.createElement('td');

            celulaAcoes.appendChild(
                criarBotaoAcao('Editar (PUT)', null, 
                    function () { 
                        detalharCategoria(categoria.Id);
                    }
                )
            );
            celulaAcoes.appendChild(
                criarBotaoAcao('Excluir (DELETE)', 'danger', 
                    function () {
                        excluir(categoria.Id);
                    }
                )
            );

            celulaAcoes.classList.add('acoes');
            
            linhaTabela.appendChild(celulaAcoes);

            tabela.appendChild(linhaTabela);
        });
    }

    function detalharCategoria(idCategoria) {
        limparFormulario();
        
        const tituloFormulario = document.getElementById('titulo-formulario')

        if (!idCategoria) {
            categoriaEmEdicao.id = null;
            
            tituloFormulario.innerText = 'Incluir Novo Categoria';

            ativarView('view-formulario');

            return;
        }

        ClienteHttp.api
            .get(ROTA + '/' + idCategoria)
            .then(function (categoria) {
                categoriaEmEdicao.id = categoria.Id;
                
                preencherDetalhesCategoria(categoria);

                tituloFormulario.innerText = 'Alterar Categoria ' + categoria.Descricao;

                ativarView('view-formulario');
            })
            .catch(function (excecao) {
                console.error('Ocorreu um erro ao consultar o categoria ' + idCategoria + ': ' + excecao);
            });
    }

    function preencherDetalhesCategoria(categoria) {
        document.getElementById('Id').value = categoria.Id;
        document.getElementById('Descricao').value = categoria.Descricao;
        //document.getElementById('UsuarioUltimaAlteracao').value = categoria.UsuarioUltimaAlteracao;
    }

    function ativarView(idView) {
        console.log('ativarView chamada com:', idView);
        const sinalizadorViewAtiva = 'ativo';
        
        document
            .querySelectorAll('#conteudo-categorias .view')
            .forEach(function (elemento) {
                elemento.classList.remove(sinalizadorViewAtiva);
            });

        document
            .getElementById(idView)
            .classList.add(sinalizadorViewAtiva);
    }
    
    function salvar() {
        console.log('categoriaEmEdicao.id =', categoriaEmEdicao.id);  // ← ADICIONE ISTO
    
        const categoriaDto = {
            //Id: Number(document.getElementById('Id').value),
            //Descricao: document.getElementById('Descricao').value
        };

        if (categoriaEmEdicao.id) {
            categoriaDto.Descricao = document.getElementById('Descricao').value;
        } else {
            categoriaDto.Id = Number(document.getElementById('Id').value);
            categoriaDto.Descricao = document.getElementById('Descricao').value;
        }
            
        const requisicao = categoriaEmEdicao.id
            ? ClienteHttp.api.put(ROTA + '/' + categoriaEmEdicao.id, categoriaDto)
            : ClienteHttp.api.post(ROTA, categoriaDto);

        console.log('Método:', categoriaEmEdicao.id ? 'PUT' : 'POST');

        requisicao
            .then(function () {
                limparFormulario();
                listarCategorias();
            })
            .catch(function (excecao) {
                console.error(excecao);

                var mensagem = '';
                try {
                    if (excecao && excecao.Mensagem)
                        mensagem = excecao.Mensagem;
                    else if (excecao && excecao.message)
                        mensagem = excecao.message;
                    else
                        mensagem = JSON.stringify(excecao);
                }
                catch (e) {
                    mensagem = String(excecao);
                }

                alert('Erro: ' + mensagem);
            });
    }

    function excluir(idCategoria) {
        if (!confirm('Deseja realmente remover este categoria?'))
            return;
        
        ClienteHttp.api
            .delete(ROTA + '/' + idCategoria)
            .then(function () {
                listarCategorias();
            })
            .catch(function (excecao) {
                console.error('Ocorreu um erro ao tentar excluir o categoria ' + idCategoria + ': ' + excecao);
            });
    }

    function limparFormulario() {
        document.getElementById('Id').value = '';
        document.getElementById('Descricao').value = '';
        //document.getElementById('caracteristica-3').checked = false;
        //document.getElementById('caracteristica-4').value = '';
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
