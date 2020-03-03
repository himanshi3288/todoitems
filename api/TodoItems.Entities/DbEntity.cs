using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoItems.Entities
{
    public class DbEntity
    {
        [JsonProperty("Id")]
        public virtual Int64 Id { get; set; }

        [JsonProperty("IsDeleted")]
        public virtual bool IsDeleted { get; set; }

        [JsonProperty("CreatedDateUTC")]
        public virtual DateTime CreatedDateUTC { get; set; }

        [JsonProperty("UpdatedDateUTC")]
        public virtual DateTime? UpdatedDateUTC { get; set; }
    }
}
