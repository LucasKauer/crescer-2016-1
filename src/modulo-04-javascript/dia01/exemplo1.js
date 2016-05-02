console.log('Outro Script!!!');
console.log(hello);

// var somar (a, b) => a + b
function somar(a, b) { return a + b; };
function verificaFuncao(fn) {
  return typeof fn === 'function';
}
var sub = function() {
  var a = arguments[0];
  var b = arguments[1];
  var fn = arguments[2];
  if (verificaFuncao(fn)) fn(a - b);
};
var imprimirResultado = function(res) {
  console.log('O resultado é: ', res);
};
var funcoes = [ somar(1, 1), sub ];
var subRef = funcoes[1];
subRef(3, 2, imprimirResultado);
