using LocadoraApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraApi.Repository
{
    public interface IFilmeRepository
    {
        public IEnumerable<Filme> ListAll();

        public int InsertFilme(Filme data);

        public int RemoveFilme(int Id);
    }
}
