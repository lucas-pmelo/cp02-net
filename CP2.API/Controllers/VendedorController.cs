using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;   
        }

        /// <summary>
        /// Obtém todos os dados dos vendedores.
        /// </summary>
        /// <returns>Uma lista de vendedores.</returns>
        [HttpGet]
        [Produces<IEnumerable<VendedorEntity>>]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosVendedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Obtém os dados de um vendedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do vendedor.</param>
        /// <returns>Os dados do vendedor correspondente.</returns>
        [HttpGet("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterVendedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Salva os dados de um novo vendedor.
        /// </summary>
        /// <param name="entity">Dados do vendedor a ser salvo.</param>
        /// <returns>Os dados do vendedor salvo.</returns>
        [HttpPost]
        [Produces<VendedorEntity>]
        public IActionResult Post([FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosVendedor(entity);

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
        /// Edita os dados de um vendedor existente.
        /// </summary>
        /// <param name="id">ID do vendedor a ser editado.</param>
        /// <param name="entity">Dados atualizados do vendedor.</param>
        /// <returns>Os dados do vendedor atualizado.</returns>
        [HttpPut("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult Put(int id, [FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosVendedor(id, entity);

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
        /// Deleta um vendedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do vendedor a ser deletado.</param>
        /// <returns>Os dados do vendedor deletado.</returns>
        [HttpDelete("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosVendedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível deletar os dados");
        }
    }
}
