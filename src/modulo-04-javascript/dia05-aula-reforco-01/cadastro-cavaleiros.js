'use strict';

$(function() {

  // iniciando o plugin e informando a máscara.
  $('#txtDtNascimento').datepicker({
    dateFormat: 'dd/mm/yy'
  });

  var $frmNovoCavaleiro = $('#frmNovoCavaleiro');
  $frmNovoCavaleiro.submit(function(e) {
    // console.log($frmNovoCavaleiro.serialize());

    var cavaleiro = converterFormParaCavaleiro($frmNovoCavaleiro);
    repositorio.cavaleiros.adicionar(cavaleiro);
    renderizarCavaleiroNaTela(cavaleiro);

    $frmNovoCavaleiro[0].reset();

    return e.preventDefault();
  });

  // Carregando imagens sequencialmente na ordem, de forma recursiva.
  // No carregamento já registramos o evento de click na imagem para exibir os detalhes do cavaleiro.

  (function carregaImg(indice) {
    var $detalhesCavaleiro = $('#detalhes-cavaleiro');
    var cavaleiro = goldSaints[indice];
    if (typeof cavaleiro !== 'undefined') {

      var thumb = obterThumb(cavaleiro);
      var imgCavaleiro = new Image();
      imgCavaleiro.src = thumb.url;
      imgCavaleiro.alt = cavaleiro.nome;
      imgCavaleiro.id = cavaleiro.id;
      imgCavaleiro.onload = function() {
        var $img = $(imgCavaleiro);
        $img.appendTo($('<li>').appendTo($('#cavaleiros'))).fadeIn();
        $img.on('click mouseleave', function() {
          var self = $(this);
          var nome = self.attr('alt');
          var altura = goldSaints.filter(function(elem) {
            return elem.id === parseInt(self.attr('id'));
          })[0].alturaCm;
          $detalhesCavaleiro.children().detach();
          $detalhesCavaleiro.append($('<h3>').text( nome ));
          $detalhesCavaleiro.append($('<h3>').text( altura / 100 ));
        });
        setTimeout(function() {
          $img.off('mouseleave');
        }, 5000);

        htmlHelpers.adicionarBtnExcluir(cavaleiro.id, $img);

        if (indice < goldSaints.length - 1) carregaImg(indice + 1);
      };
    }

  })(0);

  // Adicionando campos para imagens
  var $novasImagens = $('#novasImagens');

  $('#btnAdicionarImg').click(function() {
    var $novoLi = gerarElementoLiComInputs();
    $novasImagens.append($novoLi);
  });

  $('#btnAdicionarGolpe').click(function() {
    $('#novosGolpes').append(gerarElementoLiComInputTexto());
  });

});

function converterFormParaCavaleiro($form) {

  // Obtém o objeto nativo Form através da posição 0 no objeto jQuery e cria um FormData a partir dele
  var formData = new FormData($form[0]);

  // obtendo objeto date a partir do que foi escolhido.
  var data = $('#txtDtNascimento').datepicker('getDate');

  var novasImagens = [];
  // e === elemento
  // i === indice
  // [ 1, 5, 7 ].forEach(function(e, i) { });
  // i = índice
  // e === elemento
  //fazTudo({ id: 1, tipoSanguineo: 'O', nome: 'goku' });
  //fazTudo(/* id: */ 1, /* tipo sanguineo */ 'O', 'goku', false, null, undefined, []);
  $('#novasImagens li').each(function(/*i, e*/) {
    novasImagens.push({
      url: $(this).find('input[name=urlImagem]').val(),
      isThumb: $(this).find('input[name=isThumb]').is(':checked')
    });
  });

  var novosGolpes = [];
  $('#novosGolpes li').each(function(i) {
    novosGolpes.push($(this).find('input[name=golpe]').val());
  });

  return {
    nome: formData.get('nome'),
    // solução sem FormData:
    // tipoSanguineo: $('#slTipoSanguineo :selected').val()
    tipoSanguineo: formData.get('tipoSanguineo'),
    imagens: novasImagens,
    // toISOString: https://developer.mozilla.org/pt-BR/docs/Web/JavaScript/Reference/Global_Objects/Date/toISOString
    dataNascimento: (data || new Date()).toISOString(),
    alturaCm: parseFloat(formData.get('alturaMetros')) * 100,
    pesoLb: parseFloat(formData.get('pesoKg')) * 2.20462262,
    signo: formData.get('signo'),
    localNascimento: formData.get('localNascimento'),
    localTreinamento: formData.get('localTreinamento'),
    golpes: novosGolpes
  };

  // FormData: https://developer.mozilla.org/en/docs/Web/API/FormData
  /*
  var $frmNovoCavaleiro = $('#frmNovoCavaleiro');
  var formData = new FormData($frmNovoCavaleiro[0]);
  var cavaleiro = {};
  for (var entry of formData.entries()) {
    cavaleiro[entry[0]] = entry[1];
  }*/
};

function renderizarCavaleiroNaTela(cavaleiro) {
  var $img = $('<img>').attr('src', obterThumb(cavaleiro).url);
  $('#cavaleiros')
    .append(
      $('<li>').append(
        $img.fadeIn()
      )
    );
  htmlHelpers.adicionarBtnExcluir(cavaleiro.id, $img);
};

function gerarElementoLiComInputs() {
  var $novoTxt = $('<input>').attr('name', 'urlImagem').attr('type', 'text').attr('placeholder', 'Ex: bit.ly/shiryu.png');
  var $novoCheckbox =
    // Dentro de um label para pode vincular o texto ao checkbox
    $('<label>').append(
      $('<input>')
      .attr('type', 'checkbox')
      .attr('name', 'isThumb')
      .attr('checked', 'checked')
    ).append('É thumbnail?');
  return $('<li>').append($novoTxt).append($novoCheckbox);
};

function gerarElementoLiComInputTexto() {
  var $novoTxt = $('<input>').attr('name', 'golpe').attr('type', 'text').attr('placeholder', 'Ex: Pó de diamante');
  return $('<li>').append($novoTxt);
};

function obterThumb(cavaleiro) {
  // Pegando a primeira imagem que é thumbnail
  var resultado = cavaleiro.imagens.filter(function(i) {
    return i.isThumb;
  });
  // url padrão caso não tenha foto
  var thumbnailPadrao = { url: 'https://i.ytimg.com/vi/trKzSiBOqt4/hqdefault.jpg', isThumb: true };
  return resultado.length > 0 ? resultado[0] : thumbnailPadrao;
};

function excluirCavaleiro() {
  // Descobrindo o índice do cavaleiro no array a partir do seu id.
  var idCavaleiro = parseInt($(this).attr('data-cavaleiro-id'));
  var indiceParaRemover = repositorio.cavaleiros.remover(idCavaleiro);
  $('#cavaleiros li').eq(indiceParaRemover).remove();
}
