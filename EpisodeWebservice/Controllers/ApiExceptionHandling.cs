using EpisodeWebservice.BL;
using EpisodeWebservice.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EpisodeWebservice.Controllers
{
    public class ApiExceptionHandling:FilterAttribute, IExceptionFilter
    {
        /*handles exception*/
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonNetResult(
                new ResultViewModel
                {
                    Error = "Could not decode request: JSON parsing failed"
                },
                HttpStatusCode.BadRequest,
                JsonRequestBehavior.AllowGet);
        }

    }
}