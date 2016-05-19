'use strict';

var htmlHelpers = {};
htmlHelpers.adicionarBtnExcluir = function(idCavaleiro, $img) {
  var $btnExcluir = $('<button>')
    // É possível criar atributos novos, sugestão: utilizar o prefixo data-*
    // Desta forma não quebramos a especificação do HTML de informar mais de um elemento com o mesmo id
    .attr('data-cavaleiro-id', idCavaleiro)
    .addClass('btn btn-small btn-danger btn-canto-imagem')
    .text('X');
  $btnExcluir.insertAfter($img);
  $btnExcluir.click(excluirCavaleiro);
};
