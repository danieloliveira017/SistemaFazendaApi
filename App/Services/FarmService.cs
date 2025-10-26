using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core;
using Core.DTOs;
using Core.DTOs.farm;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace App.Services
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRespository _contextFarm;
        private readonly IUserFarmRepositorie _contextUserFarm;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _ContextHttp;

        public FarmService(
            IFarmRespository farm,
            IUserFarmRepositorie userFarm,
            IConfiguration configuration,
            IHttpContextAccessor httpContext
        )
        {
            _contextFarm = farm;
            _contextUserFarm = userFarm;
            _configuration = configuration;
            _ContextHttp = httpContext;

        }
        public async Task<ServiceResponse<UserFarmResultDto>> AddData(FarmModellDto dto)
        {
            var response = new ServiceResponse<UserFarmResultDto>();
            try
            {
                if (string.IsNullOrWhiteSpace(dto.NomeFazenda))
                {
                    response.Sucesso = false;
                    response.Mensagem = "<--- Campo do nome da fazenda e obrigatorio --->";
                    return response;
                }
                if (await _contextFarm.FarmExists(dto.NomeFazenda))
                {
                    response.Sucesso = false;
                    response.Mensagem = "<--- Ja existe o nome registrado para esssa fazenda --->";
                    return response;
                }
                //pegar o tokem
                var (userId, userName) = GetUserInfoToken();


                var newFarm = new FarmModell
                {
                    Id = Guid.NewGuid(),
                    Nome = dto.NomeFazenda,
                    AreaHectares = dto.AreaHectares,

                };

                await _contextFarm.AddData(newFarm);

                var userFarm = new UserFarmModell
                {
                    UserId = userId,
                    FarmId = newFarm.Id,
                    TipoAcesso = "Propetario",
                    DataVicuclo = DateTime.UtcNow,



                };

                await _contextUserFarm.AddData(userFarm);

                response.Sucesso = true;
                response.Mensagem = "<--- Fazenda cadastrada e vinculada ao usuario --->";
                response.Dados =
                    new UserFarmResultDto
                    {
                        Farmid = newFarm.Id,
                        NomeFazenda = newFarm.Nome,
                        UserId = userId,
                        NomeUser = userName,
                        TipoAcessp = userFarm.TipoAcesso,
                        DataVinculo = userFarm.DataVicuclo,

                    };


            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public Task<ServiceResponse<List<FarmModellDto>>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<UserFarmResponseDto>> GetAll()
        {
            var response = new ServiceResponse<UserFarmResponseDto>();
            try
            {

                var (userId, userName) = GetUserInfoToken();
                var farms = await _contextUserFarm.GetFarmsByIdUser(userId);
                if (farms == null || farms.UserFarms == null || farms.UserFarms.Count == 0)
                {
                    response.Sucesso = false;
                    response.Mensagem = "<--- Não tem fazenda cadastrada --->";
                    return response;
                }

                response.Sucesso = true;
                response.Mensagem = "<--- Fazendas Carregadas --->";
                response.Dados = new UserFarmResponseDto
                {
                    Nome = farms.Nome,
                    Email = farms.Email,
                    DateCadastro = farms.DateCadastro,
                    Classifica = farms.UserFarms.FirstOrDefault()?.TipoAcesso ?? "Nao defenido",
                    Fazendas = [.. farms.UserFarms.Select(uf=> new FarmModellDto{
                        Id = uf.FarmId,
                        NomeFazenda = uf.Farm != null ? uf.Farm.Nome: string.Empty,
                        AreaHectares = uf.Farm != null ? uf.Farm.AreaHectares : string.Empty,


                    })]
                };


            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }
            return response;
        }

        public Task<ServiceResponse<FarmModellDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FarmModellDto>>> UpadateData(FarmModellDto dto)
        {
            throw new NotImplementedException();
        }
        private (Guid userId, string UserName) GetUserInfoToken()
        {
            var htpp = _ContextHttp.HttpContext;
            var idString = htpp?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var nameString = htpp?.User?.FindFirst(ClaimTypes.Name)?.Value;

            if (!Guid.TryParse(idString, out Guid userId))
            {
                throw new Exception("Usuario nao encontrado");

            }
            return (userId, nameString ?? string.Empty);
        }

    }
}