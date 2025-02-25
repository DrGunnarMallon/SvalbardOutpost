using UnityEngine;

public class NewsState : IGameState
{
    public void EnterState()
    {
        GameManager.Instance.UIManager.ShowNewsUI();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
    }
}
