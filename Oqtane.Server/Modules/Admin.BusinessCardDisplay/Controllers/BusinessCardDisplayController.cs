using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Admin.BusinessCardDisplay.Models;
using Admin.BusinessCardDisplay.Repository;

namespace Admin.BusinessCardDisplay.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class BusinessCardDisplayController : Controller
    {
        private readonly IBusinessCardDisplayRepository _BusinessCardDisplayRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public BusinessCardDisplayController(IBusinessCardDisplayRepository BusinessCardDisplayRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _BusinessCardDisplayRepository = BusinessCardDisplayRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.BusinessCardDisplay> Get(string moduleid)
        {
            return _BusinessCardDisplayRepository.GetBusinessCardDisplays(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.BusinessCardDisplay Get(int id)
        {
            Models.BusinessCardDisplay BusinessCardDisplay = _BusinessCardDisplayRepository.GetBusinessCardDisplay(id);
            if (BusinessCardDisplay != null && BusinessCardDisplay.ModuleId != _entityId)
            {
                BusinessCardDisplay = null;
            }
            return BusinessCardDisplay;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.BusinessCardDisplay Post([FromBody] Models.BusinessCardDisplay BusinessCardDisplay)
        {
            if (ModelState.IsValid && BusinessCardDisplay.ModuleId == _entityId)
            {
                BusinessCardDisplay = _BusinessCardDisplayRepository.AddBusinessCardDisplay(BusinessCardDisplay);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "BusinessCardDisplay Added {BusinessCardDisplay}", BusinessCardDisplay);
            }
            return BusinessCardDisplay;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.BusinessCardDisplay Put(int id, [FromBody] Models.BusinessCardDisplay BusinessCardDisplay)
        {
            if (ModelState.IsValid && BusinessCardDisplay.ModuleId == _entityId)
            {
                BusinessCardDisplay = _BusinessCardDisplayRepository.UpdateBusinessCardDisplay(BusinessCardDisplay);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "BusinessCardDisplay Updated {BusinessCardDisplay}", BusinessCardDisplay);
            }
            return BusinessCardDisplay;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.BusinessCardDisplay BusinessCardDisplay = _BusinessCardDisplayRepository.GetBusinessCardDisplay(id);
            if (BusinessCardDisplay != null && BusinessCardDisplay.ModuleId == _entityId)
            {
                _BusinessCardDisplayRepository.DeleteBusinessCardDisplay(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "BusinessCardDisplay Deleted {BusinessCardDisplayId}", id);
            }
        }
    }
}
