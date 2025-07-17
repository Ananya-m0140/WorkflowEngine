using Microsoft.AspNetCore.Mvc;
using WorkflowEngine.Models;
using WorkflowEngine.Services;

namespace WorkflowEngine.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkflowDefinitionsController : ControllerBase
{
    private readonly WorkflowDefinitionService _service;

    public WorkflowDefinitionsController(WorkflowDefinitionService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(WorkflowDefinition def)
    {
        var result = _service.CreateDefinition(def);
        return result.IsSuccess ? Ok(def) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var def = _service.GetDefinition(id);
        return def is not null ? Ok(def) : NotFound("Definition not found");
    }
}
