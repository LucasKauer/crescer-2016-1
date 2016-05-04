'use strict';

var goldSaints = JSON.parse('[{"id":1,"nome":"Mu","dataNascimento":"1967-03-27T03:00:00.000Z","alturaCm":182,"pesoLb":165.35,"signo":"\u00c1ries","tipoSanguineo":"A","localNascimento":"Tibete","localTreinamento":"Jamiel","golpes":["Parede de Cristal","Extin\u00e7\u00e3o Estelar","Revolu\u00e7\u00e3o Estelar"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900361\/93eed452-0d66-11e6-8ba2-e083b8297b2b.png","isThumb":true}]},{"id":2,"nome":"Aldebaran","dataNascimento":"1967-05-08T03:00:00.000Z","alturaCm":210,"pesoLb":286.600941,"signo":"Touro","tipoSanguineo":"B","localNascimento":"Brasil","localTreinamento":"Brasil","golpes":["Grande Chifre"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900419\/dca83616-0d66-11e6-9757-8d07311e6999.png","isThumb":true}]},{"id":3,"nome":"Saga","dataNascimento":"1959-05-30T03:00:00.000Z","alturaCm":188,"pesoLb":191.81,"signo":"G\u00eameos","tipoSanguineo":"AB","localNascimento":"Gr\u00e9cia","localTreinamento":"Santu\u00e1rio, Gr\u00e9cia","golpes":["Sat\u00e3 Imperial","Outra Dimens\u00e3o","Explos\u00e3o Gal\u00e1ctica"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900456\/00e25b7e-0d67-11e6-9fb3-4b35577080d2.png","isThumb":true}]},{"id":4,"nome":"M\u00e1scara da Morte","dataNascimento":"1964-06-24T03:00:00.000Z","alturaCm":184,"pesoLb":180.77900,"signo":"C\u00e2ncer","tipoSanguineo":"A","localNascimento":"It\u00e1lia","localTreinamento":"Sic\u00edlia, It\u00e1lia","golpes":["Ondas do Inferno"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900489\/2cc0fd40-0d67-11e6-9bc0-600c5381c650.png","isThumb":true}]},{"id":5,"nome":"Aiolia","dataNascimento":"1967-08-16T03:00:00.000Z","alturaCm":185,"pesoLb":187.392923,"signo":"Le\u00e3o","tipoSanguineo":"O","localNascimento":"Gr\u00e9cia","localTreinamento":"Santu\u00e1rio, Gr\u00e9cia","golpes":["C\u00e1psula do Poder","Pata do Le\u00e3o","Rel\u00e2mpago de Plasma"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900613\/c4ba42f0-0d67-11e6-9c0e-e79c2278ab0b.png","isThumb":true}]},{"id":6,"nome":"Shaka","dataNascimento":"1967-09-19T03:00:00.000Z","alturaCm":182,"pesoLb":149.914338,"signo":"Virgem","tipoSanguineo":"AB","localNascimento":"\u00cdndia","localTreinamento":"Ganges, \u00cdndia","golpes":["Rendi\u00e7\u00e3o Divina","Ciclo das 6 Exist\u00eancias","Tesouro do C\u00e9u","Invoca\u00e7\u00e3o dos Esp\u00edritos","Ohm!","Kahn!"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900695\/4a5675dc-0d68-11e6-8396-2a775a2b0c39.png","isThumb":true}]},{"id":7,"nome":"Dohko","dataNascimento":"1726-10-20T03:00:00.000Z","alturaCm":170,"signo":"Libra","tipoSanguineo":"A","localNascimento":"China","localTreinamento":"5 Picos Antigos de Rozan, China","golpes":["C\u00f3lera do Drag\u00e3o","C\u00f3lera dos 100 Drag\u00f5es"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900848\/ea27d2e0-0d68-11e6-9d73-78add86a1811.png","isThumb":true}]},{"id":8,"nome":"Milo","dataNascimento":"1967-11-08T03:00:00.000Z","alturaCm":185,"pesoLb":185.1883,"signo":"Escorpi\u00e3o","tipoSanguineo":"B","localNascimento":"Gr\u00e9cia","localTreinamento":"Ilha de Milos, Gr\u00e9cia","golpes":["Restri\u00e7\u00e3o","Agulha Escarlate","Antares"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14900894\/36445900-0d69-11e6-81c9-77cb17448b9d.png","isThumb":true}]},{"id":9,"nome":"Aiolos","dataNascimento":"1960-11-30T03:00:00.000Z","alturaCm":187,"pesoLb":187.392923,"signo":"Sagit\u00e1rio","tipoSanguineo":"O","localNascimento":"Gr\u00e9cia","localTreinamento":"Santu\u00e1rio, Gr\u00e9cia","golpes":["Trov\u00e3o At\u00f4mico","Flecha da Justi\u00e7a"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14901061\/e5fe3b90-0d69-11e6-9a78-2449055be1fa.png","isThumb":true}]},{"id":10,"nome":"Shura","dataNascimento":"1964-01-12T03:00:00.000Z","alturaCm":186,"pesoLb":182.983678,"signo":"Capric\u00f3rnio","tipoSanguineo":"B","localNascimento":"Espanha","localTreinamento":"Montes Pirineus, Espanha","golpes":["Excalibur"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14901144\/5af186c8-0d6a-11e6-934a-35db18b16752.png","isThumb":true}]},{"id":11,"nome":"Camus","dataNascimento":"1967-02-07T03:00:00.000Z","alturaCm":184,"pesoLb":167.551319,"signo":"Aqu\u00e1rio","tipoSanguineo":"A","localNascimento":"Fran\u00e7a","localTreinamento":"Sib\u00e9ria Oriental","golpes":["P\u00f3 de Diamante","Trov\u00e3o Aurora","Execu\u00e7\u00e3o Aurora"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14901196\/9f128f78-0d6a-11e6-86b3-1a68234e9bfc.png","isThumb":true}]},{"id":12,"nome":"Afrodite","dataNascimento":"1965-03-10T03:00:00.000Z","alturaCm":183,"pesoLb":158.732829,"signo":"Peixes","tipoSanguineo":"O","localNascimento":"Su\u00e9cia","localTreinamento":"Groel\u00e2ndia","golpes":["Rosas Diab\u00f3licas Reais","Rosas Piranhas","Rosa Branca"],"imagens":[{"url":"https:\/\/cloud.githubusercontent.com\/assets\/526075\/14901259\/f4a0b3ca-0d6a-11e6-89b1-59855cabc43d.png","isThumb":true}]}]');
console.log(goldSaints);

/* Funções utilitárias para re-aproveitar código */

var formatarNumero = function(n) {
  // Cuidado com toFixed, ex:
  // parseFloat((184.5 / 100).toFixed(2))
  return Math.round(n * 100) / 100;
};

var cmParaMetros = function(cm) {
  return cm / 100;
};

var lbParaKilos = function(lb) {
  return lb / 2.2046;
};

var apenasComPesoDefinido = function(e) {
  return typeof e.pesoLb !== 'undefined';
};

/* Fim de funções utilitárias para aproveitar código */

// Ex 1.
function obterDoadores() {
  return goldSaints.filter(function(e) {
    return e.tipoSanguineo === 'O';
  });
};

// Ex 2.
function obterCavaleiroComMaisGolpes() {
  // concat: https://developer.mozilla.org/pt-BR/docs/Web/JavaScript/Reference/Global_Objects/Array/concat
  // sort: https://developer.mozilla.org/pt-BR/docs/Web/JavaScript/Reference/Global_Objects/Array/sort
  return goldSaints.concat().sort(function(a, b) {
    return b.golpes.length - a.golpes.length;
    //return a.golpes.length < b.golpes.length ? 1 : -1;
  })[0];
};

// Ex 3.
function obterMesesComMaisAniversarios() {
  // 1. Calculando o número de aniversários por mês
  var aniversariosPorMes = {};
  goldSaints.forEach(function(e) {
    var campo = new Date(e.dataNascimento).getMonth();
    aniversariosPorMes[campo] = aniversariosPorMes[campo] ? ++aniversariosPorMes[campo] : 1;
  });
  // 2. Obtendo as quantidades dos meses que possuem aniversário e o maior número de aniversários em um mês
  var mesesComAniversario = Object.keys(aniversariosPorMes);
  var qtds = mesesComAniversario.map(function(i) { return aniversariosPorMes[i]; });
  var max = Math.max.apply(this, qtds);
  // 3. Filtrando apenas os meses que tem o maior número de aniversário e traduzindo para português.
  var mesesPtBr = [ 'Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro' ];
  return mesesComAniversario
    .filter(function(i) {
      return aniversariosPorMes[i] === max;
    })
    .map(function(e) {
      // parseInt: https://developer.mozilla.org/pt-BR/docs/Web/JavaScript/Reference/Global_Objects/parseInt
      return mesesPtBr[parseInt(e)];
    });
};

// Ex 4.
function obterAlturaMedia() {
  // reduce: https://developer.mozilla.org/pt-BR/docs/Web/JavaScript/Reference/Global_Objects/Array/Reduce
  var mediaAltura = goldSaints.reduce(function(acc, e) {
    return acc + e.alturaCm;
  }, 0) / goldSaints.length;
  return formatarNumero(cmParaMetros(mediaAltura));
};

// Ex 5.
function obterAlturaMediana() {
  // Mediana de um conjunto par é a média dos elementos centrais
  var elementoCentral = goldSaints.length / 2;
  var medianaAltura = (goldSaints[elementoCentral].alturaCm + goldSaints[elementoCentral - 1].alturaCm) / 2;
  return cmParaMetros(medianaAltura);
};

// Ex 6a.
function obterPesoMedio() {
  var cavaleirosComPeso = 0;
  var mediaPeso = goldSaints
    .filter(apenasComPesoDefinido)
    .map(function(e) {
      cavaleirosComPeso++;
      return e.pesoLb;
    })
    .reduce(function(acc, e) {
      return acc + e;
    }, 0) / cavaleirosComPeso;

  return formatarNumero(lbParaKilos(mediaPeso));
};

// Ex 6b.
function obterPesoMedioDoadores() {
  var cavaleirosComPeso = 0;
  var mediaPeso = obterDoadores()
    .filter(apenasComPesoDefinido)
    .map(function(e) {
      cavaleirosComPeso++;
      return e.pesoLb;
    })
    .reduce(function(acc, e) {
      return acc + e;
    }, 0) / cavaleirosComPeso;

  return formatarNumero(lbParaKilos(mediaPeso));
};