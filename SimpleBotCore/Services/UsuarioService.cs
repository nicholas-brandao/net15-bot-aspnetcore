using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBotCore.Model;
using SimpleBotCore.Repository;

namespace SimpleBotCore.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) => _usuarioRepository = usuarioRepository;

        public List<Usuario> Get() => _usuarioRepository.Get();

        public Usuario Get(string id) => _usuarioRepository.Get(id);

        public string Create(Usuario usuario, int contador)
        {
            _usuarioRepository.Create(usuario, contador);

            return $"{usuario.Username} disse na mensagem {contador}: '{usuario.Text}' ";
        }

        public void Update(string id, Usuario usuarioIn) => _usuarioRepository.Update(id, usuarioIn);

        public void Remove(Usuario usuarioIn) => _usuarioRepository.Remove(usuarioIn);

        public void Remove(string id) => _usuarioRepository.Remove(id);
    }
}
