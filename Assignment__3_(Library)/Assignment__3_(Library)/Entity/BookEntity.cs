using Newtonsoft.Json;

namespace Assignment__3__Library_.Entity
{
    public class BookEntity
    {
        [JsonProperty(PropertyName = "uid", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "dtype", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "createdby", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdon", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Createdon { get; set; }

        [JsonProperty(PropertyName = "updatedby", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updatedon", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "archived", NullValueHandling = NullValueHandling.Ignore)]
        public bool Archived { get; set; }

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "publishdate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime PublishedDate { get; set; }

        [JsonProperty(PropertyName = "isbn", NullValueHandling = NullValueHandling.Ignore)]
        public string ISBN { get; set; }

        [JsonProperty(PropertyName = "isissued", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsIssued { get; set; }
    }
}
