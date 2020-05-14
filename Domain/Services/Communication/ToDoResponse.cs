using Livecoding.API.Domain.Models;

namespace Livecoding.API.Domain.Services.Communication
{
  public class ToDoResponse : BaseResponse
  {
    public ToDo ToDo { get; private set; }

    private ToDoResponse(bool success, string message, ToDo todo) : base(success, message)
    {
      ToDo = todo;
    }

    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="todo">Saved todo.</param>
    /// <returns>Response.</returns>
    public ToDoResponse(ToDo todo) : this(true, string.Empty, todo)
    { }

    /// <summary>
    /// Creates am error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public ToDoResponse(string message) : this(false, message, null)
    { }
  }
}