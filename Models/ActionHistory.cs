namespace WorkflowEngine.Models
{
    public class ActionHistory
{
    public string ActionId { get; set; } = string.Empty;
    public string FromState { get; set; } = string.Empty;
    public string ToState { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}

}
