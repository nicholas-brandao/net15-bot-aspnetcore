using MongoDB.Driver;
using SimpleBotCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Repository
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository(IUsuariostoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuarios = database.GetCollection<Usuario>(settings.UsuarioCollectionName);
        }


        public List<Usuario> Get() =>
            _usuarios.Find(book => true).ToList();

        public Usuario Get(string id) =>
            _usuarios.Find<Usuario>(usuario => usuario.Id == id).FirstOrDefault();

        public string Create(Usuario usuario, int contador)
        {
            _usuarios.InsertOne(usuario);

            return $"{usuario.Username} disse na mensagem {contador}: '{usuario.Text}' "; ;
        }

        public void Update(string id, Usuario usuarioIn) =>
            _usuarios.ReplaceOne(x => x.Id == id, usuarioIn);

        public void Remove(Usuario usuarioIn) =>
            _usuarios.DeleteOne(x => x.Id == usuarioIn.Id);

        public void Remove(string id) =>
            _usuarios.DeleteOne(x => x.Id == id);
    }


}
