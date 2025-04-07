namespace WorkerService.Infrastructure;

using System;
using WorkerService.Domain;

public class PedidoService : IPedidoService{

    private IPedidoRepository _pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository){
        _pedidoRepository = pedidoRepository;
    }
/*
* Method to simulate an Order processing
*/
    public async Task ProcessaPedidosAsync(){
        IEnumerable<Pedido>? pedidosAProcessar = await _pedidoRepository.GetAllAsync()!;
        foreach (Pedido pedido in pedidosAProcessar)
        {
            if((string.Compare(pedido.Status!.Status, "Pendente", false)) == 0){
                pedido.Status!.Status = "Processado";
                pedido.DataUltimoStatus = DateTime.Now;
                await _pedidoRepository.UpdateAsync(pedido);
            }
        }
    }

    public async Task GeraNovoPedidoTesteAsync() {
        Pedido _pedido = new Pedido {
            Id = Guid.NewGuid(),
            Pessoa = new Pessoa{ Id = new Guid(), Nome = "Primeira Pessoa", Sobrenome = "Teste", DataNascimento = new DateTime(1990, 12, 18), Sexo = "M" },
            Items = new List<PedidoItem>{
                new PedidoItem{ Id = new Guid(), Item = new Produto { Id = new Guid(), Nome = "Prduto Teste 1", Descricao = "Descricao do produto Teste 1"}, Quantidade = 5},
                new PedidoItem{ Id = new Guid(), Item = new Produto { Id = new Guid(), Nome = "Prduto Teste 2", Descricao = "Descricao do produto Teste 2"}, Quantidade = 1},
                new PedidoItem{ Id = new Guid(), Item = new Produto { Id = new Guid(), Nome = "Prduto Teste 3", Descricao = "Descricao do produto Teste 3"}, Quantidade = 4}
            },
            Status = new StatusPedido { Id = new Guid(), Status = "Pendente", Descricao = "Pendente de processamento" },
            DataCriacao = DateTime.Now,
            DataUltimoStatus = DateTime.Now
        };
        await _pedidoRepository.AddAsync(_pedido);
    }
}