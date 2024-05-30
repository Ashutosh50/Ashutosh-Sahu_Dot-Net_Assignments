using Newtonsoft.Json;

namespace Assignment__3__Library_.Entity
{
    public class IssueEntity
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

        [JsonProperty(PropertyName = "bookid", NullValueHandling = NullValueHandling.Ignore)]
        public string BookId { get; set; }

        [JsonProperty(PropertyName = "memberid", NullValueHandling = NullValueHandling.Ignore)]
        public string MemberId { get; set; }

        [JsonProperty(PropertyName = "issuedate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime IssueDate { get; set; }

        [JsonProperty(PropertyName = "returndate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ReturnDate { get; set; }

        [JsonProperty(PropertyName = "isreturned", NullValueHandling = NullValueHandling.Ignore)]
        public bool isReturned { get; set; }

    }
}
