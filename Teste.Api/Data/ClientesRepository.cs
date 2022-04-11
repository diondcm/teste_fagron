using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Teste.Api.Data.Repository;
using Dapper;
using Teste.Api.Data.Repository.Interface;
using Teste.Api.Data.Repository.Entity;

namespace Teste.Api.Data
{
    public class ClientesRepository : IClientesRepository
    {
        public IDbConnection Connection { get; set; }
        public ClientesRepository(IDbConnection conn)
        {
            Connection = conn;
        }
        public async Task<IEnumerable<ClientesEntity>> GetAll()
        {
            try
            {
                return await Connection.QueryAsync<ClientesEntity>("SELECT * FROM Clientes", new { });
            }
            catch (Exception ex)
            {
                //_logger.Log(ex);
                throw new Exception(ex.Message);
            }
        }
        public async Task<ClientesEntity> GetByID(int id)
        {
            try
            {
                return await Connection.QuerySingleAsync<ClientesEntity>("SELECT * FROM Clientes WHERE ID = @id", new { id });
            }
            catch (Exception ex)
            {
                //_logger.Log(ex);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ClientesEntity>> GetByNameStartWith(string name)
        {
            try
            {
                return await Connection.QueryAsync<ClientesEntity>($"SELECT * FROM Clientes WHERE Nome like '{name}%'", new { });
            }
            catch (Exception ex)
            {
                //_logger.Log(ex);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ClientesEntity>> GetByFirstNameEquals(string name)
        {
            try
            {
                return await Connection.QueryAsync<ClientesEntity>("SELECT * FROM Clientes WHERE Nome = @name", new { name });
            }
            catch (Exception ex)
            {
                //_logger.Log(ex);
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> Insert(ClientesEntity ClientesEntity)
        {
            try
            {
                return await Connection.ExecuteAsync(@"INSERT INTO [dbo].[Clientes]
                                                               ([Nome]
                                                               ,[Sobrenome]
                                                               ,[CPF]
                                                               ,[DataNasc]
                                                               ,[Profissao])
                                                         VALUES
                                                               (@Nome,
                                                               ,@Sobrenome,
                                                               ,@CPF,
                                                               ,@DataNasc,
                                                               ,@Profissao)", new
                {
                    Nome = ClientesEntity.Nome,
                    Sobrenome = ClientesEntity.Sobrenome,
                    CPF = ClientesEntity.CPF,
                    DataNasc = ClientesEntity.DataNasc,
                    Profissao = ClientesEntity.Profissao,
                });
            }
            catch (Exception ex)
            {
                //_logger.Log(ex);
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> Update(ClientesEntity ClientesEntity)
        {
            try
            {
                return await Connection.ExecuteAsync(@"UPDATE [dbo].[Clientes]
                                                           SET [Nome] = @Nome
                                                              ,[Sobrenome] = @Sobrenome
                                                              ,[CPF] = @CPF
                                                              ,[DataNasc] = @DataNasc
                                                              ,[Profissao] = @Profissao
                                                         WHERE Id = @Id", new
                {
                    Id = ClientesEntity.Id,
                    Nome = ClientesEntity.Nome,
                    Sobrenome = ClientesEntity.Sobrenome,
                    CPF = ClientesEntity.CPF,
                    DataNasc = ClientesEntity.DataNasc,
                    Profissao = ClientesEntity.Profissao,
                });
            }
            catch (Exception ex)
            {
                //_logger.Log(ex);
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> Delete(int id)
        {
            try
            {
                return await Connection.ExecuteScalarAsync<int>(@"DELETE FROM Clientes
                                                                   WHERE Id = @Id", new { id });
            }
            catch (Exception ex)
            {
                //_logger.Log(ex);
                throw new Exception(ex.Message);
            }
        }

    }
}
