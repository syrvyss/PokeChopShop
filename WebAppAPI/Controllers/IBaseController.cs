using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers;

public interface IBaseController<T> where T : class
{
    ActionResult<T> GetById(int id);
    ActionResult<IEnumerable<T>> GetAll();
    ActionResult<T> Add(T entity);
    IActionResult Update(int id, T entity);
    IActionResult Delete(int id);
}