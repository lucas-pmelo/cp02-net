using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Obtém todos os dados dos fornecedores.
        /// </summary>
        /// <returns>Uma lista de fornecedores.</returns>
        [HttpGet]
        [Produces<IEnumerable<FornecedorEntity>>]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosFornecedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Obtém os dados de um fornecedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do fornecedor.</param>
        /// <returns>Os dados do fornecedor correspondente.</returns>
        [HttpGet("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterFornecedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Salva os dados de um novo fornecedor.
        /// </summary>
        /// <param name="entity">Dados do fornecedor a ser salvo.</param>
        /// <returns>Os dados do fornecedor salvo.</returns>
        [HttpPost]
        [Produces<FornecedorEntity>]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosFornecedor(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possível salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Edita os dados de um fornecedor existente.
        /// </summary>
        /// <param name="id">ID do fornecedor a ser editado.</param>
        /// <param name="entity">Dados atualizados do fornecedor.</param>
        /// <returns>Os dados do fornecedor atualizado.</returns>
        [HttpPut("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosFornecedor(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possível salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Deleta um fornecedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do fornecedor a ser deletado.</param>
        /// <returns>Os dados do fornecedor deletado.</returns>
        [HttpDelete("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosFornecedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível deletar os dados");
        }
    }
}
