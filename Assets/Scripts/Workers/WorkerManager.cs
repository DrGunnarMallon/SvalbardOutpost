using System;
using System.Collections.Generic;
using UnityEngine;

// public class WorkerManager : MonoBehaviour
// {
//     [SerializeField] private WorkerListSO workerList;

//     private List<Worker> allWorkers = new List<Worker>();
//     private List<Worker> availableWorkers = new List<Worker>();
//     private List<Worker> hiredWorkers = new List<Worker>();

//     private void Start()
//     {
//         foreach (WorkerSO worker in workerList.workers)
//         {
//             Worker newWorker = new Worker(worker);
//             allWorkers.Add(newWorker);
//         }

//         availableWorkers = getAvailableWorkers();

//         foreach (Worker worker in availableWorkers)
//         {
//             GameManager.Instance.UIManager.workersPanel.AddWorker(worker);
//         }

//         GameManager.Instance.TimeManager.OnDayChanged += NewDay;
//     }

//     private void Update()
//     {
//         availableWorkers = getAvailableWorkers();
//         foreach (Worker worker in availableWorkers)
//         {
//             GameManager.Instance.UIManager.workersPanel.AddWorker(worker);
//         }
//     }


//     private void OnDestroy()
//     {
//         GameManager.Instance.TimeManager.OnDayChanged -= NewDay;
//     }


//     private List<Worker> getAvailableWorkers()
//     {
//         List<Worker> availableWorkers = new List<Worker>();
//         foreach (Worker worker in allWorkers)
//         {
//             if (worker.WorkerIsAvailable) continue;

//             if (worker.WorkerDateAvailable <= GameManager.Instance.TimeManager.CurrentDate)
//             {
//                 worker.SetWorkerAvailable(true);
//                 availableWorkers.Add(worker);
//             }
//         }
//         return availableWorkers;
//     }


//     private void NewDay(DateTime currentDate)
//     {
//         GameManager.Instance.ResourceManager.AddCoal(CalculateCoalProduction());
//         GameManager.Instance.ResourceManager.UseMoney(CalculateWages());
//     }


//     public void HireWorker(Worker worker)
//     {
//         worker.HireWorker();
//         hiredWorkers.Add(worker);
//     }


//     public void FireWorker(Worker worker)
//     {
//         worker.FireWorker();
//         hiredWorkers.Remove(worker);
//     }


//     public int CalculateWages()
//     {
//         int totalWages = 0;
//         foreach (Worker worker in hiredWorkers)
//         {
//             totalWages += Mathf.RoundToInt(worker.WorkerWage);
//         }
//         return totalWages;
//     }


//     public int CalculateCoalProduction()
//     {
//         int totalCoalProduction = 0;
//         foreach (Worker worker in hiredWorkers)
//         {
//             totalCoalProduction += worker.WorkerCoalProduction;
//         }
//         return totalCoalProduction;
//     }
// }

public class WorkerManager : MonoBehaviour
{
    [SerializeField] private WorkerListSO workerList;

    private List<Worker> allWorkers = new List<Worker>();
    private List<Worker> availableWorkers = new List<Worker>();
    private List<Worker> hiredWorkers = new List<Worker>();

    private void Start()
    {
        foreach (WorkerSO worker in workerList.workers)
        {
            Worker newWorker = new Worker(worker);
            allWorkers.Add(newWorker);
        }

        availableWorkers = getAvailableWorkers();

        foreach (Worker worker in availableWorkers)
        {
            GameManager.Instance.UIManager.workersPanel.AddWorker(worker);
        }

        GameManager.Instance.TimeManager.OnDayChanged += NewDay;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TimeManager.OnDayChanged -= NewDay;
    }

    private List<Worker> getAvailableWorkers()
    {
        List<Worker> availableWorkers = new List<Worker>();
        foreach (Worker worker in allWorkers)
        {
            if (worker.WorkerIsAvailable) continue;

            if (worker.WorkerDateAvailable <= GameManager.Instance.TimeManager.CurrentDate)
            {
                worker.SetWorkerAvailable(true);
                availableWorkers.Add(worker);
            }
        }
        return availableWorkers;
    }

    private void NewDay(DateTime currentDate)
    {
        // Update resources
        GameManager.Instance.ResourceManager.AddCoal(CalculateCoalProduction());
        GameManager.Instance.ResourceManager.UseMoney(CalculateWages());

        // Check for new workers that have become available
        foreach (Worker worker in allWorkers)
        {
            if (!worker.WorkerIsAvailable && worker.WorkerDateAvailable <= currentDate)
            {
                worker.SetWorkerAvailable(true);
                // Add the worker to the UI now that they are available.
                GameManager.Instance.UIManager.workersPanel.AddWorker(worker);
            }
        }
    }

    public void HireWorker(Worker worker)
    {
        worker.HireWorker();
        hiredWorkers.Add(worker);
    }

    public void FireWorker(Worker worker)
    {
        worker.FireWorker();
        hiredWorkers.Remove(worker);
    }

    public int CalculateWages()
    {
        int totalWages = 0;
        foreach (Worker worker in hiredWorkers)
        {
            totalWages += Mathf.RoundToInt(worker.WorkerWage);
        }
        return totalWages;
    }

    public int CalculateCoalProduction()
    {
        int totalCoalProduction = 0;
        foreach (Worker worker in hiredWorkers)
        {
            totalCoalProduction += worker.WorkerCoalProduction;
        }
        return totalCoalProduction;
    }
}
