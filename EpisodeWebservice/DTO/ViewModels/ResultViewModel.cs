using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpisodeWebservice.DTO.ViewModels
{
    public class ResultViewModel
    {        
        public string Error { get; set; }
        
    }
    public class ResultViewModel<T> : ResultViewModel
    {
        public T Content { get; set; }
    }

}
