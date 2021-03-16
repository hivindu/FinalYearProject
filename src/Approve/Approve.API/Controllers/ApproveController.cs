using Approve.API.Entites;
using Approve.API.Respository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Approve.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApproveController : ControllerBase
    {
        private readonly IApproveRepository _repository;
        private readonly ILogger<ApproveController> _logger;

        public ApproveController(IApproveRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Approval>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Approval>>> GetApproval()
        {
            var products = await _repository.GetApproval();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetApproval")] // setting parameter length to 24 charactors and setting a name to this method because we can redirect request from one to another by calling this custom routename
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Approval), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Approval>> GetApprovalById(string id)
        {
            var product = await _repository.GetApproval(id);

            if (product == null)
            {
                _logger.LogError($"Approval With Id: {id}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(product);
        }

        [Route("[action]/{uid}")] // url comes like api/v1/Issue/GetIssueByAdminArea/ we have to pass area in here
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Approval>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Approval>>> GetApprovalByUserId(string uid) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var issues = await _repository.GetApprovalByUserId(uid);

            if (issues == null)
            {
                _logger.LogError($"Approvals under this user id : {uid}, not found in current Contwxt.");
                return NotFound();
            }
            return Ok(issues);
        }

        [Route("[action]/{uid}/{iid}")] // url comes like api/v1/catalog/GetProductByCategory/ we have to pass category name in here
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Approval>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Approval>>> GetApprovalByIds(string uid, string iid) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var issues = await _repository.GetApprovalbyIds(uid, iid);

            if (issues == null)
            {
                _logger.LogError($"Approvals With user id: {uid} with issue id: {iid}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(issues);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Approval), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Approval>> CreateApproval([FromBody] Approval approval) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            await _repository.Create(approval);

            return CreatedAtRoute("GetApproval", new { id = approval.Id }, approval);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Approval), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateApproval([FromBody] Approval approval) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            return Ok(await _repository.Update(approval));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Approval), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteApproval(string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
