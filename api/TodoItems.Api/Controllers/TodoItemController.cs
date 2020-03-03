using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoItems.Domain;
using TodoItems.Entities;

namespace TodoItems.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class TodoItemController : ControllerBase
    {
        private readonly IDomainHandler<TodoItem> _DomainHandler;
        public TodoItemController(IDomainHandler<TodoItem> domainHandler)
        {
            _DomainHandler = domainHandler;
            //UserId = 
        }


        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _DomainHandler.GetAsync();
        }


        [HttpPost]
        public async Task<TodoItem> Post([FromBody] TodoItem item)
        {
            
            var userId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == Utilities.ConfigurationManager.UserIdClaimKey).Value);
            item.UserId = userId;
            return await _DomainHandler.AddAsync(item);
        }

        [HttpPut]
        public async Task<TodoItem> Put([FromBody] TodoItem item)
        {
            return await _DomainHandler.UpdateAsync(item);
        }


        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _DomainHandler.DeleteAsync(id);
        }
    }
}