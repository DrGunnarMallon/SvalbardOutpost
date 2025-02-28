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
        GameManager.Instance.EventManager.OnHistoricalEvent += ShowEvent;
        GameManager.Instance.EventManager.OnTradeEvent += ShowEvent;
        GameManager.Instance.EventManager.OnWorkerEvent += ShowEvent;
        GameManager.Instance.EventManager.OnEnvironmentEvent += ShowEvent;
        dismissButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.Instance.EventManager.OnHistoricalEvent -= ShowEvent;
    }

    private void ShowEvent(IGameEvent gameEvent)
    {
        if (currentEventCoroutine != null)
        {
            StopCoroutine(currentEventCoroutine);
            currentEventCoroutine = null;
        }
        isDismissed = false;
        currentEventCoroutine = StartCoroutine(ShowEventRoutine(gameEvent));
    }

    public IEnumerator ShowEventRoutine(IGameEvent gameEvent)
    {
        dismissButton.gameObject.SetActive(true);
        GameManager.Instance.AudioManager.PlayTeleTypeFX();

        string date = gameEvent.EventDate.ToString("MMM dd, yyyy");
        string header = $"<b>{date}: {gameEvent.EventName}</b>\n";

        eventText.text = header;

        string message = gameEvent.EventDescription;

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