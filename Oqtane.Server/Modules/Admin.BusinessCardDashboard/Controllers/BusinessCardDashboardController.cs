using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Admin.BusinessCardDashboard.Models;
using Admin.BusinessCardDashboard.Repository;

namespace Admin.BusinessCardDashboard.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class BusinessCardDashboardController : Controller
    {
        private readonly IBusinessCardDashboardRepository _BusinessCardDashboardRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public BusinessCardDashboardController(IBusinessCardDashboardRepository BusinessCardDashboardRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _BusinessCardDashboardRepository = BusinessCardDashboardRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.BusinessCardDashboard> Get(string moduleid)
        {
            return _BusinessCardDashboardRepository.GetBusinessCardDashboards(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.BusinessCardDashboard Get(int id)
        {
            Models.BusinessCardDashboard BusinessCardDashboard = _BusinessCardDashboardRepository.GetBusinessCardDashboard(id);
            if (BusinessCardDashboard != null && BusinessCardDashboard.ModuleId != _entityId)
            {
                BusinessCardDashboard = null;
            }
            return BusinessCardDashboard;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.BusinessCardDashboard Post([FromBody] Models.BusinessCardDashboard BusinessCardDashboard)
        {
            if (ModelState.IsValid && BusinessCardDashboard.ModuleId == _entityId)
            {
                BusinessCardDashboard = _BusinessCardDashboardRepository.AddBusinessCardDashboard(BusinessCardDashboard);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "BusinessCardDashboard Added {BusinessCardDashboard}", BusinessCardDashboard);
            }
            return BusinessCardDashboard;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.BusinessCardDashboard Put(int id, [FromBody] Models.BusinessCardDashboard BusinessCardDashboard)
        {
            if (ModelState.IsValid && BusinessCardDashboard.ModuleId == _entityId)
            {
                BusinessCardDashboard = _BusinessCardDashboardRepository.UpdateBusinessCardDashboard(BusinessCardDashboard);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "BusinessCardDashboard Updated {BusinessCardDashboard}", BusinessCardDashboard);
            }
            return BusinessCardDashboard;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.BusinessCardDashboard BusinessCardDashboard = _BusinessCardDashboardRepository.GetBusinessCardDashboard(id);
            if (BusinessCardDashboard != null && BusinessCardDashboard.ModuleId == _entityId)
            {
                _BusinessCardDashboardRepository.DeleteBusinessCardDashboard(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "BusinessCardDashboard Deleted {BusinessCardDashboardId}", id);
            }
        }
    }
}
