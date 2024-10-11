using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        IEnumerable<FornecedorEntity> ObterTodos();
        FornecedorEntity? ObterPorId(int id);
        FornecedorEntity Adicionar(FornecedorEntity fornecedor);
        FornecedorEntity? Atualizar(FornecedorEntity fornecedor);
        FornecedorEntity? DeletarDados(int id);
    }
}