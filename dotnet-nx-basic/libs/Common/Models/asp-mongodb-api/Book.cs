using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.Models.asp_mongodb_api
{
  public class Book
  {
    [BsonId]
    [BsonRepresentation(BsonType.Int64)]
    public long Id { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? BookId { get; set; } = Guid.NewGuid().ToString();

    [BsonElement("Name")]
    public string BookName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;
  }
}