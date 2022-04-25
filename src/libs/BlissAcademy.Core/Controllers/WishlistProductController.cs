﻿
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Filters;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Core.Security;
using BlissAcademy.Core.PublishedContent;
using MediatR;
using System.Threading;
using BlissAcademy.Core.Features;
using Microsoft.AspNetCore.Http;
using BlissAcademy.Core.Controllers;

namespace BlissAcademy.Core.Controllers
{
    public class WishlistProductController : SurfaceControllerBase
    {

        public WishlistProductController(IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            IMediator mediator)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider, mediator)
        {

        }

        [HttpPost]
        [ValidateUmbracoFormRouteString]
        public async Task<IActionResult> AddProduct(AddWishlistProduct.CommandRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var response = await Mediator.Send(request, cancellationToken);

            if (response.Status)
            {
                var queryString = QueryString.Create("success", "true");

                return RedirectToCurrentUmbracoPage(queryString);
            }

            return RedirectToCurrentUmbracoPage();
        }

        [HttpPost]
        [ValidateUmbracoFormRouteString]
        public async Task<IActionResult> RemoveProduct(RemoveWishlistProduct.CommandRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var response = await Mediator.Send(request, cancellationToken);

            if (response.Status)
            {
                var queryString = QueryString.Create("success", "true");

                return RedirectToCurrentUmbracoPage(queryString);
            }

            return RedirectToCurrentUmbracoPage();
        }
    }
}

