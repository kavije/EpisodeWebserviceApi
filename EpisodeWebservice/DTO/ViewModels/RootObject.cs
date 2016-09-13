using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpisodeWebservice.DTO.ViewModels
{
    public class RootObject
    {
        public RootObject()
        {
            payload = new List<PayLoad>();
        }
        public List<PayLoad> payload { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public int totalRecords { get; set; }
    }
}