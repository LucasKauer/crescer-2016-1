'use strict';

describe('Ex 1. Doadores de sangue', function() {
  it('obterDoadores retorna Aiolia, Aiolos e Afrodite', function() {
    var doadores = JSON.parse('[{"id":5,"nome":"Aiolia","dataNascimento":"1967-08-16T03:00:00.000Z","alturaCm":185,"pesoLb":187.392923,"signo":"Leão","tipoSanguineo":"O","localNascimento":"Grécia","localTreinamento":"Santuário, Grécia","golpes":["Cápsula do Poder","Pata do Leão","Relâmpago de Plasma"],"imagens":[{"url":"https://cloud.githubusercontent.com/assets/526075/14900613/c4ba42f0-0d67-11e6-9c0e-e79c2278ab0b.png","isThumb":true}]},{"id":9,"nome":"Aiolos","dataNascimento":"1960-11-30T03:00:00.000Z","alturaCm":187,"pesoLb":187.392923,"signo":"Sagitário","tipoSanguineo":"O","localNascimento":"Grécia","localTreinamento":"Santuário, Grécia","golpes":["Trovão Atômico","Flecha da Justiça"],"imagens":[{"url":"https://cloud.githubusercontent.com/assets/526075/14901061/e5fe3b90-0d69-11e6-9a78-2449055be1fa.png","isThumb":true}]},{"id":12,"nome":"Afrodite","dataNascimento":"1965-03-10T03:00:00.000Z","alturaCm":183,"pesoLb":158.732829,"signo":"Peixes","tipoSanguineo":"O","localNascimento":"Suécia","localTreinamento":"Groelândia","golpes":["Rosas Diabólicas Reais","Rosas Piranhas","Rosa Branca"],"imagens":[{"url":"https://cloud.githubusercontent.com/assets/526075/14901259/f4a0b3ca-0d6a-11e6-89b1-59855cabc43d.png","isThumb":true}]}]');
    expect(doadores).toEqual(obterDoadores());
  });
});

describe('Ex 2. Canivete suíço', function() {
  it('obterCavaleiroComMaisGolpes retorna Shaka', function() {
    console.log(JSON.stringify(goldSaints[5]));
    var cavaleiroComMaisGolpes = JSON.parse('{"id":6,"nome":"Shaka","dataNascimento":"1967-09-19T03:00:00.000Z","alturaCm":182,"pesoLb":149.914338,"signo":"Virgem","tipoSanguineo":"AB","localNascimento":"Índia","localTreinamento":"Ganges, Índia","golpes":["Rendição Divina","Ciclo das 6 Existências","Tesouro do Céu","Invocação dos Espíritos","Ohm!","Kahn!"],"imagens":[{"url":"https://cloud.githubusercontent.com/assets/526075/14900695/4a5675dc-0d68-11e6-8396-2a775a2b0c39.png","isThumb":true}]}');
    expect(cavaleiroComMaisGolpes).toEqual(obterCavaleiroComMaisGolpes());
  });
});

describe('Ex 3. Aniversários', function() {
  it('obterMesesComMaisAniversarios retorna Março, Maio e Novembro', function() {
    var esperado = [ 'Março', 'Maio', 'Novembro' ];
    expect(esperado).toEqual(obterMesesComMaisAniversarios());
  });
});

describe('Ex 4. Altura média', function() {
  it('obterAlturaMedia retorna 1.86', function() {
    expect(1.86).toEqual(obterAlturaMedia());
  });
});

describe('Ex 5. Altura mediana', function() {
  it('obterAlturaMediana retorna 1.76', function() {
    expect(1.76).toEqual(obterAlturaMediana());
  });
});

describe('Ex 6a. Peso médio', function() {
  it('obterPesoMedio retorna 84.27', function() {
    expect(84.27).toEqual(obterPesoMedio());
  });
});

describe('Ex 6b. Peso médio doadores', function() {
  it('obterPesoMedioDoadores retorna 80.67', function() {
    expect(80.67).toEqual(obterPesoMedioDoadores());
  });
});

describe('Ex 7. IMC', function() {
  it('obterIMC retorna todos IMC dos cavaleiros com pesos definidos', function() {
    var imcs = [ 22.64, 29.48, 24.62, 24.22, 24.84, 20.53, 24.54, 24.31, 23.99, 22.45, 21.5 ];
    expect(imcs).toEqual(obterIMC());
  });
});

describe('Ex 8. Sobrepeso', function() {
  it('obterSobrepeso retorna array com Aldebaran apenas', function() {
    var aldebaran = JSON.parse('{"id":2,"nome":"Aldebaran","dataNascimento":"1967-05-08T03:00:00.000Z","alturaCm":210,"pesoLb":286.600941,"signo":"Touro","tipoSanguineo":"B","localNascimento":"Brasil","localTreinamento":"Brasil","golpes":["Grande Chifre"],"imagens":[{"url":"https://cloud.githubusercontent.com/assets/526075/14900419/dca83616-0d66-11e6-9757-8d07311e6999.png","isThumb":true}]}');
    expect([ aldebaran ]).toEqual(obterSobrepeso());
  });
});