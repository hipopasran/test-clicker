using UnityEngine;

[CreateAssetMenu(fileName = "Tap_Settings", menuName = "Tap/TapSettings", order = 1)]
public class TapSettings : ScriptableObject
{
    [Header("Tap Settings")] 
    public int BaseTapEnergyValue;
    public float BaseTapReward;
    public float BaseTapModificator;
    public float TapMultiplier;
    public float TapModificatorTime;
}
