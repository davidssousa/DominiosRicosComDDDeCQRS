using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NerdStore.Core.Interfaces;
using NerdStore.Catalogo.Domain.Entities;

namespace NerdStore.Catalogo.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();        
        Task<Produto> ObterPorId(Guid id);        
        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);        
        Task<IEnumerable<Produto>> ObterCategorias();        

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);

        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);

    }
}
