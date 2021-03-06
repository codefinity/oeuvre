﻿using Domania.Security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oeuvre.Modules.ContentCreation.Application.Articles.CreateNewArticle;
using Oeuvre.Modules.ContentCreation.Application.Contracts;
using System;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.API.Controllers
{
    [Route("contentcreation/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IContentCreationModule contentCreationModule;

        public ArticlesController(IContentCreationModule contentCreationModule)
        {
            this.contentCreationModule = contentCreationModule;
        }

        [HttpPost("/contentcreation/createnew")]
        [Authorize]
        [HasPermission("CreateArticle")]
        public async Task<IActionResult> CreateNewArticle(CreateNewArticleRequest request)
        {

            try
            {
                await contentCreationModule.ExecuteCommandAsync(new CreateNewArticleCommand(
                                                                        request.Topic,
                                                                        request.Body));
            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok();
        }


    }
}
