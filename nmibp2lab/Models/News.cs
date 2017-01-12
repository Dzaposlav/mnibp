using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nmibp2lab.Mongo;
using System.ComponentModel.DataAnnotations;

namespace nmibp2lab.Models
{
    public class News : MongoEntity
    {
        public string title { get; set; }
        [DataType(DataType.MultilineText)]
        public string text { get; set; }
        public string author { get; set; }
        public byte[] image { get; set; }
        public List<string> comments { get; set; }

    }


}