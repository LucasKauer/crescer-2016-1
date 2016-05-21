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
};

CavaleiroIndexView.prototype.render = function () {
    var self = this;

    // 1 - Carregar lista de cavaleiros na tela
    this.cavaleiros.todos()
        .then(
            function onSuccess(res) {
                res.data.forEach(function (cava) {
                    self.cavaleirosUi.append(
                        self.criarHtmlCavaleiro(cava)
                    );
                });
            },
            function onError(res) {
                self.errorToast.show(res.status + ' - ' + res.statusText);
            }
        );

    // 2 - Registra evento de clique para inserção do cavaleiro fake
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

CavaleiroIndexView.prototype.criarHtmlCavaleiro = function (cava) {
    return $('<li>')
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
};

CavaleiroIndexView.prototype.excluirCavaleiroNoServidor = function (e) {
    // dispensamos o uso do atributo 'data-cavaleiro-id' utilizando event.data:
    // pirou? rtfm => http://api.jquery.com/event.data/
    var self = e.data.self;
    self.cavaleiros.excluir(e.data.id)
        .done(function (res) {
            self.successToast.show('Excluído com sucesso!');
        });
};

CavaleiroIndexView.prototype.editarCavaleiroNoServidor = function(e) {
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