using UnityEngine;

public class ResourceState : IGameState
{
    public void EnterState()
    {
        GameManager.Instance.UIManager.ShowResourceUI();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
    }
}