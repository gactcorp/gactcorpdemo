using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MvcMongoDB01.Models
{
    public class Employee
    {
        //[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        //public string Id { get; set; }
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        [BsonRepresentation(BsonType.Double)]
        public decimal Salary { get; set; }
    }
}