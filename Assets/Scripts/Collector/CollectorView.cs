using TMPro;
using UnityEngine;

public class CollectorView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentReward;

    public void UpdateCurrentReward(float value)
    {
        _currentReward.text = value.ToString();
    }
}
