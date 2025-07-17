namespace WorkflowEngine.Models;
public class WorkflowDefinition {
    public string Id { get; set; } = default!;
    public List<State> States { get; set; } = [];
    public List<WorkflowAction> Actions { get; set; } = [];
}
