'use strict';

describe('Ex 1. Daisy Game!', function() {
  it('quando informa 4 retorna \'Love me not\'', function() {
    expect(daisyGame(4)).toBe('Love me not');
  });
  it('quando informa 0 retorna \'Love me not\'', function() {
    expect(daisyGame(0)).toBe('Love me not');
  });
  it('quando informa 17 retorna \'Love me\'', function() {
    expect(daisyGame(17)).toBe('Love me');
  });
  it('quando informa undefined retorna \'Love me\'', function() {
    expect(daisyGame()).toBe('Love me');
  });
});

describe('Ex 2. Maior texto', function() {
  it('quando informa array vazio retorna vazio', function() {
    expect(maiorTexto([])).toBe('');
  });
  it('quando informa array com apenas um elemento retorna o mesmo', function() {
    expect(maiorTexto([ 'único' ])).toBe('único');
  });
  it('quando informa array com duas strings de mesmo tamanho retorna o primeiro', function() {
    expect(maiorTexto([ 'm3sm0', 'mesmo' ])).toBe('m3sm0');
  });
  it('quando informa array com duas strings diferentes', function() {
    expect(maiorTexto([ 'm3sm0', 'maior!!' ])).toBe('maior!!');
  });
  it('quando informa array com várias strings diferentes', function() {
    expect(maiorTexto([ 'm3sm0', 'abacate', 'goku', 'yajirobe', 'freeza', 'kuririn' ])).toBe('yajirobe');
  });
});

describe('Ex 3. Instrutor querido', function() {
  window.imprimeNoConsole = function(instrutor) {
   console.log('olá querido instrutor:', instrutor)
  }

  beforeEach(function() {
    spyOn(window, 'imprimeNoConsole');
  });

  it('quando informa função imprimir no console para todos instrutores', function() {
    // Arrange
    var instrutores = [ 'bernardo', 'nunes', 'fabrício', 'ben-hur', 'carlos' ];
    // Act
    imprime(instrutores, imprimeNoConsole);
    // Assert
    expect(imprimeNoConsole.calls.count()).toBe(5);
    instrutores.forEach(function(i) {
      expect(imprimeNoConsole).toHaveBeenCalledWith(i);  
    });
  });

  it('quando informa função imprimir no console para array vazio', function() {
    // Arrange
    var instrutores = [];
    // Act
    imprime(instrutores, imprimeNoConsole);
    // Assert
    expect(imprimeNoConsole.calls.count()).toBe(0);
  });

  it('quando informa função imprimir no console para um instrutor', function() {
    // Arrange
    var instrutores = [ 'bernardo' ];
    // Act
    imprime(instrutores, imprimeNoConsole);
    // Assert
    expect(imprimeNoConsole.calls.count()).toBe(1);
    expect(imprimeNoConsole).toHaveBeenCalledWith(instrutores[0]);
  });

  it('quando informa algo que não é função', function() {
    imprime([ 'bernardo' ], 3.14);
    expect(imprimeNoConsole.calls.count()).toBe(0);
  });

});

describe('Ex 4. Soma diferentona', function() {
  it('quando informa 3 e 4', function() {
    expect(adicionar(3)(4)).toBe(7);
  });
  it('quando informa 5642 e 8749', function() {
    expect(adicionar(5642)(8749)).toBe(14391);
  });
  it('quando informa 0 e 0', function() {
    expect(adicionar(0)(0)).toBe(0);
  });
  it('quando não informa parcela alguma', function() {
    expect(adicionar()()).toBeNaN();
  });
  it('quando não informa primeira parcela', function() {
    expect(adicionar()(1)).toBeNaN();
  });
  it('quando não informa segunda parcela', function() {
    expect(adicionar(1)()).toBeNaN();
  });
  it('quando informa -3 e 2.5', function() {
    expect(adicionar(-3)(2.5)).toBe(-0.5);
  });
});

describe('Ex 5. Fibona', function() {
  it('quando informa 1 = 1', function() {
    expect(fiboSum(1)).toBe(1);
  });
  it('quando informa 2 = 1+1', function() {
    expect(fiboSum(2)).toBe(2);
  });
  it('quando informa 3 = 1+1+2', function() {
    expect(fiboSum(3)).toBe(4);
  });
  it('quando informa 4 = 1+1+2+3', function() {
    expect(fiboSum(4)).toBe(7);
  });
  it('quando informa 5 = 1+1+2+3+5', function() {
    expect(fiboSum(5)).toBe(12);
  });
  it('quando informa 6 = 1+1+2+3+5+8', function() {
    expect(fiboSum(6)).toBe(20);
  });
  it('quando informa 7 = 1+1+2+3+5+8+13', function() {
    expect(fiboSum(7)).toBe(33);
  });
});