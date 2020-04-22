
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Entities
{
    public class Categoria : Entity
    {
        public int    Codigo { get; set; }       
        public string Nome { get; set; }       

        public Categoria(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;

            Validar();
        }

        public void Validar()
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo Nome nao pode estar vazio");
            AssertionConcern.ValidarSeIgual(Codigo, 0, "O campo Codigo nao pode ser igual a 0");
        }

    }
}