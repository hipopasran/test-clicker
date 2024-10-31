using UnityEngine;
using UnityEngine.UI;

public class ClickerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Controllers _controllers;
    [SerializeField] private Button _tapButton;
    [SerializeField] private TapSettings _tapSettings;
    [SerializeField] private bool _useCollectorBaseReward;

    [Header("Debug Values")]
    [SerializeField] private int _tapEnergy;
    [SerializeField] private float _tapReward;
    [SerializeField] private float _tapModificator;
    [SerializeField] private float _tapModificatorTime;
    [SerializeField] private float _tapMultiplier;

    private ResourceController _resourceController;
    private CollectorController _collectorController;
    private TapRewardUIController _tapRewardUIController;
    
    private void Tap()
    {
        if (_resourceController.IsEnoughtEnergy(_tapEnergy))
        {
            var reward = CalculateReward();
            _resourceController.SubstractEnergy(_tapEnergy);
            _resourceController.UpdateResources(reward);
            _tapRewardUIController.Click(reward);
        }
    }

    private float CalculateReward()
    {
        var reward = _tapReward + (_tapModificator * _tapModificatorTime) *
            _tapMultiplier;

        if (_useCollectorBaseReward) reward += _collectorController.RewardPerTime * 0.1f;

        return reward;
    }

    private void Init()
    {
        _resourceController = _controllers.ResourceController;
        _collectorController = _controllers.CollectorController;
        _tapRewardUIController = _controllers.TapRewardUIController;

        // Load
        _tapEnergy = _tapSettings.BaseTapEnergyValue;
        _tapReward = _tapSettings.BaseTapReward;
        _tapModificator = _tapSettings.BaseTapModificator;
        _tapModificatorTime = _tapSettings.TapModificatorTime;
        _tapMultiplier = _tapSettings.TapMultiplier;
    }

    private void Awake()
    {
        _tapButton.onClick.AddListener(Tap);
        
        Init();
    }
}
