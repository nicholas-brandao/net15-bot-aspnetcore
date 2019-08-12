using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Model
{
    public class UsuarioDatabaseSettings : IUsuariostoreDatabaseSettings
    {
        public string UsuarioCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUsuariostoreDatabaseSettings
    {
        string UsuarioCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
