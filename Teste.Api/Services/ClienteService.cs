using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Teste.Api.Data;
using Teste.Api.Data.Repository.Entity;
using Teste.Api.Models.v1.Request;
using Teste.Api.Options;
using Teste.Api.Services.Interface;

namespace Teste.Api.Services
{
    public class ClienteService : IClienteService
    {
        private ClientesRepository Repository { get; set; }
        private IConfiguration _config;
        public ClienteService(IConfiguration config)
        {
            _config = config;
            var Options = _config.GetSection(TesteApiOptions.Key).Get<TesteApiOptions>();
            IDbConnection cnn = new SqlConnection(Options.ConnectionString);
            Repository = new ClientesRepository(cnn);
            
        }
        public async Task<int> Delete(int id)
        {
            return await Repository.Delete(id);
        }

        public async Task<IEnumerable<ClientesEntity>> GetAll()
        {
            return await Repository.GetAll();
        }

        public async Task<ClientesEntity> GetById(int id)
        {
            return await Repository.GetByID(id);
        }

        public async Task<IEnumerable<ClientesEntity>> GetByNameStartWith(string name)
        {
            return await Repository.GetByNameStartWith(name);
        }

        public async Task<int> Insert(ClienteModels clienteModels)
        {
            ClientesEntity clientesEntity = new ClientesEntity();
            clientesEntity.Id = clienteModels.Id;
            clientesEntity.Nome = clienteModels.Nome;
            clientesEntity.Sobrenome = clienteModels.Sobrenome;
            clientesEntity.CPF = clienteModels.CPF;
            clientesEntity.DataNasc = clienteModels.DataNasc;
            clientesEntity.Profissao = (int)clienteModels.Profissao;

            return await Repository.Insert(clientesEntity);
        }

        public async Task<int> Update(ClienteModels clienteModels)
        {
            ClientesEntity clientesEntity = new ClientesEntity();
            clientesEntity.Id = clienteModels.Id;
            clientesEntity.Nome = clienteModels.Nome;
            clientesEntity.Sobrenome = clienteModels.Sobrenome;
            clientesEntity.CPF = clienteModels.CPF;
            clientesEntity.DataNasc = clienteModels.DataNasc;
            clientesEntity.Profissao = (int)clienteModels.Profissao;

            return await Repository.Update(clientesEntity);
        }
    }
}
