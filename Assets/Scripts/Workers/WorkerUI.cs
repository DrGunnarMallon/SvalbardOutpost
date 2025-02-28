// using UnityEngine;
// using TMPro;
// using UnityEngine.UI;
// using System;

// public class WorkerUI : MonoBehaviour
// {
//     [SerializeField] private Image workerImage;
//     [SerializeField] private TextMeshProUGUI nameText;
//     [SerializeField] private TextMeshProUGUI jobText;
//     [SerializeField] public TextMeshProUGUI skillText;
//     [SerializeField] private TextMeshProUGUI wageText;
//     [SerializeField] private TextMeshProUGUI coalText;

//     [SerializeField] private Image background;

//     [SerializeField] private Button hireButton;
//     [SerializeField] private Button fireButton;
//     [SerializeField] private Button trainButton;

//     private Worker workerData;
//     private Color startingColor;

//     private void Start()
//     {
//         startingColor = background.color;
//     }

//     public void Initialize(Worker workerData)
//     {
//         workerImage.sprite = workerData.WorkerIcon;
//         nameText.text = workerData.WorkerName;
//         jobText.text = workerData.WorkerJob.ToString();
//         skillText.text = workerData.WorkerSkill.ToString();
//         wageText.text = $"${workerData.WorkerWage.ToString()} / day";
//         coalText.text = workerData.WorkerCoalProduction.ToString() + " / day";
//         this.workerData = workerData;
//     }

//     public void DisableTrainButton()
//     {
//         trainButton.interactable = false;
//     }

//     public void HireWorker()
//     {
//         GameManager.Instance.WorkerManager.HireWorker(workerData);
//         hireButton.interactable = false;
//         background.color = new Color32(255, 155, 100, 255);
//     }

//     public void FireWorker()
//     {
//         GameManager.Instance.WorkerManager.FireWorker(workerData);
//         hireButton.interactable = true;
//         fireButton.interactable = true;
//         background.color = startingColor;
//     }

// }

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorkerUI : MonoBehaviour
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

    private Worker workerData;
    private Color startingColor;

    private void Start()
    {
        startingColor = background.color;
    }

    public void Initialize(Worker workerData)
    {
        this.workerData = workerData;
        UpdateUI();
        workerData.OnUpdated += UpdateUI;
    }

    private void OnDestroy()
    {
        if (workerData != null)
            workerData.OnUpdated -= UpdateUI;
    }

    private void UpdateUI(Worker updatedWorker = null)
    {
        wageText.text = $"${workerData.WorkerWage:0.00} / day";
        coalText.text = workerData.WorkerCoalProduction.ToString() + " / day";
        nameText.text = workerData.WorkerName;
        jobText.text = workerData.WorkerJob.ToString();
        skillText.text = workerData.WorkerSkill.ToString();
        workerImage.sprite = workerData.WorkerIcon;
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
