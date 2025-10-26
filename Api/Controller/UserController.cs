using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _contextUser;

        public UserController(IUserService userService)
        {
            _contextUser = userService;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<RegistroDto>> RegistroUser(RegistroDto registroDto)
        {
            var result = await _contextUser.AddData(registroDto);
            if (!result.Sucesso)
            {
                return BadRequest(new { sucesso = false, mensagem = result.Mensagem });
            }
            
            return Ok(result);
        }
        [HttpPost("Login")]

        public async Task<ActionResult<LoginResponseDto>> Login(LoginDto loginDto)
        {
            var result = await _contextUser.Login(loginDto);
            if (!result.Sucesso)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Painel")]
        public IActionResult Dashboard()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var userName = User.Claims.FirstOrDefault(c => c.Type == "userName")?.Value;
            var classifica = User.Claims.FirstOrDefault(c => c.Type == "classifica")?.Value;
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            return Ok(new
            {
                sucesso = true,
                dados = new
                {
                    userId,
                    name,
                    userName,
                    email,
                    classifica

                }
            });
        }



    }
}