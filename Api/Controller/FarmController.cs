using Core.DTOs;
using Core.DTOs.farm;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmController : ControllerBase
    {
        private readonly IFarmService _farmService;

        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }

        [Authorize]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarFazenda([FromBody] FarmModellDto dto)
        {
            var result = await _farmService.AddData(dto);

            if (!result.Sucesso)
                return BadRequest(new { message = result.Mensagem });

            return Ok(new
            {
                message = result.Mensagem,
                result.Dados
            });
        }

        [Authorize]
        [HttpGet("GetFazendas")]
        public async Task<ActionResult> GetMyFarms()
        {
            var result = await _farmService.GetAll();
            if (!result.Sucesso)
            {
                return BadRequest(new { message = result.Mensagem });
            }

            return Ok(new
            {
                message = result.Mensagem,
                result.Dados,

            });
        }
       

    }
}
