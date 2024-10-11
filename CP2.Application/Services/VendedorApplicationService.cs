﻿using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public VendedorEntity? EditarDadosVendedor(int id, IVendedorDto vendedorDto)
        {
            vendedorDto.Validate();

            var vendedorExistente = _repository.ObterPorId(id);
            if (vendedorExistente == null) return null;

            vendedorExistente.Nome = vendedorDto.Nome;
            vendedorExistente.Email = vendedorDto.Email;
            vendedorExistente.Telefone = vendedorDto.Telefone;
            vendedorExistente.DataNascimento = vendedorDto.DataNascimento;
            vendedorExistente.Endereco = vendedorDto.Endereco;
            vendedorExistente.DataContratacao = vendedorDto.DataContratacao;
            vendedorExistente.ComissaoPercentual = vendedorDto.ComissaoPercentual;
            vendedorExistente.MetaMensal = vendedorDto.MetaMensal;

            return _repository.Atualizar(vendedorExistente);
        }

        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public IEnumerable<VendedorEntity> ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public VendedorEntity? SalvarDadosVendedor(IVendedorDto vendedorDto)
        {
            vendedorDto.Validate();

            var vendedor = new VendedorEntity
            {
                Nome = vendedorDto.Nome,
                Email = vendedorDto.Email,
                Telefone = vendedorDto.Telefone,
                DataNascimento = vendedorDto.DataNascimento,
                Endereco = vendedorDto.Endereco,
                DataContratacao = vendedorDto.DataContratacao,
                ComissaoPercentual = vendedorDto.ComissaoPercentual,
                MetaMensal = vendedorDto.MetaMensal,
                CriadoEm = DateTime.Now
            };

            return _repository.Adicionar(vendedor);
        }
    }
}
