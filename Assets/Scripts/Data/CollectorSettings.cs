using UnityEngine;

[CreateAssetMenu(fileName = "Collector_Settings", menuName = "Collector/CollectorSettings", order = 1)]
public class CollectorSettings : ScriptableObject
{
    public float BaseReward;
    public float RewardTime;
}
