using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Admin.PageSubscriberDashboard.Models;
using Admin.PageSubscriberDashboard.Repository;

namespace Admin.PageSubscriberDashboard.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class PageSubscriberDashboardController : Controller
    {
        private readonly IPageSubscriberDashboardRepository _PageSubscriberDashboardRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public PageSubscriberDashboardController(IPageSubscriberDashboardRepository PageSubscriberDashboardRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _PageSubscriberDashboardRepository = PageSubscriberDashboardRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.PageSubscriberDashboard> Get(string moduleid)
        {
            return _PageSubscriberDashboardRepository.GetPageSubscriberDashboards(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.PageSubscriberDashboard Get(int id)
        {
            Models.PageSubscriberDashboard PageSubscriberDashboard = _PageSubscriberDashboardRepository.GetPageSubscriberDashboard(id);
            if (PageSubscriberDashboard != null && PageSubscriberDashboard.ModuleId != _entityId)
            {
                PageSubscriberDashboard = null;
            }
            return PageSubscriberDashboard;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.PageSubscriberDashboard Post([FromBody] Models.PageSubscriberDashboard PageSubscriberDashboard)
        {
            if (ModelState.IsValid && PageSubscriberDashboard.ModuleId == _entityId)
            {
                PageSubscriberDashboard = _PageSubscriberDashboardRepository.AddPageSubscriberDashboard(PageSubscriberDashboard);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "PageSubscriberDashboard Added {PageSubscriberDashboard}", PageSubscriberDashboard);
            }
            return PageSubscriberDashboard;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.PageSubscriberDashboard Put(int id, [FromBody] Models.PageSubscriberDashboard PageSubscriberDashboard)
        {
            if (ModelState.IsValid && PageSubscriberDashboard.ModuleId == _entityId)
            {
                PageSubscriberDashboard = _PageSubscriberDashboardRepository.UpdatePageSubscriberDashboard(PageSubscriberDashboard);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "PageSubscriberDashboard Updated {PageSubscriberDashboard}", PageSubscriberDashboard);
            }
            return PageSubscriberDashboard;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.PageSubscriberDashboard PageSubscriberDashboard = _PageSubscriberDashboardRepository.GetPageSubscriberDashboard(id);
            if (PageSubscriberDashboard != null && PageSubscriberDashboard.ModuleId == _entityId)
            {
                _PageSubscriberDashboardRepository.DeletePageSubscriberDashboard(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "PageSubscriberDashboard Deleted {PageSubscriberDashboardId}", id);
            }
        }
    }
}
