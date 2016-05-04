'use strict';

function Elfo(nome, flechas) {
  this.nome = nome;
  this.flechas = flechas || 42;
}

Elfo.prototype.atirarFlecha = function() {
  this.flechas--;
};

// Uso:
// var elfo = new Elfo('Legolas', 55);
// elfo.atirarFlecha();
