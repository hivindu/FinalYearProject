using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WorkAssign.API.Entities;
using WorkAssign.API.Repositories.Interfaces;

namespace WorkAssign.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkRepository _repository;
        private readonly ILogger<WorkController> _logger;

        public WorkController(IWorkRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Work>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Work>>> GetTasksList()
        {
            var tasks = await _repository.GetTaskList();
            return Ok(tasks);
        }

        [HttpGet("{id:length(24)}", Name = "GetTask")] // setting parameter length to 24 charactors and setting a name to this method because we can redirect request from one to another by calling this custom routename
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Work), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Work>> GetTaskList(string id)
        {
            var tasks = await _repository.GetTask(id);

            if (tasks == null)
            {
                _logger.LogError($"Task With Id: {id}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(tasks);
        }

        [Route("[action]/{date}")] // url comes like api/v1/catalog/GetProductByCategory/ we have to pass category name in here
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Work>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Work>>> GetTaskByDate(DateTime date) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var tasks = await _repository.GetTaskByDate(date);
            return Ok(tasks);
        }

        [Route("[action]/{Uid}")] // url comes like api/v1/catalog/GetProductByCategory/ we have to pass category name in here
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Work>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Work>>> GetTaskByUserId(string Uid) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var tasks = await _repository.GetTaskListByUid(Uid);

            if (tasks == null)
            {
                _logger.LogError($"Task With Id: {Uid}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(tasks);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Work), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Work>> AssignTask([FromBody] Work task) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            await _repository.Create(task);

            return CreatedAtRoute("GetTask", new { id = task.Id }, task);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Work), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTask([FromBody] Work task) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            return Ok(await _repository.Update(task));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Work), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteTask(string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
