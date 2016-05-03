'use strict';

// Ex 1
function daisyGame(numero) {
  return 'Love me' + (numero % 2 === 0 ? ' not' : '');
};

// Ex 2
function maiorTexto(arr) {
  var maior = '';
  arr.forEach(function(e) {
    if (e.length > maior.length) maior = e;
  });
  return maior;
};

// Ex 3
function imprime(instrutores, fn) {
  instrutores.forEach(function(instrutor) {
    if (typeof fn === 'function') fn(instrutor);
  });
};

// Ex 4
// adicionar(3)(4);
// ES2015:
// var adicionar = (parcela1) => (parcela2) => parcela1+parcela2
function adicionar(parcela1) {
  return function(parcela2) {
    return parcela1 + parcela2;
  }
};

var fibonacci = function(n) {
  if (n === 1 || n === 2) return 1;
  return fibonacci(n-1)+fibonacci(n-2);
};

// Ex 5
var fiboSum = function(n, usarRecursao) {

  if (usarRecursao) {
    if (n === 1) return 1;
    return fibonacci(n, true) + fiboSum(n-1, true);
  }

  // IIFE
  // http://benalman.com/news/2010/11/immediately-invoked-function-expression/
  return (function(texto) {
    console.log(texto);
    var anterior = 0, atual = 1, soma = 0, prox;
    for (var i = 0; i < n; i++) {
      prox = anterior + atual;
      soma += atual;
      anterior = atual;
      atual = prox;
    }
    return soma;
  })('Teste');

};

// Ex 6
var queroCafe = function(mascada, precos) {
  precos.sort(function(a, b) {
    return a > b;
  });
  for (var i = precos.length - 1; precos[i] > mascada; i--) {
    precos.pop(precos[i]);
  }
  return precos.toString();
};

// Ex 7
function contarPorTipo (objeto, tipo) {

  // inspirado em http://stackoverflow.com/a/13467007/5194966
  function getType(v) {
    return v === null ? 'null' : typeof v !== 'undefined' && v.constructor === Array ? 'array' : typeof v;
  }

  var count = 0;
  for (var campo in objeto) {
    if (getType(objeto[campo]) === tipo) count++;
  }

  return count;
}

// Ex 8
// Variáveis globais:
var gohan = 'gohan', goku = 'Goku';
function revelarSaiyaman() {
  /*
    JavaScript faz hasteamento de variáveis (Hoisting, veja https://developer.mozilla.org/pt-BR/docs/Glossario/Hoisting),
    Ou seja, quando o interpretador carrega o script ele reorganiza o código
    deixando todas declarações de variáveis ANTES do restante do código.
    Portanto, o `var gohan` abaixo é hasteado para o início desta function, anulando a variável global e ficando undefined no console.log.
    Código após hasteamento:
      var gohan;
      console.log(gohan);
      goku = 'Son Goku';
      gohan = 'Son ' + gohan;
      return gohan;

    Poderíamos evitar o hasteamento se retornássemos direto e sem declarar variável local:

      console.log(gohan);
      goku = 'Son Goku';
      return 'Son ' + gohan;
  */
  console.log(gohan);
  // alterando variável global, alteração vai refletir após sair deste método.
  goku = 'Son Goku';
  var gohan = 'Son ' + gohan;
  return gohan;
}
console.log(revelarSaiyaman());
console.log(goku);
