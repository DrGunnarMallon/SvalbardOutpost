using UnityEngine;

[System.Serializable]
public class GameEvent
{
    public string eventName;
    public int coalEffect;
    public int foodEffect;
    public int toolsEffect;

    public void ApplyEvent()
    {
        ResourceManager rm = GameManager.Instance.ResourceManager;

        if (coalEffect > 0)
        {
            rm.AddCoal(coalEffect);
        }
        else
        {
            rm.UseCoal(coalEffect);
        }

        if (foodEffect > 0)
        {
            rm.AddFood(foodEffect);
        }
        else
        {
            rm.UseFood(foodEffect);
        }

        if (toolsEffect > 0)
        {
            rm.AddTools(toolsEffect);
        }
        else
        {
            rm.UseTools(toolsEffect);
        }

    }
}