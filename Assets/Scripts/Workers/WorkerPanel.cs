using UnityEngine;

public class WorkerPanel : MonoBehaviour
{
    [SerializeField] private GameObject workerItemPrefab;
    [SerializeField] private Transform contentContainer;

    public void AddWorker(Worker workerData)
    {
        GameObject workerItemGO = Instantiate(workerItemPrefab, contentContainer, false);
        WorkerUI worker = workerItemGO.GetComponent<WorkerUI>();
        worker?.Initialize(workerData);

        if (workerData.WorkerSkill == SkillLevel.Expert)
        {
            worker.DisableTrainButton();
        }
    }
}
