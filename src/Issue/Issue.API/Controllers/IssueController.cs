using Issue.API.Entities;
using Issue.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Issue.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueRepository _repository;
        private readonly ILogger<IssueController> _logger;

        public IssueController(IIssueRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Issues>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Issues>>> GetIssues()
        {
            var issues = await _repository.GetIssues();
            return Ok(issues);
        }

        [HttpGet("{id:length(24)}", Name = "GetIssue")] // setting parameter length to 24 charactors and setting a name to this method because we can redirect request from one to another by calling this custom routename
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Issues), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Issues>> GetUserById(string id)
        {
            var issue = await _repository.GetIssue(id);

            if (issue == null)
            {
                _logger.LogError($"Issue With Id: {id}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(issue);
        }

        [Route("[action]/{area}")] // url comes like api/v1/Issue/GetIssueByAdminArea/ we have to pass area in here
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Issues>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Issues>>> GetIssueByAdminArea(string area) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var issues = await _repository.GetIssueByAdminArea(area);

            if (issues == null)
            {
                _logger.LogError($"Issues With Administrative Area: {area}, not found in current Contwxt.");
                return NotFound();
            }
            return Ok(issues);
        }

        [Route("[action]/{date}")] // url comes like api/v1/catalog/GetProductByCategory/ we have to pass category name in here
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Issues>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Issues>>> GetIssueByDate(string date) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var issues = await _repository.GetIssueByDate(date);

            if (issues == null)
            {
                _logger.LogError($"Issues With date: {date}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(issues);
        }

        [Route("[action]/{road}")] // url comes like api/v1/catalog/GetProductByCategory/ we have to pass category name in here
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Issues>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Issues>>> GetIssueByRoad(string road) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var issues = await _repository.GetIssueByRoad(road);

            if (issues == null)
            {
                _logger.LogError($"Issues With road type: {road}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(issues);
        }

        [Route("[action]/{type}/{area}")] // url comes like api/v1/catalog/GetProductByCategory/ we have to pass category name in here
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Issues>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Issues>>> GetIssueByType(int type, string area) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var issues = await _repository.GetIssuebyType(type,area);

            if (issues == null)
            {
                _logger.LogError($"Issues With type id: {type} in administrative area: {area}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(issues);
        }

        [Route("[action]/{area}")] 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Issues>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Issues>>> GetApprovedIssuesByAdminArea(string area) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var issues = await _repository.GetApprovedIssuesByAdminArea(area);

            if (issues == null)
            {
                _logger.LogError($"Issues With  administrative area: {area}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(issues);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Issues), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Issues>> CreateUser([FromBody] Issues issue) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            await _repository.Create(issue);

            return CreatedAtRoute("GetIssue", new { id = issue.Id }, issue);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Issues), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser([FromBody] Issues issue) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            return Ok(await _repository.Update(issue));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Issues), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            return Ok(await _repository.Delete(id));
        }

    }
}
