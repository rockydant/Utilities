using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Admin.QRCodeGenerator.Models;
using Admin.QRCodeGenerator.Repository;

namespace Admin.QRCodeGenerator.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class QRCodeGeneratorController : Controller
    {
        private readonly IQRCodeGeneratorRepository _QRCodeGeneratorRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public QRCodeGeneratorController(IQRCodeGeneratorRepository QRCodeGeneratorRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _QRCodeGeneratorRepository = QRCodeGeneratorRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.QRCodeGenerator> Get(string moduleid)
        {
            return _QRCodeGeneratorRepository.GetQRCodeGenerators(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.QRCodeGenerator Get(int id)
        {
            Models.QRCodeGenerator QRCodeGenerator = _QRCodeGeneratorRepository.GetQRCodeGenerator(id);
            if (QRCodeGenerator != null && QRCodeGenerator.ModuleId != _entityId)
            {
                QRCodeGenerator = null;
            }
            return QRCodeGenerator;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.QRCodeGenerator Post([FromBody] Models.QRCodeGenerator QRCodeGenerator)
        {
            if (ModelState.IsValid && QRCodeGenerator.ModuleId == _entityId)
            {
                QRCodeGenerator = _QRCodeGeneratorRepository.AddQRCodeGenerator(QRCodeGenerator);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "QRCodeGenerator Added {QRCodeGenerator}", QRCodeGenerator);
            }
            return QRCodeGenerator;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.QRCodeGenerator Put(int id, [FromBody] Models.QRCodeGenerator QRCodeGenerator)
        {
            if (ModelState.IsValid && QRCodeGenerator.ModuleId == _entityId)
            {
                QRCodeGenerator = _QRCodeGeneratorRepository.UpdateQRCodeGenerator(QRCodeGenerator);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "QRCodeGenerator Updated {QRCodeGenerator}", QRCodeGenerator);
            }
            return QRCodeGenerator;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.QRCodeGenerator QRCodeGenerator = _QRCodeGeneratorRepository.GetQRCodeGenerator(id);
            if (QRCodeGenerator != null && QRCodeGenerator.ModuleId == _entityId)
            {
                _QRCodeGeneratorRepository.DeleteQRCodeGenerator(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "QRCodeGenerator Deleted {QRCodeGeneratorId}", id);
            }
        }
    }
}
