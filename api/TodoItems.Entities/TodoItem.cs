using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoItems.Entities
{
    public class TodoItem : DbEntity
    {
        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("UserId")]
        public long UserId { get; set; }
    }
}
