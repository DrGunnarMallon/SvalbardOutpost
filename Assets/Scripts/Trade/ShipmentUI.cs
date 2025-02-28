using UnityEngine;
using UnityEngine.UI;

public class ShipmentUI : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;

    public void UpdateIndicator(int totalTime, int timeRemaining)
    {
        float progress = (float)(totalTime - timeRemaining) / (totalTime - 1);
        progressSlider.value = progress;
    }
}

