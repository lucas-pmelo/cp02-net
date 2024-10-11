using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        IEnumerable<VendedorEntity> ObterTodos();
        VendedorEntity? ObterPorId(int id);
        VendedorEntity Adicionar(VendedorEntity vendedor);
        VendedorEntity? Atualizar(VendedorEntity vendedor);
        VendedorEntity? DeletarDados(int id);
    }
}
