using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWorkerList", menuName = "Workers/Worker List")]
public class WorkerListSO : ScriptableObject
{
    public List<WorkerSO> workers;
}
