'use strict';

function carregarDadosNaPagina() {
    $.ajax({ url: urlCavaleiroGet, type: 'GET'/*, timeout: 2000 */ })
    .then(
        function onSuccess(res) {
            console.log(res.data);
            var $cavaleiros = $('#cavaleiros');
            res.data.forEach(function (cava) {
                $cavaleiros.append(
                    criarHtmlCavaleiro(cava)
                );
            });
        },
        function onError(res) {
            console.error(':(');
            console.error(res);

            var criarSpanComErro = function (msg) {
                return $('<span>').text(msg).addClass('erro');
            };

            $('#feedback')
            .append(criarSpanComErro(res.status))
            .append($('<br>'))
            .append(criarSpanComErro(res.statusText));
        }
    )
    .always(function (res) {
        console.log('acabouuuuuuuu');
    });
};
carregarDadosNaPagina();

function criarHtmlCavaleiro(cava) {
    return $('<li>')
        .append(cava.Nome)
        .append(
            $('<button>')
                .attr('data-cavaleiro-id', cava.Id)
                .click(editarCavaleiroNoServidor)
                .text('Editar')
        )
        .append(
            $('<button>')
                .attr('data-cavaleiro-id', cava.Id)
                .click(excluirCavaleiroNoServidor)
                .text('Excluir')
        );
    // <button data-cavaleiro-id="7" onclick='excluirCavaleiroNoServidor();'>Excluir</button>
}

function excluirCavaleiroNoServidor() {
    var cavaleiroId = parseInt($(this).attr('data-cavaleiro-id'));
    $.ajax({
        url: '/Cavaleiro/Delete' /*+  $.param({ id: cavaleiroId }),*/,
        type: 'DELETE',
        data: { id: cavaleiroId }
    });
};

function editarCavaleiroNoServidor() {
    var cavaleiroId = parseInt($(this).attr('data-cavaleiro-id'));

    $.get('/Cavaleiro/GetById', { id: cavaleiroId })
        .done(function (detalhe) {
            // TODO: Implementar atualização a partir de um formulário ou campos na tela, e não hard-coded
            cavaleiroHardCoded = detalhe.data;
            cavaleiroHardCoded.Nome = 'Novo nome após update ' + new Date().getTime();
            cavaleiroHardCoded.AlturaCm = 205;
            cavaleiroHardCoded.Signo = 3;
            cavaleiroHardCoded.TipoSanguineo = 2;
            cavaleiroHardCoded.DataNascimento = new Date(2001, 0, 15);
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

            $.ajax({
                url: '/Cavaleiro/Put',
                type: 'PUT',
                data: cavaleiroHardCoded
            });
        });
};

var cavaleiroHardCoded = {
    Nome: 'Xiru ' + new Date().getTime(),
    AlturaCm: 187,
    Signo: 7,
    TipoSanguineo: 1,
    DataNascimento: new Date(),
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

function registrarEventoDoBotao() {

    $('#btnCriar').click(function () {

        $.ajax({
            url: urlCavaleiroPost,
            type: 'POST',
            data: cavaleiroHardCoded
        }).done(function (res) {
            // Aqui estamos otendo os detalhes atualizados do cavaleiro recém inserido.
            // Notem o custo de fazer toda separação conceitual (uma action para cada tipo de operação no banco, etc).
            // Poderíamos ter retornado no resultado do POST a entidade atualizada invés de apenas o id, concordam?
            $.get('/Cavaleiro/GetById', { id: res.id })
                .done(function (detalhe) {
                    cavaleiroHardCoded = detalhe.data;
                });
        });

    });
};
registrarEventoDoBotao();


/*.done(function (res) {
    console.log(res.data);
        var $cavaleiros = $('#cavaleiros');
        res.data.forEach(function (cava) {
            $cavaleiros.append(
                $('<li>').append(cava.Nome)
            );
        });
})
.fail(function (res) {
    console.error(':(');
    console.error(res);

    var criarSpanComErro = function (msg) {
        return $('<span>').text(msg).addClass('erro');
    };

    $('#feedback')
    .append(criarSpanComErro(res.status))
    .append($('<br>'))
    .append(criarSpanComErro(res.statusText));
});*/