using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointTrii.Response
{
    public class EpisodeResponse
    {
        public Info info { get; set; }
        public List<Result> results { get; set; }
    }

    public class Info
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string next { get; set; }
        public object prev { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public string name { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public List<string> characters { get; set; }
        public string url { get; set; }
        public DateTime created { get; set; }
    }
}
