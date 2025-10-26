using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Core;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Diagnostics.Metrics;

namespace App.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRespository _IUserRespositry;
        private readonly IConfiguration _configuration;



        public UserService(IUserRespository userRespository, IConfiguration configuration)
        {

            _IUserRespositry = userRespository;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<List<RegistroDto>>> AddData(RegistroDto data)
        {
            var response = new ServiceResponse<List<RegistroDto>>();
            try
            {
                if (string.IsNullOrWhiteSpace(data.UserName))
                {
                    response.Sucesso = false;
                    response.Mensagem = "<--- Campo user name e obrigario --->";
                    return response;
                }
                // evitar usuario duplicado
                if (await _IUserRespositry.UserExists(data.UserName))
                {
                    response.Sucesso = false;
                    response.Mensagem = "<--- Username ja existe --->";
                    return response;
                }

                // hash senha

                var hashPassword = BCrypt.Net.BCrypt.HashPassword(data.Password);
                var newUser = new UserModell
                {
                    UserName = data.UserName,
                    PasswordHash = hashPassword,
                    Nome = data.Nome,
                    Email = data.Email,
                    Classifica = data.Classifica,
                    DateCadastro = data.DateCadastro


                };

                var result = await _IUserRespositry.AddData(newUser);
                if (result.Sucesso)
                {
                    response.Sucesso = true;
                    response.Mensagem = "<--- Usuario cadastrado --->";
                    response.Dados = [
                        new RegistroDto{
                        UserName = newUser.UserName,
                        Nome = newUser.Nome,
                        Email = newUser.Email,
                        Classifica = newUser.Classifica,
                        DateCadastro = newUser.DateCadastro
                        }

                    ];
                }
                else
                {
                    response.Sucesso = false;
                    response.Mensagem = "<--- Erro ao cadastrar usuario --->";
                }


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public Task<ServiceResponse<List<RegistroDto>>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<RegistroDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<RegistroDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<RegistroDto>>> UpdateData(RegistroDto data)
        {
            throw new NotImplementedException();
        }

        async Task<ServiceResponse<LoginResponseDto>> IUserService.Login(LoginDto dto)
        {
            var response = new ServiceResponse<LoginResponseDto>();
            // buscar usuario
            var user = await _IUserRespositry.GetUserName(dto.UserName);
            if (user == null)
            {
                response.Sucesso = false;
                response.Mensagem = "<--- Usuario nao encontrado --->";
                return response;
            }

            // verificar a senha
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                response.Sucesso = false;
                response.Mensagem = "<--- Senha inválida --->";
                return response;
            }

            // gerar o tokem

            string token = GerarToken(user);

            token.AsSpan();


            response.Sucesso = true;
            response.Mensagem = "<--- Login realizado com sucesso --->";
            response.Dados = new LoginResponseDto
            {
                Token = token,
                Id = user.Id,
                UserName = user.UserName,
                Nome = user.Nome,
                Email = user.Email,
                Classifica = user.Classifica,
                Fazendas = [.. user.UserFarms.Select(F=> new FarmModellDto
            {
                 Id = F.FarmId,
                 NomeFazenda = F.Farm != null ? F.Farm.Nome: string.Empty,
                 AreaHectares = F.Farm !=null ? F.Farm.AreaHectares : string.Empty


                })]



            };
            return response;
        }

        private string GerarToken(UserModell user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Nome),
                new("userName", user.UserName ),
                new(ClaimTypes.Email, user.Email),
                new("classifica", user.Classifica),


            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokendescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );


            return new JwtSecurityTokenHandler().WriteToken(tokendescriptor);

        }
    }
}