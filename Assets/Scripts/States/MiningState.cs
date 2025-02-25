using UnityEngine;

public class MiningState : IGameState
{
    public void EnterState()
    {
        GameManager.Instance.UIManager.ShowMiningUI();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
    }
}
