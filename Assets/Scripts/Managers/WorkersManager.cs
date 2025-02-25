using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkersManager : MonoBehaviour
{
    [SerializeField] private WorkerListSO workerList;

    private List<WorkerSO> workers = new List<WorkerSO>();


    private void Start()
    {
        foreach (WorkerSO worker in workerList.workers)
        {
            GameManager.Instance.UIManager.workersPanel.AddWorker(worker);
        }

        GameManager.Instance.TimeManager.OnDayChanged += NewDay;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TimeManager.OnDayChanged -= NewDay;
    }

    private void NewDay(DateTime currentDate)
    {
        GameManager.Instance.ResourceManager.AddCoal(CalculateCoalProduction());
        GameManager.Instance.ResourceManager.UseMoney(CalculateWages());
    }

    public void HireWorker(WorkerSO worker)
    {
        workers.Add(worker);
        worker.hired = true;
    }

    public void FireWorker(WorkerSO worker)
    {
        workers.Remove(worker);
    }

    public int CalculateWages()
    {
        int totalWages = 0;
        foreach (WorkerSO worker in workers)
        {
            totalWages += worker.workerWage;
        }
        return totalWages;
    }

    public int CalculateCoalProduction()
    {
        int totalCoalProduction = 0;
        foreach (WorkerSO worker in workers)
        {
            totalCoalProduction += worker.workerCoalProduction;
        }
        return totalCoalProduction;
    }
}
