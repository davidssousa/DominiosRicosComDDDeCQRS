
using System;
using Xunit;
using NerdStore.Core.DomainObjects;
using NerdStore.Catalogo.Domain.Entities;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act & Assert
            var ex = new DomainException();
            var CategoriaId = Guid.NewGuid();

            ex = Assert.Throws<DomainException>( () => 
                    new Produto(true, DateTime.Now, string.Empty, "Imagem do Produto", "Nome do Produto", 100, CategoriaId, 
                    new Dimensoes(100, 100, 100)
                )
            );
            Assert.Equal("O campo Descrição do produto não pode estar vazio", ex.Message);


            ex = Assert.Throws<DomainException>( () => 
                    new Produto(true, DateTime.Now, "Descricao do Produto", "Imagem do Produto", string.Empty, 100, CategoriaId, 
                    new Dimensoes(100, 100, 100)
                )
            );
            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>( () => 
                    new Produto(true, DateTime.Now, "Descricao do Produto", "Imagem do Produto", "Nome do Produto", 0, CategoriaId, 
                    new Dimensoes(100, 100, 100)
                )
            );
            Assert.Equal("O campo Valor do produto não pode ser menor ou igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>( () => 
                    new Produto(true, DateTime.Now, "Descricao do Produto", "Imagem do Produto", "Nome do Produto", 100, Guid.Empty, 
                    new Dimensoes(100, 100, 100)
                )
            );
            Assert.Equal("O campo Categoria do produto não pode estar vazio", ex.Message);

            
        }
    }
}
