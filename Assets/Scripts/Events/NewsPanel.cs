using UnityEngine;

public class NewsPanel : MonoBehaviour
{
    public void ShowNews()
    {
        gameObject.SetActive(true);
    }

    public void HideNews()
    {
        gameObject.SetActive(false);
    }
}