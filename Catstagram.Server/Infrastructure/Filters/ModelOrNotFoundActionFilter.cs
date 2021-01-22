﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.Server.Infrastructure.Filters
{
    public class ModelOrNotFoundActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Result is  ObjectResult result)
            {
                var model = result.Value;

                if (model is null)
                    context.Result = new NotFoundResult();
            }

        }
    }
}
