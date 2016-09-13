using EpisodeWebservice.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using static EpisodeWebservice.BL.IShowManager;

namespace EpisodeWebservice.BL
{
    public class ShowManager: iShowManager
    {
        iShowManager _iShowManager;
        /*future implementation of IOC container*/
        public ShowManager(iShowManager iShowManager)
        {
            _iShowManager = iShowManager;
        }
        public ShowManager()
        {
            //_iShowManager = iShowManager;
        }

        /*Handles the logic of payload filtering*/
        public ShowList GetShows(RootObject inputPayLoad)
        {
            if (inputPayLoad.payload == null)
                return new ShowList();
          
           var results = inputPayLoad.payload.Where(x => x.drm == true && x.episodeCount > 0).Select(
                g => new Reponse() {
                    Image = g.image.showImage,
                    Slug =g.slug,
                    Title = g.title
            });
            var showList = new ShowList
            {
                response = results
            };
            return showList;
        }
       }



    
}