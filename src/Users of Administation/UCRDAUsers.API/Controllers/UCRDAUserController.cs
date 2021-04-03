using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UCRDAUsers.API.Entities;
using UCRDAUsers.API.Repository.Interface;

namespace UCRDAUsers.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UCRDAUserController : ControllerBase
    {
        private readonly IUCRDAUserRepository _repository;
        private readonly ILogger<UCRDAUserController> _logger;

        public UCRDAUserController(IUCRDAUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UCRDAUser>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UCRDAUser>>> GetUsers()
        {
            var users = await _repository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")] // setting parameter length to 24 charactors and setting a name to this method because we can redirect request from one to another by calling this custom routename
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UCRDAUser), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UCRDAUser>> GetUserById(string id)
        {
            var user = await _repository.GetUser(id);

            if (user == null)
            {
                _logger.LogError($"User With Id: {id}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("[action]/{nic}/{password}", Name = "GetUser")] // setting parameter length to 24 charactors and setting a name to this method because we can redirect request from one to another by calling this custom routename
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UCRDAUser), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UCRDAUser>> GetUserById(string nic,string password)
        {
            var user = await _repository.GetUserByCredentials(nic,password);

            if (user == null)
            {
                _logger.LogError($"User With this credential not found in current Contwxt.");
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UCRDAUser), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UCRDAUser>> CreateUser([FromBody] UCRDAUser user) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            await _repository.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UCRDAUser), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UCRDAUser user) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            return Ok(await _repository.Update(user));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(UCRDAUser), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
