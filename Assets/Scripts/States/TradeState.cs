using UnityEngine;

public class TradeState : IGameState
{
    public void EnterState()
    {
        GameManager.Instance.UIManager.ShowTradeUI();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
    }
}
