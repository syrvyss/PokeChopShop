using Data;
using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<T> : ControllerBase where T : class
{
    private readonly IBaseRepository<T> _repository;

    protected BaseController(IBaseRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public ActionResult<T> GetById(int id)
    {
        var entity = _repository.GetById(id);
        if (entity == null) return NotFound();

        return entity;
    }

    [HttpGet]
    public ActionResult<IEnumerable<T>> GetAll()
    {
        var entities = _repository.GetAll();
        return Ok(entities);
    }

    [HttpPost]
    public ActionResult<T> Add(T entity)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _repository.Add(entity);

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, T entity)
    {
        var existingEntity = _repository.GetById(id);

        if (existingEntity == null) return NotFound();

        _repository.Update(entity);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var entity = _repository.GetById(id);
        if (entity == null) return NotFound();

        _repository.Delete(entity);

        return NoContent();
    }
}