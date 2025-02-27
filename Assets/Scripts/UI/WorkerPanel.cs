using UnityEngine;

public class WorkerPanel : MonoBehaviour
{
    [SerializeField] private GameObject workerItemPrefab;
    [SerializeField] private Transform contentContainer;

    public void AddWorker(WorkerSO workerData)
    {
        GameObject workerItemGO = Instantiate(workerItemPrefab, contentContainer, false);
        Worker worker = workerItemGO.GetComponent<Worker>();
        worker?.Initialize(workerData);

        if (workerData.workerSkill == SkillLevel.Expert)
        {
            worker.DisableTrainButton();
        }
    }
}
