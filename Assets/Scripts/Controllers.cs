using UnityEngine;

public class Controllers : MonoBehaviour
{
    [SerializeField] private ResourceController _resourceController;
    [SerializeField] private CollectorController _collectorController;
    [SerializeField] private ClickerController _clickerController;
    [SerializeField] private TapRewardUIController _tapRewardUIController;

    public ResourceController ResourceController => _resourceController;
    public CollectorController CollectorController => _collectorController;
    public ClickerController ClickerController => _clickerController;
    public TapRewardUIController TapRewardUIController => _tapRewardUIController;
}
