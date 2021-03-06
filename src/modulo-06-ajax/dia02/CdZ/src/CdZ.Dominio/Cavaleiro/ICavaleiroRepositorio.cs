﻿using System.Collections.Generic;

namespace CdZ.Dominio
{
    public interface ICavaleiroRepositorio
    {
        int Adicionar(Cavaleiro cavaleiro);
        Cavaleiro Buscar(int id);
        IEnumerable<Cavaleiro> Todos(int tamanhoPagina, int pagina);
        void Excluir(int id);
        void Atualizar(Cavaleiro cavaleiro);
        int TotalCavaleiros();
    }
}
