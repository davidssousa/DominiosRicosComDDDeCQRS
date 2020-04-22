using System;
using NerdStore.Core.DomainObjects;
using NerdStore.Core.Interfaces;

namespace NerdStore.Catalogo.Domain.Entities
{
    public class Produto: Entity, IAggregateRoot
    {

        public bool      Ativo { get; private set; }    
        public DateTime  DataCadastro { get; private set; }    
        public string    Descricao { get; private set; }    
        public string    Imagem { get; private set; }    
        public string    Nome { get; private set; }    
        public int       QuantidadeEstoque { get; private set; }    
        public decimal   Valor { get; private set; }    

        public Guid      CategoriaId { get; private set; }    
        public Categoria Categoria { get; private set; }    

        public Produto(bool ativo, DateTime dataCadastro, string descricao, string imagem, string nome, decimal valor, Guid categoriaId)
        {
            Ativo = ativo;
            DataCadastro = dataCadastro;
            Descricao = descricao;
            Imagem = imagem;
            Nome = nome;
            Valor = valor;
            CategoriaId = categoriaId;

            Validar();
        }

        public void Validar() 
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo nome do produto não pode estar vazio");
            AssertionConcern.ValidarSeVazio(Descricao, "O campo descrição do produto não pode estar vazio");
            AssertionConcern.ValidarSeVazio(Imagem, "O campo imagem do produto não pode estar vazio");
            AssertionConcern.ValidarSeDiferente(CategoriaId, Guid.Empty, "O campo categoria do produto não pode estar vazio");
            AssertionConcern.ValidarSeMenorOuIgualMinimo(Valor, 0, "O campo valor do produto não pode ser menor ou igual a 0");
        }

        public void Ativar() => this.Ativo = true;
        public void Desativar() => this.Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            AssertionConcern.ValidarSeVazio(Descricao, "O campo descrição não pode estar vazio");
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade) 
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente!");
            QuantidadeEstoque -= quantidade; 
        }

        public void ReporEstoque(int quantidade) 
        {
            QuantidadeEstoque += quantidade; 
        }

        public bool PossuiEstoque(int quantidade) 
        {
            return QuantidadeEstoque >= quantidade; 
        }

    }
}