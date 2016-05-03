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

describe('Ex 2. maiorTexto', function() {
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