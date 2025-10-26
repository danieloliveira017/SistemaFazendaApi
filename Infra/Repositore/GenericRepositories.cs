using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infra.Repositore
{
    public class GenericRepositories<T> : IGenericRepositorie<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepositories(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<ServiceResponse<T>> AddData(T data)
        {
            var response = new ServiceResponse<T>();
            try
            {
                _context.Set<T>().Add(data);
                await _context.SaveChangesAsync();
                response.Dados = data;
                response.Sucesso = true;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<T>>> DeletData(Guid id)
        {
            var response = new ServiceResponse<List<T>>();
            try
            {
                var dados = await _dbSet.FindAsync(id);
               
                if (dados == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "<--- Registro não encontrado --->";
                    return response;
                }

                _dbSet.Remove(dados);
                await _context.SaveChangesAsync();

                response.Sucesso = true;
                response.Dados = await _dbSet.ToListAsync();

                

            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<T>>> Getall()
        {
            var response = new ServiceResponse<List<T>>();
            try
            {
                var lista = await _dbSet.ToListAsync();
                response.Dados = lista;
                response.Sucesso = true;
            }catch(Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<T>> GetId(Guid id)
        {
            var response = new ServiceResponse<T>();
            try
            {
                var dados = await _dbSet.FindAsync(id);
                
                response.Sucesso = true;
                response.Dados = dados;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<T>>> UpdateData(T data)
        {
            var response = new ServiceResponse<List<T>>();
            try
            {
                var dados = _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                response.Sucesso = true;
                response.Dados = await _dbSet.ToListAsync();

            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }

            return response;
        }

     
       


    }
}