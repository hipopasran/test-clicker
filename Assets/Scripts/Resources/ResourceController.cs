using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private ResourceView _resourceView;
    [SerializeField] private EnergySettings _energySettings;
    
    [Header("Debug Values")]
    [SerializeField] private int _currentEnergy;
    [SerializeField] private float _currentResources;

    public bool IsEnoughtEnergy(int value)
    {
        if (_currentEnergy - value >= 0)
        {
            return true;
        }

        return false;
    }

    public void SubstractEnergy(int energy)
    {
        _currentEnergy -= energy;
        _resourceView.UpdateEnergyValue(_currentEnergy);
    }

    public void UpdateResources(float resources)
    {
        _currentResources += resources;
        _resourceView.UpdateResourceValue(_currentResources);
    }

    private void Init()
    {
        // Load
        
        _currentEnergy = _energySettings.BaseEnergy;
        _resourceView.UpdateEnergyValue(_currentEnergy);

        _currentResources = 0;
        _resourceView.UpdateResourceValue(_currentResources);
    }

    private void Awake()
    {
        Init();
    }
}
