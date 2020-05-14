using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Livecoding.API.Domain.Models;
using Livecoding.API.Domain.Services;
using Livecoding.API.Domain.Repositories;
using Livecoding.API.Domain.Services.Communication;

namespace Livecoding.API.Services
{
  public class ToDoService : IToDoService
  {
    private readonly IToDoRepository _todoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ToDoService(IToDoRepository todoRepository, IUnitOfWork unitOfWork)
    {
      this._todoRepository = todoRepository;
      _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ToDo>> ListAsync()
    {
      return await _todoRepository.ListAsync();
    }

    public async Task<ToDoResponse> SaveAsync(ToDo todo)
    {
      try
      {
        await _todoRepository.AddAsync(todo);
        await _unitOfWork.CompleteAsync();

        return new ToDoResponse(todo);
      }
      catch (Exception ex)
      {
        // Do some logging stuff
        return new ToDoResponse($"An error occurred when saving the todo: {ex.Message}");
      }
    }

    public async Task<ToDoResponse> UpdateAsync(int id, ToDo todo)
    {
      var existingToDo = await _todoRepository.FindByIdAsync(id);

      if (existingToDo == null)
        return new ToDoResponse("ToDo not found.");

        existingToDo.Title = todo.Title;
        existingToDo.ExpiryDate = todo.ExpiryDate;
        existingToDo.Description = todo.Description;
        existingToDo.Complete = todo.Complete;

      try
      {
        _todoRepository.Update(existingToDo);
        await _unitOfWork.CompleteAsync();

        return new ToDoResponse(existingToDo);
      }
      catch (Exception ex)
      {
        // Do some logging stuff
        return new ToDoResponse($"An error occurred when updating the todo: {ex.Message}");
      }
    }

    public async Task<ToDoResponse> DeleteAsync(int id)
    {
      var existingToDo = await _todoRepository.FindByIdAsync(id);

      if (existingToDo == null)
        return new ToDoResponse("ToDo not found.");

      try
      {
        _todoRepository.Remove(existingToDo);
        await _unitOfWork.CompleteAsync();

        return new ToDoResponse(existingToDo);
      }
      catch (Exception ex)
      {
        // Do some logging stuff
        return new ToDoResponse($"An error occurred when deleting the todo: {ex.Message}");
      }
    }

    public async Task<ToDoResponse> GetToDoById(int id)
    {
      var existingToDo = await _todoRepository.FindByIdAsync(id);

      if (existingToDo == null)
        return new ToDoResponse("ToDo not found.");

      return new ToDoResponse(existingToDo);
    }
  }
}