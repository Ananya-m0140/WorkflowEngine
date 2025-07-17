using WorkflowEngine.Models;

namespace WorkflowEngine.Services;

public class WorkflowInstanceService
{
    private readonly InMemoryDataStore _store;

    public WorkflowInstanceService(InMemoryDataStore store)
    {
        _store = store;
    }

    public WorkflowInstance? StartInstance(string definitionId)
    {
        var def = _store.Definitions.FirstOrDefault(d => d.Id == definitionId);
        if (def == null) return null;

        var initial = def.States.First(s => s.IsInitial);
        var instance = new WorkflowInstance
        {
            DefinitionId = definitionId,
            CurrentState = initial.Id
        };
        _store.Instances.Add(instance);
        return instance;
    }

    public (bool IsSuccess, string? Error, WorkflowInstance? Instance) ExecuteAction(string instanceId, string actionId)
    {
        var instance = _store.Instances.FirstOrDefault(i => i.Id == instanceId);
        if (instance == null) return (false, "Instance not found", null);

        var def = _store.Definitions.FirstOrDefault(d => d.Id == instance.DefinitionId);
        if (def == null) return (false, "Definition not found", null);

        var currentState = def.States.FirstOrDefault(s => s.Id == instance.CurrentState);
        if (currentState?.IsFinal == true)
            return (false, "Cannot transition from final state", null);

        var action = def.Actions.FirstOrDefault(a => a.Id == actionId);
        if (action == null) return (false, "Action not found", null);

        if (!action.Enabled) return (false, "Action is disabled", null);
        if (!action.FromStates.Contains(instance.CurrentState))
            return (false, "Action not allowed from current state", null);

        instance.CurrentState = action.ToState;
        instance.History.Add(new ActionHistory { ActionId = actionId });
        return (true, null, instance);
    }

    public WorkflowInstance? GetInstance(string id) =>
        _store.Instances.FirstOrDefault(i => i.Id == id);
}
