using AutoMapper;
using IG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Core.Identity;
using ToDoList.Server.Dtos;
using ToDoList.Server.Exeptions;
using ToDoList.Server.Extensions;

namespace ToDoList.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController: Controller
    {
        private IMapper _mapper;
        private IRepo<ToDo> _repository;
        private ILogger<ToDoController> _logger;
        private UserManager<User> _manager;

        public ToDoController(UserManager<User> manager,IMapper mapper,IRepo<ToDo> repository,ILogger<ToDoController> logger)
        {
            _mapper = mapper;
            _repository = repository;
           _logger = logger;
            _manager = manager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody]CreateToDo createToDo)
        {

           var userId= HttpContext.GetUserId();

            var todo = _mapper.Map<ToDo>(createToDo);

            

            todo.UserId=userId;

           var thetodo= await  _repository.Add(todo);


            return Created("ToDo",thetodo);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddRangeAsync([FromBody]IEnumerable<CreateToDo> createToDo,int userId)
        //{

        //    var todos = createToDo.Select(t=>_mapper.Map<ToDo>(t));


        //    todos.Select(s=>s.Id=userId);

        //    await _repository.AddRangeAsync(todos);


        //    return Created("ToDo",todos);
        //}


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(ReadToDo updateteToDo)
        {

            if(updateteToDo.Id<=0)
            {
                throw new ArgumentNullException();

            }

            var theToDo=_mapper.Map<ToDo>(updateteToDo);

            await _repository.Update(theToDo);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            if(Id<=0)
            {
                throw new ArgumentNullException();
            }


            if(await _repository.GetById(Id)==null)
            {
                throw new ToDoNotFoundException($"Todo with id {Id} was not fount");

            }

            await _repository.Remove(Id);


            return NoContent();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsync()
        {

            return Ok(await _repository.GetByQueryAsync());

        }

        [HttpGet("Get By Id : {Id}")]
        public async Task<IActionResult> DetailsAsync(int? Id)
        {

            if (Id == null)
                throw new ArgumentNullException();

            var Todo=await _repository.GetById((int)Id);


            return Ok(Todo);

        }
    }
}
