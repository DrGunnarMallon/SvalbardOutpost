using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] private Image workerImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI jobText;
    [SerializeField] public TextMeshProUGUI skillText;
    [SerializeField] private TextMeshProUGUI wageText;
    [SerializeField] private TextMeshProUGUI coalText;

    [SerializeField] private Image background;

    [SerializeField] private Button hireButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button trainButton;

    private WorkerSO workerData;
    private Color startingColor;

    private void Start()
    {
        startingColor = background.color;
    }

    public void Initialize(WorkerSO workerData)
    {
        workerImage.sprite = workerData.workerIcon;
        nameText.text = workerData.workerName;
        jobText.text = workerData.workerJob.ToString();
        skillText.text = workerData.workerSkill.ToString();
        wageText.text = $"${workerData.workerWage.ToString()} / day";
        coalText.text = workerData.workerCoalProduction.ToString() + " / day";
        this.workerData = workerData;
    }

    public void DisableTrainButton()
    {
        trainButton.interactable = false;
    }

    public void HireWorker()
    {
        GameManager.Instance.WorkerManager.HireWorker(workerData);
        hireButton.interactable = false;
        background.color = new Color32(255, 155, 100, 255);
    }

    public void FireWorker()
    {
        GameManager.Instance.WorkerManager.FireWorker(workerData);
        hireButton.interactable = true;
        fireButton.interactable = true;
        background.color = startingColor;
    }

}
