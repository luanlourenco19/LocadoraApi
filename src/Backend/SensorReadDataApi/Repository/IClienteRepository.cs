using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraApi.Domain;

namespace LocadoraApi.Repository
{
    public interface IClienteRepository
    {
        public IEnumerable<Cliente> ListAll();

        public int Insert(Cliente data);

        public int Remove(int Id);
    }
}
