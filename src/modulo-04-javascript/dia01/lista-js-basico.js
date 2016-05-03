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
  
  var calcularIterativo = function() {
    var anterior = 0, atual = 1, soma = 0, prox;
    for (var i = 0; i < n; i++) {
      prox = anterior + atual;
      soma += atual;
      anterior = atual;
      atual = prox;
    }
    return soma;
  };

  return calcularIterativo();

};

// Ex 6
var queroCafe = function(mascada, precos) {
  var precosValidos = [];
  for (var i = 0; i < precos.length; i++) {
    if (precos[i] <= mascada) precosValidos.push(precos[i]);
  }
  return precosValidos.sort().toString();
};

// Ex 7
function contarPorTipo(objeto, tipo) {
  var count = 0;
  for (var campo in objeto) {
    if ((typeof objeto[campo] === tipo) ||
      (tipo === 'null' && objeto[campo] === null) ||
      (tipo === 'array' && objeto[campo] && objeto[campo].constructor === Array)
    )
      count++;
  }
  return count;
};