using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpisodeWebservice.DTO.ViewModels
{
    public class ShowList
    {
        public ShowList()
        {
            response = new List<Reponse>();
        }
        public IEnumerable<Reponse> response { get; set; }
    }
}