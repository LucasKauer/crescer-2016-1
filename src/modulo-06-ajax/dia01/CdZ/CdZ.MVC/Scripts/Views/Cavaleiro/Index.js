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
});