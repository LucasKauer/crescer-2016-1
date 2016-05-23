'use strict';

function CavaleiroIndexView(options) {
    options = options || {};
    this.errorToast = options.errorToast;
    this.successToast = options.successToast;
    this.cavaleirosUi = options.cavaleirosUi;
    this.cavaleiros = new Cavaleiros({
        urlGet: options.urlCavaleiroGet,
        urlGetById: options.urlCavaleiroGetById,
        urlPost: options.urlCavaleiroPost,
        urlDelete: options.urlCavaleiroDelete,
        urlPut: options.urlCavaleiroPut
    });
    this.intervaloPolling = options.intervaloPolling || 5000;
    this.idsCavaleirosJaRenderizados = [];
    this.notification = new CustomNotification();
    this.botaoPaginaAnterior = options.botaoPaginaAnterior;
    this.botaoProximaPagina = options.botaoProximaPagina;
    this.paginaAtual = 1;
};

CavaleiroIndexView.prototype.render = function () {
    var self = this;

    // 1 - Carregar inicialmente lista de cavaleiros na tela
    this.cavaleiros.todos()
        .then(
            function onSuccess(res) {
                self.totalPaginas = res.totalPaginas;
                res.data.forEach(function (cava) {
                    self.renderizarCavaleiroNaTela(cava);
                });
            },
            function onError(res) {
                self.errorToast.show(res.status + ' - ' + res.statusText);
            }
        );

    // 2 - Disparar "timer" que consultará servidor a cada X tempo.
    // Se quisermos evitar fazer o bind(this) em todas chamadas internas, podemos tirar a selfie, lembram?
    setInterval(function () {
        this.cavaleiros.todos({ semSpinner: true })
            .done(function (res) {
                var novosCavaleiros = [];
                res.data.forEach(function (cava) {
                    // $.inArray https://api.jquery.com/jQuery.inArray/
                    if ($.inArray(cava.Id, this.idsCavaleirosJaRenderizados) === -1) {
                        novosCavaleiros.push(cava);
                    }
                }.bind(this));
                // Caso haja novos cavaleiros:
                // 1 - Tira o indicativo de "Novo" no últimos adicionados (caso existam)
                // 2 - Renderiza cada novo cavaleiro na tela
                // 3 - Envia notificação com o total de novos cavaleiros que foram adicionados.
                if (novosCavaleiros.length > 0) {
                    if (res.data.length > 0) {
                        $('[data-adicionado-por-ultimo]').remove();
                    }
                    novosCavaleiros.forEach(function (cava) {
                        this.renderizarCavaleiroNaTela(cava, /* é novo? */ true);
                    }.bind(this));
                    this.notification.send(
                        novosCavaleiros.length === 1 ? '1 novo cavaleiro foi adicionado!' :
                        novosCavaleiros.length + ' novos cavaleiros foram adicionados!'
                    );
                }
            }.bind(this));
    }.bind(this), this.intervaloPolling);

    // 3 - Registrando cliques na paginação.
    // aqui usamos o seletor "and" para registrar o mesmo click aos dois botões
    // desta forma geramos o seguinte seletor exemplo, que atende aos dois botões:
    // $('#btnUm, #btnDois')
    $(this.botaoPaginaAnterior.selector + ',' + this.botaoProximaPagina.selector).click(function (e) {
        var sentidoPaginacao = this.botaoProximaPagina.is(e.target) ? 1 : -1;
        this.paginaAtual += sentidoPaginacao;
        this.cavaleiros.todos({ pagina: this.paginaAtual })
            .done(function (res) {
                this.cavaleirosUi.empty();
                res.data.forEach(function (cava) {
                    self.renderizarCavaleiroNaTela(cava);
                });
                CavaleiroIndexView.atualizarBotoesPaginacao.call(this);
            }.bind(this));
    }.bind(this));

    // 4 - Verifica se os botões de paginação devem ser atualizados.
    // call - https://developer.mozilla.org/pt-BR/docs/Web/JavaScript/Reference/Global_Objects/Function/call
    // Aqui o call é utilizado com o efeito parecido do bind(this), porém em tempo de execução (o bind funciona em tempo de definição da função).
    // Também seria possível utilizar .apply(this)
    // Surtou? Pegue um café e dê uma lidinha sobre as diferenças entre call e apply
    // Ânimo, se você chegou até esse comentário é pq vc já foi muito mais longe que a maioria dos devs JS.
    // Viu como JS é muito mais que alert? :-D
    CavaleiroIndexView.atualizarBotoesPaginacao.call(this);

    // 5 - Registra evento de clique para inserção do cavaleiro fake
    // TODO - remover quando colocar o bind dos campos do formulário
    $('#btnCriar').click(function () {
        self.cavaleiros.inserir(cavaleiroHardCoded).done(function (res) {
            // Aqui estamos otendo os detalhes atualizados do cavaleiro recém inserido.
            // Notem o custo de fazer toda separação conceitual (uma action para cada tipo de operação no banco, etc).
            // Poderíamos ter retornado no resultado do POST a entidade atualizada invés de apenas o id, concordam?
            self.cavaleiros.buscar(res.id)
                .done(function (detalhe) {
                    cavaleiroHardCoded = detalhe.data;
                });
        });
    });
};

// Exemplo de como faríamos para simular um "método estático".
// Note que esta function não é "anexada" ao prototype do tipo CavaleiroIndexView, logo não vale para todos objetos criados com o construtor CavaleiroIndexView.
// Tendo então o efeito de um "método estático", vide a forma como ela é chamada no trecho acima.
CavaleiroIndexView.atualizarBotoesPaginacao = function () {
    if (this.paginaAtual === 1) {
        this.botaoPaginaAnterior.attr('disabled', 'disabled').addClass('btn-desabilitado');
    } else if (this.paginaAtual === this.totalPaginas) {
        this.botaoProximaPagina.attr('disabled', 'disabled').addClass('btn-desabilitado');
    } else {
        [this.botaoPaginaAnterior, this.botaoProximaPagina].forEach(function (btn) {
            // removeAttr - https://api.jquery.com/removeAttr/
            btn.removeAttr('disabled');
        });
    }
};

CavaleiroIndexView.prototype.renderizarCavaleiroNaTela = function (cava, novo) {
    this.cavaleirosUi.append(this.criarHtmlCavaleiro(cava, novo));
    this.idsCavaleirosJaRenderizados.push(cava.Id);
};

CavaleiroIndexView.prototype.criarHtmlCavaleiro = function (cava, novo) {

    var cavaleiro = new Cavaleiro(cava);

    var $li = $('<li>')
        .append(
            $('<img>').attr('src', cavaleiro.obterThumb().Url).addClass('cavaleiro-thumb')
        )
        .append(cava.Nome)
        .append(
            $('<button>')
                // o segundo parâmetro são parâmetros que podemos enviar para o evento jQuery
                // posteriormente recuperamos com event.data (vide abaixo)
                // estamos enviando o valor de this pois o contexto é perdido (eventos são assíncronos)
                .on('click', { id: cava.Id, self: this }, this.editarCavaleiroNoServidor)
                .text('Editar')
        )
        .append(
            $('<button>')
                // o segundo parâmetro são parâmetros que podemos enviar para o evento jQuery
                // posteriormente recuperamos com event.data (vide abaixo)
                // estamos enviando o valor de this pois o contexto é perdido (eventos são assíncronos)
                .on('click', { id: cava.Id, self: this }, this.excluirCavaleiroNoServidor)
                .text('Excluir')
        );

    if (novo) {
        $li.append(
            $('<img>')
                .attr('src', 'http://code.divshot.com/geo-bootstrap/img/test/new2.gif')
                .attr('data-adicionado-por-ultimo', '')
        );
    }

    return $li;
};

CavaleiroIndexView.prototype.excluirCavaleiroNoServidor = function (e) {
    // dispensamos o uso do atributo 'data-cavaleiro-id' utilizando event.data:
    // pirou? rtfm => http://api.jquery.com/event.data/
    var self = e.data.self;
    // $(this) retorna o <button> que foi clicado na UI.
    var $button = $(this);
    self.cavaleiros.excluir(e.data.id)
        .done(function (res) {
            // remover da UI: parent() retorna a respectiva <li> do cavaleiro.
            $button.parent().remove();
            self.successToast.show('Excluído com sucesso!');
        });
};

CavaleiroIndexView.prototype.editarCavaleiroNoServidor = function (e) {
    var cavaleiroId = e.data.id;
    var self = e.data.self;
    self.cavaleiros.buscar(cavaleiroId)
        .done(function (detalhe) {
            // TODO: Implementar atualização a partir de um formulário ou campos na tela, e não hard-coded
            cavaleiroHardCoded = detalhe.data;
            simularAtualizacaoHardCoded();
            self.cavaleiros.editar(cavaleiroHardCoded)
                .done(function (res) {
                    self.successToast.show('Cavaleiro atualizado com sucesso!');
                });
        });
};

// TODO: remover cavaleiro hard-coded quando fizer bind do formulário.
var cavaleiroHardCoded = {
    Nome: 'Xiru ' + new Date().getTime(),
    AlturaCm: 187,
    PesoLb: 220.462262,
    Signo: 7,
    TipoSanguineo: 1,
    // Estamos enviando a data UTC (sem timezone) para que seja corretamente armazenada e posteriormente exibida de acordo com o fuso-horário da aplicação cliente que consumir os dados
    DataNascimento: new Date(Date.UTC(2001, 1, 15)).toISOString(),
    Golpes: [{ Nome: 'Cólera do Dragão' }, { Nome: 'Cólera dos 100 dragões' }],
    LocalNascimento: {
        Texto: 'Beijing'
    },
    LocalTreinamento: {
        Texto: '5 picos de rosan'
    },
    Imagens: [{
        Url: 'http://images.uncyc.org/pt/3/37/Shiryumestrepokemon.jpg',
        IsThumb: true
    }, {
        Url: 'http://images.uncyc.org/pt/thumb/5/52/Shyryugyarados.jpg/160px-Shyryugyarados.jpg',
        IsThumb: false
    }]
};

// TODO: Implementar atualização a partir de um formulário ou campos na tela, e não hard-coded
function simularAtualizacaoHardCoded() {
    cavaleiroHardCoded.Nome = 'Novo nome após update ' + new Date().getTime();
    cavaleiroHardCoded.AlturaCm = 205;
    cavaleiroHardCoded.Signo = 3;
    cavaleiroHardCoded.TipoSanguineo = 2;
    // Estamos enviando a data UTC (sem timezone) para que seja corretamente armazenada e posteriormente exibida de acordo com o fuso-horário da aplicação cliente que consumir os dados
    cavaleiroHardCoded.DataNascimento = new Date(Date.UTC(2010, 9, 10)).toISOString();
    if (cavaleiroHardCoded.Golpes.length > 0) {
        cavaleiroHardCoded.Golpes[0] = cavaleiroHardCoded.Golpes[0] || {};
        cavaleiroHardCoded.Golpes[0].Nome = 'Voadora do Sub-Zero Brasileiro'
        cavaleiroHardCoded.Golpes[1] = cavaleiroHardCoded.Golpes[1] || {};
        cavaleiroHardCoded.Golpes[1].Nome = 'Cólera dos 42 dragões';
        cavaleiroHardCoded.Golpes[2] = { Nome: 'Novo golpe aterrador' };
    }
    cavaleiroHardCoded.LocalNascimento.Texto = 'Porto Alegre';
    cavaleiroHardCoded.LocalTreinamento.Texto = 'Alvorada';
    if (cavaleiroHardCoded.Imagens.length > 0) {
        cavaleiroHardCoded.Imagens[0] = cavaleiroHardCoded.Imagens[0] || {};
        cavaleiroHardCoded.Imagens[0].Url = 'https://cloud.githubusercontent.com/assets/526075/15443404/5c97dde6-1ebe-11e6-8ae6-83372051dda7.png';
        cavaleiroHardCoded.Imagens[0].IsThumb = true;
        cavaleiroHardCoded.Imagens[1] = cavaleiroHardCoded.Imagens[1] || {};
        cavaleiroHardCoded.Imagens[1].Url = 'https://cloud.githubusercontent.com/assets/526075/15443410/6e9ba586-1ebe-11e6-8b90-64aca9e18a32.png';
        cavaleiroHardCoded.Imagens[1].IsThumb = false;
    }
};