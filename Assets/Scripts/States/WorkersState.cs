using UnityEngine;

public class WorkersState : IGameState
{
    public void EnterState()
    {
        GameManager.Instance.UIManager.ShowWorkersUI();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
    }
}
