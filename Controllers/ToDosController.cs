using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Livecoding.API.Domain.Models;
using Livecoding.API.Domain.Services;
using Livecoding.API.Resources;
using Livecoding.API.Extensions;

namespace Livecoding.API.Controllers
{
  [Route("/api/[controller]")]
  public class ToDosController : Controller
  {
    private readonly IToDoService _todoService;
    private readonly IMapper _mapper;

    public ToDosController(IToDoService todoService, IMapper mapper)
    {
      _todoService = todoService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ToDoResource>> GetAllAsync()
    {
      var todos = await _todoService.ListAsync();
      var resources = _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoResource>>(todos);

      return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveToDoResource resource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState.GetErrorMessages());

      var todo = _mapper.Map<SaveToDoResource, ToDo>(resource);
      var result = await _todoService.SaveAsync(todo);

      if (!result.Success)
        return BadRequest(result.Message);

      var todoResource = _mapper.Map<ToDo, ToDoResource>(result.ToDo);
      return Ok(todoResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveToDoResource resource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState.GetErrorMessages());

      var todo = _mapper.Map<SaveToDoResource, ToDo>(resource);
      var result = await _todoService.UpdateAsync(id, todo);

      if (!result.Success)
        return BadRequest(result.Message);

      var todoResource = _mapper.Map<ToDo, ToDoResource>(result.ToDo);
      return Ok(todoResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
      var result = await _todoService.DeleteAsync(id);

      if (!result.Success)
        return BadRequest(result.Message);

      var todoResource = _mapper.Map<ToDo, ToDoResource>(result.ToDo);
      return Ok(todoResource);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetToDoById(int id)
    {
      var result = await _todoService.GetToDoById(id);

      if (!result.Success)
        return BadRequest(result.Message);

      var todoResource = _mapper.Map<ToDo, ToDoResource>(result.ToDo);
      return Ok(todoResource);
    }
  }
}