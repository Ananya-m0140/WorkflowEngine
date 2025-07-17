using WorkflowEngine.Models;

namespace WorkflowEngine.Services;

public class WorkflowDefinitionService
{
    private readonly InMemoryDataStore _store;

    public WorkflowDefinitionService(InMemoryDataStore store)
    {
        _store = store;
    }

    public (bool IsSuccess, string? Error) CreateDefinition(WorkflowDefinition def)
    {
        if (_store.Definitions.Any(d => d.Id == def.Id))
            return (false, "Duplicate definition ID");

        if (!def.States.Any(s => s.IsInitial))
            return (false, "At least one initial state required");

        if (def.States.Count(s => s.IsInitial) > 1)
            return (false, "Only one initial state allowed");

        if (def.Actions.Any(a => !def.States.Any(s => s.Id == a.ToState)))
            return (false, "Invalid action: toState does not exist");

        _store.Definitions.Add(def);
        return (true, null);
    }

    public WorkflowDefinition? GetDefinition(string id) =>
        _store.Definitions.FirstOrDefault(d => d.Id == id);

    
    public List<WorkflowDefinition> GetAllDefinitions() =>
        _store.Definitions;
}
