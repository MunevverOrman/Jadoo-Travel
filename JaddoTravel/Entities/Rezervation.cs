using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace JadooTravel.Entities
{
    public class Rezervation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RezervationId { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }


    }
}
