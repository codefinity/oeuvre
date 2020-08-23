using Domaina.CQRS.Command;
using Oeuvre.Modules.ContentCreation.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Application.CreateNewArticle
{
    public class CreateNewArticleCommand : CommandBase<Guid>
    {
        public CreateNewArticleCommand(string topic,
                                        string body)
        {
            Topic = topic;
            Body = body;
        }

        public string Topic { get; }
        public string Body { get; }

    }
}
