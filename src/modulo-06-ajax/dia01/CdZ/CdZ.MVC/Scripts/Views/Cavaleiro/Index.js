'use strict';

$.ajax({ url: urlCavaleiroGet, type: 'GET' })
    .done(function (res) {
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
    });