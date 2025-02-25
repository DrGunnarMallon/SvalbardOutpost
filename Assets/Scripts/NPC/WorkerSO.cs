using UnityEngine;

[CreateAssetMenu(fileName = "NewWorker", menuName = "Workers/Worker")]
public class WorkerSO : ScriptableObject
{
    [Header("Worker Details")]
    public Sprite workerIcon;
    public string workerName;
    public JobType workerJob;
    public SkillLevel workerSkill;
    public int workerWage;

    public int workerCoalProduction = 1;
    public int workerHappiness = 100;

    public bool hired = false;
}
