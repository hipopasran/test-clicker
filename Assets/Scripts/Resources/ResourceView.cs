using UnityEngine;
using TMPro;

public class ResourceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _energyText;
    [SerializeField] private TextMeshProUGUI _resourcesText;
    
    public void UpdateEnergyValue(int value)
    {
        _energyText.text = value.ToString();
    }

    public void UpdateResourceValue(float value)
    {
        _resourcesText.text = value.ToString();
    }
}
