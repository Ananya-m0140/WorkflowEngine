using Microsoft.AspNetCore.Mvc;
using WorkflowEngine.Services;

namespace WorkflowEngine.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkflowInstancesController : ControllerBase
{
    private readonly WorkflowInstanceService _service;

    public WorkflowInstancesController(WorkflowInstanceService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Start([FromQuery] string definitionId)
    {
        var instance = _service.StartInstance(definitionId);
        return instance is not null ? Ok(instance) : BadRequest("Invalid definition");
    }

    [HttpPost("{id}/execute")]
    public IActionResult Execute(string id, [FromQuery] string actionId)
    {
        var result = _service.ExecuteAction(id, actionId);
        return result.IsSuccess ? Ok(result.Instance) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var instance = _service.GetInstance(id);
        return instance is not null ? Ok(instance) : NotFound("Instance not found");
    }

    // ✅ New method to get all workflow instances
    [HttpGet]
    public IActionResult GetAll()
    {
        var instances = _service.GetAllInstances();
        return Ok(instances);
    }
}
