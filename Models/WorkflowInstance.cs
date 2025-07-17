namespace WorkflowEngine.Models;
using WorkflowEngine.Models; // For ActionHistory

public class WorkflowInstance {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string DefinitionId { get; set; } = default!;
    public string CurrentState { get; set; } = default!;
    public List<ActionHistory> History { get; set; } = [];
}
