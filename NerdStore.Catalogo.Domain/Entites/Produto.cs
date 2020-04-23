using System;
using NerdStore.Core.DomainObjects;
using NerdStore.Core.Interfaces;

namespace NerdStore.Catalogo.Domain.Entities
{
    public class Produto: Entity, IAggregateRoot
    {

        public bool      Ativo { get; private set; }    
        public Guid      CategoriaId { get; private set; }    
        public DateTime  DataCadastro { get; private set; }    
        public string    Descricao { get; private set; }    
        public string    Imagem { get; private set; }    
        public string    Nome { get; private set; }    
        public int       QuantidadeEstoque { get; private set; }    
        public decimal   Valor { get; private set; }    

        public Dimensoes Dimensoes { get; private set; }    
        public Categoria Categoria { get; private set; }    
        
        protected Produto() {}

        public Produto(bool ativo, DateTime dataCadastro, string descricao, string imagem, string nome, decimal valor, Guid categoriaId, Dimensoes dimensoes)
        {
            Ativo = ativo;
            DataCadastro = dataCadastro;
            Descricao = descricao;
            Dimensoes = dimensoes;
            Imagem = imagem;
            Nome = nome;
            Valor = valor;
            CategoriaId = categoriaId;

            Validar();
        }

        public void Validar() 
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
            AssertionConcern.ValidarSeVazio(Descricao, "O campo Descrição do produto não pode estar vazio");
            AssertionConcern.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");
            AssertionConcern.ValidarSeMenorOuIgualMinimo(Valor, 0, "O campo Valor do produto não pode ser menor ou igual a 0");
            AssertionConcern.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo Categoria do produto não pode estar vazio");
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