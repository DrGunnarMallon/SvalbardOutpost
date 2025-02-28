using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public ResourceManager ResourceManager { get; private set; }
    [field: SerializeField] public UIManager UIManager { get; private set; }
    [field: SerializeField] public EventManager EventManager { get; private set; }
    [field: SerializeField] public TimeManager TimeManager { get; private set; }
    [field: SerializeField] public Transform Player { get; private set; }
    [field: SerializeField] public AudioManager AudioManager { get; private set; }
    [field: SerializeField] public WorkerManager WorkerManager { get; private set; }
    [field: SerializeField] public TradeManager TradeManager { get; private set; }

    private IGameState currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ResourceManager.Initialize();
        EventManager.Initialize();

        TimeManager.OnDayChanged += EventManager.CheckHistoricalEvent;

        SetState(new MainManagementState());
    }

    private void Update()
    {
        currentState?.UpdateState();
    }

    public void SetState(IGameState state)
    {
        currentState?.ExitState();
        currentState = state;
        currentState.EnterState();
    }

    public void SetNewsState()
    {
        SetState(new NewsState());
    }

    public void SetResearchState()
    {
        SetState(new ResearchState());
    }

    public void SetMainManagementState()
    {
        SetState(new MainManagementState());
    }

    public void SetWorkersState()
    {
        SetState(new WorkersState());
    }

    public void SetTradeState()
    {
        SetState(new TradeState());
    }

    public void SetMiningState()
    {
        SetState(new MiningState());
    }

    public void SetResourcesState()
    {
        SetState(new ResourceState());
    }
}
