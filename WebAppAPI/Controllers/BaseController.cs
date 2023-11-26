using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<T> : ControllerBase where T : class
{
    protected readonly Logic.Controllers.IBaseController<T> _controller;

    protected BaseController()
    {
    }

    protected BaseController(Logic.Controllers.IBaseController<T> controller)
    {
        _controller = controller;
    }

    [HttpGet("{id}")]
    public ActionResult<T> GetById(int id)
    {
        var entity = _controller.GetById(id);
        if (entity == null) return NotFound();

        return entity;
    }

    [HttpGet]
    public ActionResult<IEnumerable<T>> GetAll()
    {
        var entities = _controller.GetAll();
        return Ok(entities);
    }

    [HttpPost]
    public ActionResult<T> Add(T entity)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _controller.Add(entity);

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, T entity)
    {
        var existingEntity = _controller.GetById(id);

        if (existingEntity == null) return NotFound();

        _controller.Update(entity);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var entity = _controller.GetById(id);
        if (entity == null) return NotFound();

        _controller.Delete(id);

        return NoContent();
    }
}