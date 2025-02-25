using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class EventPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI eventText;
    [SerializeField] private float typingSpeed = 0.02f;
    [SerializeField] private Button dismissButton;

    private Coroutine currentEventCoroutine;
    private bool isDismissed;

    private void Start()
    {
        GameManager.Instance.EventManager.OnHistoricalEvent += UpdateEvent;
        dismissButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.Instance.EventManager.OnHistoricalEvent -= UpdateEvent;
    }

    private void UpdateEvent(HistoricalEventDataSO historicalEvent)
    {
        if (currentEventCoroutine != null)
        {
            StopCoroutine(currentEventCoroutine);
            currentEventCoroutine = null;
        }
        isDismissed = false;
        currentEventCoroutine = StartCoroutine(ShowEventRoutine(historicalEvent));
    }

    public IEnumerator ShowEventRoutine(HistoricalEventDataSO historicalEvent)
    {
        dismissButton.gameObject.SetActive(true);
        GameManager.Instance.AudioManager.PlayTeleTypeFX();
        Debug.Log(GameManager.Instance.AudioManager);

        string date = historicalEvent.EventDate.ToString("MMM dd, yyyy");
        string header = $"<b>{date}: {historicalEvent.eventName}</b>\n";

        eventText.text = header;

        string message = historicalEvent.description;

        for (int i = 0; i < message.Length; i++)
        {
            if (isDismissed)
            {
                yield break;
            }
            eventText.text += message[i];
            yield return new WaitForSeconds(typingSpeed);
        }
        GameManager.Instance.AudioManager.StopSoundFX();

        while (!isDismissed)
        {
            yield return null;
        }

        eventText.text = string.Empty;
    }

    public void DismissEvent()
    {
        GameManager.Instance.AudioManager.StopSoundFX();
        isDismissed = true;
        eventText.text = string.Empty;
        dismissButton.gameObject.SetActive(false);
    }
}