using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Repository
{
    public interface IRepository<T>
    {

        List<T> Get();
        T Get(string id);
        string Create(T usuario, int contador);
        void Update(string id, T usuarioIn);
        void Remove(T usuarioIn);
        void Remove(string id);
    }
}
