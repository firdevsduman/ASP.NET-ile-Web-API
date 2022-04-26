
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace iknow_project;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("urun_adi")]
    public string? urun_adi { get; set; }

    [BsonElement("urun_agirlik")]
    public int urun_agirlik { get; set; }

    [BsonElement("urun_adedi")]
    public int urun_adedi { get; set; } 
}