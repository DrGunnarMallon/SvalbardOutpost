using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransferButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool isIncrease;
    [SerializeField] private MarketUIElement coalTransferManager;

    public float initialDelay = 0.4f;
    public float accelerationFactor = 0.6f;
    public float minDelay = 0.01f;

    private bool isHeld = false;
    private Coroutine holdCoroutine;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeld = true;
        if (isIncrease)
        {
            coalTransferManager.ChangeTransferAmount(1);
        }
        else
        {
            coalTransferManager.ChangeTransferAmount(-1);
        }

        holdCoroutine = StartCoroutine(RepeatAction());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHeld = false;
        if (holdCoroutine != null)
        {
            StopCoroutine(holdCoroutine);
        }
    }

    private IEnumerator RepeatAction()
    {
        float delay = initialDelay;

        while (isHeld)
        {
            yield return new WaitForSeconds(delay);
            if (!isHeld) break;

            if (isIncrease)
            {
                coalTransferManager.ChangeTransferAmount(1);
            }
            else
            {
                coalTransferManager.ChangeTransferAmount(-1);
            }

            delay = Mathf.Max(delay * accelerationFactor, minDelay);
        }
    }
}
