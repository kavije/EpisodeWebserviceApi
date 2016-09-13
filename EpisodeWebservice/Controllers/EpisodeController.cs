using EpisodeWebservice.BL;
using EpisodeWebservice.DTO.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using static EpisodeWebservice.BL.IShowManager;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.IO;

namespace EpisodeWebservice.Controllers
{
    [ApiExceptionHandling]
    public class EpisodeController : Controller
    {
        public iShowManager _ShowManager;
        public EpisodeController() : base()
        { }

        //future implementation of ioc container with unity
        public EpisodeController(ShowManager ShowManager)

        { _ShowManager = ShowManager; }

        /*This function accepts the posted payload for data manupulation*/
        [System.Web.Http.HttpPost]
        public JsonNetResult GetShowsWithDrm(RootObject inputPayload)
        {
            iShowManager sh = new ShowManager();
            var shows = sh.GetShows(inputPayload);
            return new JsonNetResult(shows, JsonRequestBehavior.AllowGet);
        }
    }
}

   
