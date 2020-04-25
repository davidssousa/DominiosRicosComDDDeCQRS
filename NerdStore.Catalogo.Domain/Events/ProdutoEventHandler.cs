
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NerdStore.Catalogo.Domain.Interfaces;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            // TODO: Enviar email, Colocar nume fila, manipular mensagem, etc ...
        }
    }
}