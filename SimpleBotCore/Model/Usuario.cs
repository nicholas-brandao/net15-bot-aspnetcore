using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBotCore.Model
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Text")]
        public string Text { get; set; }
        public Usuario(string id, string username, string text)
        {
            this.Id = id;
            this.Username = username;
            this.Text = text;
        }
    }
}