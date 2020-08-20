using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.API.Controllers
{
    public class CreateNewArticleRequest
    {
        public string Topic { get; set; }
        public string Body { get; set; }

    }
}
