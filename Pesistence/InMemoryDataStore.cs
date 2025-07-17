using WorkflowEngine.Models;

namespace WorkflowEngine;

public class InMemoryDataStore
{
    public List<WorkflowDefinition> Definitions { get; set; } = new();
    public List<WorkflowInstance> Instances { get; set; } = new();
}
