using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CollectorController : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Controllers _controllers;
    [SerializeField] private CollectorSettings _collectorSettings;
    [SerializeField] private CollectorView _collectorView;
    [SerializeField] private Button _collectButton;

    [Header("Debug Values")]
    [SerializeField] private float _reward;
    [SerializeField] private float _rewardTime;
    [SerializeField] private float _currentReward;

    private Coroutine _timer;
    private ResourceController _resourceController;
    private TapRewardUIController _tapRewardUIController;

    public float RewardPerTime => _reward;

    private void Init()
    {
        _collectButton.onClick.AddListener(Collect);
        _resourceController = _controllers.ResourceController;
        _tapRewardUIController = _controllers.TapRewardUIController;
        
        // Load
        _reward = _collectorSettings.BaseReward;
        _rewardTime = _collectorSettings.RewardTime;

        _collectorView.UpdateCurrentReward(_currentReward);
    }

    private void Collect()
    {
        if (_currentReward > 0)
        {
            _resourceController.UpdateResources(_currentReward);
            _tapRewardUIController.Click(_currentReward);
            _currentReward = 0;
            _collectorView.UpdateCurrentReward(0);
        }
    }

    private void StartTimer()
    {
        if(_timer != null) StopCoroutine(_timer);
        _timer = StartCoroutine(Wait(_rewardTime, () =>
        {
            _currentReward += _reward;
            _collectorView.UpdateCurrentReward(_currentReward);
            StartTimer();
        }));
    }

    private IEnumerator Wait(float delay, System.Action callback)
    {
        float time = 0;
        while (time < delay)
        {
            time += Time.deltaTime;
            yield return null;
        }
        
        callback?.Invoke();
    }

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        StartTimer();
    }
}
