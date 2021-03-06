﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lombiq.Hosting.DistributedEvents.Services;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Filters;

namespace Lombiq.Hosting.DistributedEvents.Filters
{
    [OrchardFeature("Lombiq.Hosting.DistributedEvents.ForegroundPollingEventRaising")]
    public class PollingEventRaisingFilter : FilterProvider, IResultFilter
    {
        private readonly IForegroundPolledEventRaiser _polledEventRaiser;


        public PollingEventRaisingFilter(IForegroundPolledEventRaiser polledEventRaiser)
        {
            _polledEventRaiser = polledEventRaiser;
        }


        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _polledEventRaiser.TryRaise(Constants.TimeSpanBetweenForegroundPolls);
        }
    }
}