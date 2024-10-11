using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity? EditarDadosFornecedor(int id, IFornecedorDto fornecedor)
        {
            var fornecedorExistente = _repository.ObterPorId(id);
            if (fornecedorExistente == null) return null;

            fornecedorExistente.Nome = fornecedor.Nome;
            fornecedorExistente.CNPJ = fornecedor.CNPJ;
            fornecedorExistente.Endereco = fornecedor.Endereco;
            fornecedorExistente.Telefone = fornecedor.Telefone;
            fornecedorExistente.Email = fornecedor.Email;

            return _repository.Atualizar(fornecedorExistente);
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public FornecedorEntity? SalvarDadosFornecedor(IFornecedorDto fornecedor)
        {
            var novoFornecedor = new FornecedorEntity
            {
                Nome = fornecedor.Nome,
                CNPJ = fornecedor.CNPJ,
                Endereco = fornecedor.Endereco,
                Telefone = fornecedor.Telefone,
                Email = fornecedor.Email,
                CriadoEm = DateTime.Now
            };
            return _repository.Adicionar(novoFornecedor);
        }
    }
}