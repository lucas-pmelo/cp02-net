using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            return _context.Fornecedor.ToList();
        }

        public FornecedorEntity? ObterPorId(int id)
        {
            return _context.Fornecedor.Find(id);
        }

        public FornecedorEntity Adicionar(FornecedorEntity fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public FornecedorEntity? Atualizar(FornecedorEntity fornecedor)
        {
            if (!_context.Fornecedor.Any(f => f.Id == fornecedor.Id))
            {
                return null;
            }

            _context.Entry(fornecedor).State = EntityState.Modified;
            _context.SaveChanges();
            return fornecedor;
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return null;
            }

            _context.Fornecedor.Remove(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }
    }
}
