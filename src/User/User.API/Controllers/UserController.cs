using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using User.API.Entities;
using User.API.Repositories;

namespace User.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Users>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var products = await _repository.GetUsers();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")] // setting parameter length to 24 charactors and setting a name to this method because we can redirect request from one to another by calling this custom routename
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Users>> GetUserById(string id)
        {
            var product = await _repository.GetUser(id);

            if (product == null)
            {
                _logger.LogError($"Product With Id: {id}, not found in current Contwxt.");
                return NotFound();
            }

            return Ok(product);
        }

        [Route("[action]/{nic}")] // url comes like api/v1/catalog/GetProductByCategory/ we have to pass category name in here
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Users>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Users>>> GetUserByNic(string nic) // route name and pareameter must be same otherwise it won't match the value that we are passing
        {
            var products = await _repository.GetUserByNic(nic);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Users>> CreateUser([FromBody] Users user) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            await _repository.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser([FromBody] Users user) //we are expecting http request and inside of request we expect product body and .net core will auto convert jason to object
        {
            return Ok(await _repository.Update(user));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            return Ok(await _repository.Delete(id));
        }

    }
}
