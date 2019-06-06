using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {

        private static MongoClient conn = new MongoClient("mongodb://localhost:27017");
        private static IMongoDatabase db = conn.GetDatabase("15net");

        public string Reply(SimpleMessage message)
        {
            Salvar(message);
            return $"{message.User} disse '{message.Text}' ({RetornaNumeroMensagensEnviadas(message.Id)} mensagens enviadas)";
        }

        void Salvar(SimpleMessage message)
        {
            #region Desafio 1
            var col = db.GetCollection<BsonDocument>("colMensagens");

            var doc = new BsonDocument() {
                                           { "Id", message.Id },
                                           { "Usuario", message.User },
                                           { "Mensagem", message.Text }
                                         };
            col.InsertOne(doc);
            #endregion

            #region Desafio 2
            var colContMensagensEnviadas = db.GetCollection<BsonDocument>("colMensagensEnviadas");

            var cont = colContMensagensEnviadas.Find(new BsonDocument() {
                                                                          { "Id", message.Id }
                                                                         }).ToList();

            var docContMensagem = new BsonDocument() {
                                           { "Id", message.Id },
                                           { "Cont", cont.Count+1 }
                                         };
            colContMensagensEnviadas.InsertOne(docContMensagem);
            #endregion
        }

        private string RetornaNumeroMensagensEnviadas(string idUsuario)
        {
            return db.GetCollection<BsonDocument>("colMensagensEnviadas").Find(new BsonDocument() {
                                                                          { "Id", idUsuario }
                                                                         }).ToList().Count().ToString();
        }
    }
}