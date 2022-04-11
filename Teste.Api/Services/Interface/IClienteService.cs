using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Teste.Api.Data;
using Teste.Api.Data.Repository.Entity;
using Teste.Api.Enumerator;
using Teste.Api.Enumerator.v1;
using Teste.Api.Models.v1.Request;

namespace Teste.Api.Services.Interface
{
    public interface IClienteService
    {
        Task<ClientesEntity> GetById(int id);
        Task<IEnumerable<ClientesEntity>> GetByNameStartWith(string name);
        Task<IEnumerable<ClientesEntity>> GetAll();
        Task<int> Insert(ClienteModels clienteModels);
        Task<int> Update(ClienteModels clienteModels);
        Task<int> Delete(int id);
    }
}
