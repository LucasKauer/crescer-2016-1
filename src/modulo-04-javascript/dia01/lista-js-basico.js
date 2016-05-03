'use strict';

// Ex 1
function daisyGame(numero) {
  return numero % 2 === 0 ? 'Love me not' : 'Love me';
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
function adicionar(parcela1) {
  return function(parcela2) {
    return parcela1 + parcela2;
  }
};