namespace WorkflowEngine.Models;
public class WorkflowAction {
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public bool Enabled { get; set; }
    public List<string> FromStates { get; set; } = [];
    public string ToState { get; set; } = default!;
}
