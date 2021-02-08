using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Admin.PageSubscriber.Models;
using Admin.PageSubscriber.Repository;

namespace Admin.PageSubscriber.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class PageSubscriberController : Controller
    {
        private readonly IPageSubscriberRepository _PageSubscriberRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public PageSubscriberController(IPageSubscriberRepository PageSubscriberRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _PageSubscriberRepository = PageSubscriberRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.PageSubscriber> Get(string moduleid)
        {
            return _PageSubscriberRepository.GetPageSubscribers(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.PageSubscriber Get(int id)
        {
            Models.PageSubscriber PageSubscriber = _PageSubscriberRepository.GetPageSubscriber(id);
            if (PageSubscriber != null && PageSubscriber.ModuleId != _entityId)
            {
                PageSubscriber = null;
            }
            return PageSubscriber;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.PageSubscriber Post([FromBody] Models.PageSubscriber PageSubscriber)
        {
            if (ModelState.IsValid && PageSubscriber.ModuleId == _entityId)
            {
                PageSubscriber = _PageSubscriberRepository.AddPageSubscriber(PageSubscriber);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "PageSubscriber Added {PageSubscriber}", PageSubscriber);
            }
            return PageSubscriber;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.PageSubscriber Put(int id, [FromBody] Models.PageSubscriber PageSubscriber)
        {
            if (ModelState.IsValid && PageSubscriber.ModuleId == _entityId)
            {
                PageSubscriber = _PageSubscriberRepository.UpdatePageSubscriber(PageSubscriber);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "PageSubscriber Updated {PageSubscriber}", PageSubscriber);
            }
            return PageSubscriber;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.PageSubscriber PageSubscriber = _PageSubscriberRepository.GetPageSubscriber(id);
            if (PageSubscriber != null && PageSubscriber.ModuleId == _entityId)
            {
                _PageSubscriberRepository.DeletePageSubscriber(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "PageSubscriber Deleted {PageSubscriberId}", id);
            }
        }
    }
}
