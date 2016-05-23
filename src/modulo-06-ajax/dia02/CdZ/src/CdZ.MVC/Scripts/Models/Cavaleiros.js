'use strict';

function Cavaleiros(options) {
    options = options || {};
    this.urlGet = options.urlGet || '/Cavaleiro/Get';
    this.urlGetById = options.urlGetById || '/Cavaleiro/GetById';
    this.urlPost = options.urlPost || '/Cavaleiro/Post';
    this.urlDelete = options.urlDelete || '/Cavaleiro/Delete';
    this.urlPut = options.urlPut || '/Cavaleiro/Put';
};

Cavaleiros.prototype.todos = function (options) {
    options = options || {};
    return $.get({
        url: this.urlGet,
        data: { pagina: options.pagina },
        withoutSpinner: options.semSpinner
    });
};

Cavaleiros.prototype.buscar = function (idCavaleiro) {
    return $.get(this.urlGetById, { id: idCavaleiro })
};

Cavaleiros.prototype.inserir = function (cavaleiro) {
    return $.post(this.urlPost, cavaleiro);
};

Cavaleiros.prototype.excluir = function (idCavaleiro) {
    return $.ajax({
        url: this.urlDelete,
        type: 'DELETE',
        data: { id: idCavaleiro }
    });
};

Cavaleiros.prototype.editar = function (cavaleiro) {
    return $.ajax({
        url: this.urlPut,
        type: 'PUT',
        data: cavaleiro
    });
};