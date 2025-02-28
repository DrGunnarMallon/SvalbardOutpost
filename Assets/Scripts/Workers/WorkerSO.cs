using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWorker", menuName = "Workers/Worker")]
public class WorkerSO : ScriptableObject
{
    [Header("Worker Details")]
    public Sprite workerIcon;
    public string workerName;
    public JobType workerJob;
    public SkillLevel workerSkill;
    public float workerWage;
    public int workerCoalProduction;
    public int workerReliability;
    public string workerDateAvailable;
}
