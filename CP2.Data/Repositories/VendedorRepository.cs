using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<VendedorEntity> ObterTodos()
        {
            return _context.Vendedor.ToList();
        }

        public VendedorEntity? ObterPorId(int id)
        {
            return _context.Vendedor.Find(id);
        }

        public VendedorEntity Adicionar(VendedorEntity vendedor)
        {
            _context.Vendedor.Add(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public VendedorEntity? Atualizar(VendedorEntity vendedor)
        {
            _context.Vendedor.Update(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            var vendedor = ObterPorId(id);
            if (vendedor != null)
            {
                _context.Vendedor.Remove(vendedor);
                _context.SaveChanges();
            }
            return vendedor;
        }
    }
}