'use strict';

function Cavaleiro(dadosServidor) {
    for (var prop in dadosServidor) {
        this[prop] = dadosServidor[prop];
    }
};

Cavaleiro.prototype.obterThumb = function () {
    // Pegando a primeira imagem que é thumbnail
    var resultado = this.Imagens.filter(function (i) {
        return i.IsThumb;
    });
    // url padrão caso não tenha foto
    var thumbnailPadrao = { Url: 'https://cloud.githubusercontent.com/assets/526075/15455448/06739c34-202b-11e6-9b5d-c8d150a5509f.png', IsThumb: true };
    return resultado.length > 0 ? resultado[0] : thumbnailPadrao;
};