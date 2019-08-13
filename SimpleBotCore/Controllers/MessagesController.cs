using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using SimpleBotCore.Logic;
using SimpleBotCore.Model;
using SimpleBotCore.Services;

namespace SimpleBotCore.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        SimpleBotUser _bot = new SimpleBotUser();


        public static int contador = 1;
        private readonly IUsuarioService _usuarioService;

        public MessagesController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        // POST api/messages
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Activity activity)
        {
            if (activity != null && activity.Type == ActivityTypes.Message)
            {
                await HandleActivityAsync(activity);
            }

            // HTTP 202
            return Accepted();
        }

        // Estabelece comunicacao entre o usuario e o SimpleBotUser
        async Task HandleActivityAsync(Activity activity)
        {
            string text = activity.Text;
            string userFromId = activity.From.Id;
            string userFromName = activity.From.Name;

            Usuario usuario = new Usuario(userFromId, userFromName, text);

            string response = _usuarioService.Create(usuario, contador);
            contador++;

            await ReplyUserAsync(activity, response);
        }

        // Responde mensagens usando o Bot Framework Connector
        async Task ReplyUserAsync(Activity message, string text)
        {
            var connector = new ConnectorClient(new Uri(message.ServiceUrl));
            var reply = message.CreateReply(text);

            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
}
