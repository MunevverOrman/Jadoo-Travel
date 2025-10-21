using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravel.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public string CityCountry { get; set; }
    }
}
