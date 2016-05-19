'use strict';

var goldSaints =
JSON.parse(
  localStorage['cavaleiros'] ||
  '[{"id":1,"nome":"Mu","dataNascimento":"1967-03-27T03:00:00.000Z","alturaCm":182,"pesoLb":165.35,"signo":"\u00c1ries","tipoSanguineo":"A","localNascimento":"Tibete","localTreinamento":"Jamiel","golpes":["Parede de Cristal","Extin\u00e7\u00e3o Estelar","Revolu\u00e7\u00e3o Estelar"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900361\/93eed452-0d66-11e6-8ba2-e083b8297b2b.png","isThumb":true}]},{"id":2,"nome":"Aldebaran","dataNascimento":"1967-05-08T03:00:00.000Z","alturaCm":210,"pesoLb":286.600941,"signo":"Touro","tipoSanguineo":"B","localNascimento":"Brasil","localTreinamento":"Brasil","golpes":["Grande Chifre"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900419\/dca83616-0d66-11e6-9757-8d07311e6999.png","isThumb":true}]},{"id":3,"nome":"Saga","dataNascimento":"1959-05-30T03:00:00.000Z","alturaCm":188,"pesoLb":191.81,"signo":"G\u00eameos","tipoSanguineo":"AB","localNascimento":"Gr\u00e9cia","localTreinamento":"Santu\u00e1rio, Gr\u00e9cia","golpes":["Sat\u00e3 Imperial","Outra Dimens\u00e3o","Explos\u00e3o Gal\u00e1ctica"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900456\/00e25b7e-0d67-11e6-9fb3-4b35577080d2.png","isThumb":true}]},{"id":4,"nome":"M\u00e1scara da Morte","dataNascimento":"1964-06-24T03:00:00.000Z","alturaCm":184,"pesoLb":180.77900,"signo":"C\u00e2ncer","tipoSanguineo":"A","localNascimento":"It\u00e1lia","localTreinamento":"Sic\u00edlia, It\u00e1lia","golpes":["Ondas do Inferno"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900489\/2cc0fd40-0d67-11e6-9bc0-600c5381c650.png","isThumb":true}]},{"id":5,"nome":"Aiolia","dataNascimento":"1967-08-16T03:00:00.000Z","alturaCm":185,"pesoLb":187.392923,"signo":"Le\u00e3o","tipoSanguineo":"O","localNascimento":"Gr\u00e9cia","localTreinamento":"Santu\u00e1rio, Gr\u00e9cia","golpes":["C\u00e1psula do Poder","Pata do Le\u00e3o","Rel\u00e2mpago de Plasma"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900613\/c4ba42f0-0d67-11e6-9c0e-e79c2278ab0b.png","isThumb":true}]},{"id":6,"nome":"Shaka","dataNascimento":"1967-09-19T03:00:00.000Z","alturaCm":182,"pesoLb":149.914338,"signo":"Virgem","tipoSanguineo":"AB","localNascimento":"\u00cdndia","localTreinamento":"Ganges, \u00cdndia","golpes":["Rendi\u00e7\u00e3o Divina","Ciclo das 6 Exist\u00eancias","Tesouro do C\u00e9u","Invoca\u00e7\u00e3o dos Esp\u00edritos","Ohm!","Kahn!"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900695\/4a5675dc-0d68-11e6-8396-2a775a2b0c39.png","isThumb":true}]},{"id":7,"nome":"Dohko","dataNascimento":"1726-10-20T03:00:00.000Z","alturaCm":170,"signo":"Libra","tipoSanguineo":"A","localNascimento":"China","localTreinamento":"5 Picos Antigos de Rozan, China","golpes":["C\u00f3lera do Drag\u00e3o","C\u00f3lera dos 100 Drag\u00f5es"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900848\/ea27d2e0-0d68-11e6-9d73-78add86a1811.png","isThumb":true}]},{"id":8,"nome":"Milo","dataNascimento":"1967-11-08T03:00:00.000Z","alturaCm":185,"pesoLb":185.1883,"signo":"Escorpi\u00e3o","tipoSanguineo":"B","localNascimento":"Gr\u00e9cia","localTreinamento":"Ilha de Milos, Gr\u00e9cia","golpes":["Restri\u00e7\u00e3o","Agulha Escarlate","Antares"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900894\/36445900-0d69-11e6-81c9-77cb17448b9d.png","isThumb":true}]},{"id":9,"nome":"Aiolos","dataNascimento":"1960-11-30T03:00:00.000Z","alturaCm":187,"pesoLb":187.392923,"signo":"Sagit\u00e1rio","tipoSanguineo":"O","localNascimento":"Gr\u00e9cia","localTreinamento":"Santu\u00e1rio, Gr\u00e9cia","golpes":["Trov\u00e3o At\u00f4mico","Flecha da Justi\u00e7a"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14901061\/e5fe3b90-0d69-11e6-9a78-2449055be1fa.png","isThumb":true}]},{"id":10,"nome":"Shura","dataNascimento":"1964-01-12T03:00:00.000Z","alturaCm":186,"pesoLb":182.983678,"signo":"Capric\u00f3rnio","tipoSanguineo":"B","localNascimento":"Espanha","localTreinamento":"Montes Pirineus, Espanha","golpes":["Excalibur"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14901144\/5af186c8-0d6a-11e6-934a-35db18b16752.png","isThumb":true}]},{"id":11,"nome":"Camus","dataNascimento":"1967-02-07T03:00:00.000Z","alturaCm":184,"pesoLb":167.551319,"signo":"Aqu\u00e1rio","tipoSanguineo":"A","localNascimento":"Fran\u00e7a","localTreinamento":"Sib\u00e9ria Oriental","golpes":["P\u00f3 de Diamante","Trov\u00e3o Aurora","Execu\u00e7\u00e3o Aurora"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14901196\/9f128f78-0d6a-11e6-86b3-1a68234e9bfc.png","isThumb":true}]},{"id":12,"nome":"Afrodite","dataNascimento":"1965-03-10T03:00:00.000Z","alturaCm":183,"pesoLb":158.732829,"signo":"Peixes","tipoSanguineo":"O","localNascimento":"Su\u00e9cia","localTreinamento":"Groel\u00e2ndia","golpes":["Rosas Diab\u00f3licas Reais","Rosas Piranhas","Rosa Branca"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14901259\/f4a0b3ca-0d6a-11e6-89b1-59855cabc43d.png","isThumb":true}]}]'
);
var ultimoIdInserido = parseInt(localStorage['ultimoIdInserido']) || goldSaints[goldSaints.length - 1].id;

$(function() {

  // iniciando o plugin e informando a máscara.
  $('#txtDtNascimento').datepicker({
    dateFormat: 'dd/mm/yy'
  });

  var $frmNovoCavaleiro = $('#frmNovoCavaleiro');
  $frmNovoCavaleiro.submit(function(e) {
    // console.log($frmNovoCavaleiro.serialize());

    var cavaleiro = converterFormParaCavaleiro($frmNovoCavaleiro);
    localStorage['ultimoIdInserido'] = cavaleiro.id = ++ultimoIdInserido;
    goldSaints.push(cavaleiro);
    localStorage['cavaleiros'] = JSON.stringify(goldSaints);
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
      // url padrão caso não tenha foto
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

        adicionarBtnExclusao(cavaleiro.id, $img);

        if (indice < goldSaints.length - 1) carregaImg(indice + 1);
      };
    }

  })(/* parâmetro inicial, não é padrão de mercado ser zero sempre */ 0);

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
  // forEach - Array.prototype
  // [ 4, 3, 2, 1, 'ursinhos carinhosos'].forEach(function(elem, indice) { });
  // each - jQuery
  $('#novasImagens li').each(function(indice, elem) {
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
    adicionarBtnExclusao(cavaleiro.id, $img);
};


function adicionarBtnExclusao(idCavaleiro, $img) {
  var $btnExcluir = $('<button>')
    // É possível criar atributos novos, sugestão: utilizar o prefixo data-*
    // Desta forma não quebramos a especificação do HTML de informar mais de um elemento com o mesmo id
    .attr('data-cavaleiro-id', idCavaleiro)
    .addClass('btn btn-small btn-danger btn-canto-imagem')
    .text('X');
  $btnExcluir.insertAfter($img);
  $btnExcluir.click(excluirCavaleiro);
};

function gerarElementoLiComInputs() {
  var $novoTxt = $('<input>').attr('name', 'urlImagem').attr('type', 'text').attr('placeholder', 'Ex: bit.ly/shiryu.png');
  var $novoCheckbox =
    // Dentro de um label para pode vincular o texto ao checkbox
    $('<label>')
      .append(
        $('<input>')
        .attr('type', 'checkbox')
        .attr('name', 'isThumb')
        .attr('checked', 'checked'))
      .append('É thumbnail?');
  return $('<li>').append($novoTxt).append($novoCheckbox);
};

function gerarElementoLiComInputTexto() {
  var $novoTxt = $('<input>').attr('name', 'golpe').attr('type', 'text').attr('placeholder', 'Ex: Pó de diamante');
  return $('<li>').append($novoTxt);
};

function obterThumb(cavaleiro) {
  // Pegando a primeira imagem que é thumbnail
  // C# 6
  // using System.Linq;
  // return cavaleiro.imagens.FirstOrDefault(_ => _.isThumb);
  var thumbs = cavaleiro.imagens.filter(function(i) {
    return i.isThumb;
  });
  //debugger;
  return thumbs.isEmpty() ? { url: 'https://i.ytimg.com/vi/trKzSiBOqt4/hqdefault.jpg', isThumb: true } : thumbs[0];
};

function excluirCavaleiro() {
  // Descobrindo o índice do cavaleiro no array a partir do seu id.
  var idCavaleiro = parseInt($(this).attr('data-cavaleiro-id'));
  var indiceParaRemover;
  goldSaints.forEach(function(elem, i) {
    if (elem.id === idCavaleiro) {
      indiceParaRemover = i;
      return;
    }
  });
  $('#cavaleiros li').eq(indiceParaRemover).remove();
  // splice: https://developer.mozilla.org/pt-BR/docs/Web/JavaScript/Reference/Global_Objects/Array/splice
  goldSaints.splice(indiceParaRemover, 1);
  localStorage['cavaleiros'] = JSON.stringify(goldSaints);
}
