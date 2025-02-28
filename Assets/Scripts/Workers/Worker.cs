// using System;
// using System.Globalization;
// using UnityEngine;

// public class Worker
// {
//     public Sprite WorkerIcon { get; private set; }
//     public string WorkerName { get; private set; }
//     public JobType WorkerJob { get; private set; }
//     public SkillLevel WorkerSkill { get; private set; }
//     public float WorkerWage { get; private set; }
//     public DateTime WorkerDateAvailable { get; private set; }
//     public int WorkerCoalProduction { get; private set; }
//     public int WorkerHappiness { get; private set; }
//     public int WorkerHealth { get; private set; }
//     public int WorkerReliability { get; private set; }
//     public bool WorkerHired { get; private set; }
//     public bool WorkerIsAvailable { get; private set; }

//     public Worker(WorkerSO template)
//     {
//         WorkerIcon = template.workerIcon;
//         WorkerName = template.workerName;
//         WorkerJob = template.workerJob;
//         WorkerSkill = template.workerSkill;
//         WorkerWage = template.workerWage;
//         WorkerDateAvailable = DateTime.ParseExact(template.workerDateAvailable, "yyyy-MM-dd", CultureInfo.InvariantCulture);
//         WorkerCoalProduction = template.workerCoalProduction;

//         WorkerHired = false;
//         WorkerHealth = 100;
//         WorkerHappiness = 100;
//     }

//     public void HireWorker()
//     {
//         WorkerHired = true;
//     }

//     public void FireWorker()
//     {
//         WorkerHired = false;
//         WorkerWage *= 1.1f;
//         WorkerHappiness *= Mathf.RoundToInt(0.9f);
//     }

//     public void SetWorkerAvailable(bool available)
//     {
//         WorkerIsAvailable = available;
//     }
// }

using System;
using System.Globalization;
using UnityEngine;

public class Worker
{
    public Sprite WorkerIcon { get; private set; }
    public string WorkerName { get; private set; }
    public JobType WorkerJob { get; private set; }
    public SkillLevel WorkerSkill { get; private set; }
    public float WorkerWage { get; private set; }
    public DateTime WorkerDateAvailable { get; private set; }
    public int WorkerCoalProduction { get; private set; }
    public int WorkerHappiness { get; private set; }
    public int WorkerHealth { get; private set; }
    public int WorkerReliability { get; private set; }
    public bool WorkerHired { get; private set; }
    public bool WorkerIsAvailable { get; private set; }

    // Event to notify observers (like UI) about updates.
    public event Action<Worker> OnUpdated;

    public Worker(WorkerSO template)
    {
        WorkerIcon = template.workerIcon;
        WorkerName = template.workerName;
        WorkerJob = template.workerJob;
        WorkerSkill = template.workerSkill;
        WorkerWage = template.workerWage;
        WorkerDateAvailable = DateTime.ParseExact(template.workerDateAvailable, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        WorkerCoalProduction = template.workerCoalProduction;

        WorkerHired = false;
        WorkerHealth = 100;
        WorkerHappiness = 100;
    }

    public void HireWorker()
    {
        WorkerHired = true;
        OnUpdated?.Invoke(this);
    }

    public void FireWorker()
    {
        WorkerHired = false;
        WorkerWage *= 1.1f;
        WorkerHappiness = Mathf.RoundToInt(WorkerHappiness * 0.9f);
        OnUpdated?.Invoke(this);
    }

    public void SetWorkerAvailable(bool available)
    {
        WorkerIsAvailable = available;
        OnUpdated?.Invoke(this);
    }
}
