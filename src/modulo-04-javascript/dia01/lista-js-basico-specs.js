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