using EpisodeWebservice.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpisodeWebservice.BL
{
    public class IShowManager
    {
        public interface iShowManager
        {
            ShowList GetShows(RootObject inputPayload);
            
        }
    }
}