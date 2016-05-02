'use strict';

var hello = 'Hello World';
console.log(hello);

var goku = {
  nome: 'Son Goku',
  classe: 'Saiyajin',
  ki: 999500,
  kamehameha: function() {
    var vd = document.getElementById('videoKame');
    var partes = [ 'Ka', 'Me', 'Ha', 'Me', 'Haaa!!!' ];
    var indice = 0;
    vd.style.display = 'block';
    vd.play();
    var id = setInterval(function() {  
      if (indice === partes.length - 1) {
        clearInterval(id);
      }
      document.body.appendChild(document.createTextNode(partes[indice++]));
    }, 1400);
  }
};