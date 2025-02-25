using UnityEngine;

public class MainManagementState : IGameState
{
    public void EnterState()
    {
        GameManager.Instance.UIManager.ShowManagementUI();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
    }
}
