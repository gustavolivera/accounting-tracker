using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BaseController<T> : ControllerBase where T : class
{
    private readonly IBaseService<T> _service;

    public BaseController(IBaseService<T> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAssync() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var entity = await _service.GetByIdAsync(id);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] T entity)
    {
        var created = await _service.CreateAsync(entity);
        return created == null ? NotFound() : Ok(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] T entity)
    {
        if (!IdEquals(entity, id)) return BadRequest("ID mismatch.");
        var updated = await _service.UpdateAsync(entity);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }

    // Métodos auxiliares — assumem que a entidade tem propriedade "Id" do tipo Guid
    private static Guid GetId(T entity)
    {
        return (Guid)entity?.GetType().GetProperty("Id")?.GetValue(entity)!;
    }

    private static bool IdEquals(T entity, Guid id)
    {
        var value = entity?.GetType().GetProperty("Id")?.GetValue(entity);
        return value is Guid guid && guid == id;
    }
}
