using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravel.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; } 
    }
}
