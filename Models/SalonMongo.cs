using MongoDB.Bson.Serialization.Attributes;

public class SalonMongo {
[BsonId]
[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
public string? Id { get; set; }    
    public string Edificio {get; set;} = string.Empty;
    public string Nombre {get; set;} = string.Empty;
    public string Uso {get; set;} = string.Empty;

    public decimal Largo { get; set; }
    public decimal Ancho { get; set; }
    public decimal Capacidad { get; set; } 
}