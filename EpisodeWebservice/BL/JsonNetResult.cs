using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EpisodeWebservice.BL
{
           public class JsonNetResult : ActionResult
        {
            public Encoding ContentEncoding { get; set; }

            public string ContentType { get; set; }

            public bool Translate { get; set; }

            public object Data { get; set; }

            public JsonRequestBehavior JsonRequestBehavior { get; set; }

            public JsonSerializerSettings SerializerSettings { get; set; }

            public Formatting Formatting { get; set; }

            public int ResponseStatusCode { get; set; }

            public JsonNetResult(object data)
                : this(data, (int)HttpStatusCode.OK, JsonRequestBehavior.DenyGet, null, Formatting.None)
            {
            }

            public JsonNetResult(object data, HttpStatusCode responseStatusCode)
                : this(data, (int)responseStatusCode, JsonRequestBehavior.DenyGet, null, Formatting.None)
            {
            }

            public JsonNetResult(object data, JsonRequestBehavior jsonRequestBehavior)
                : this(data, (int)HttpStatusCode.OK, jsonRequestBehavior, null, Formatting.None)
            {
            }

            public JsonNetResult(object data, HttpStatusCode responseStatusCode, JsonRequestBehavior jsonRequestBehavior)
                : this(data, (int)responseStatusCode, jsonRequestBehavior, null, Formatting.None)
            {
            }

            public JsonNetResult(object data, int responseStatusCode, JsonRequestBehavior jsonRequestBehavior, JsonSerializerSettings jsonSerializerSettings, Formatting formatting)
            {
                Data = data;
                ResponseStatusCode = responseStatusCode;
                JsonRequestBehavior = jsonRequestBehavior;
                SerializerSettings = jsonSerializerSettings ?? new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                Formatting = formatting;
                Translate = true;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
                }

                var response = context.HttpContext.Response;

                response.StatusCode = ResponseStatusCode;

                response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
                if (ContentEncoding != null)
                {
                    response.ContentEncoding = ContentEncoding;
                }

                if (Data == null)
                    return;

                var writer = new JsonTextWriter(response.Output) { Formatting = Formatting };
                var serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }
    }

