using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Api.Data.Repository.Entity;

namespace Teste.Api.Data.Repository.Interface
{
    public interface IClientesRepository
    {
        Task<ClientesEntity> GetByID(int id);
    }
}
