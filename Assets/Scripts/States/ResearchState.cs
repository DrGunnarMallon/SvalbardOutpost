using UnityEngine;

public class ResearchState : IGameState
{
    public void EnterState()
    {
        GameManager.Instance.UIManager.ShowResearchUI();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
    }
}
