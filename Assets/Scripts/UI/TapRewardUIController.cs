using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TapRewardUIController : MonoBehaviour
{
    [SerializeField] private int _poolStartCount;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private TapRewardUI _tapRewardUIPrefab;

    private List<TapRewardUI> _listFree = new List<TapRewardUI>();
    private List<TapRewardUI> _listInProgress = new List<TapRewardUI>();

    public void Click(float value)
    {
        if (_listFree.Count < 1)
        {
            SpawnOneTapEffect();
        }
        
        var popup = _listFree[0];
        _listFree.Remove(popup);
        _listInProgress.Add(popup);
        popup.SetValue(value);
        popup.Animate(_endPoint, () =>
        {
            ReturnToPool(popup);
        }); 
    }

    public void SpawnOneTapEffect()
    {
        var popup = Instantiate(_tapRewardUIPrefab, _startPoint.position + new Vector3(Random.Range(-100f,100f), 0f ,0f), Quaternion.identity, _startPoint);
        popup.gameObject.SetActive(false);
        _listFree.Add(popup);
    }

    private void ReturnToPool(TapRewardUI _popup)
    {
        _listInProgress.Remove(_popup);
        _listFree.Add(_popup);
        _popup.transform.position = _startPoint.position + new Vector3(Random.Range(-100f, 100f),0,0);
    }

    private void CreatePool()
    {
        for (int i = 0; i < _poolStartCount; i++)
        {
            SpawnOneTapEffect();
        }
    }

    private void Awake()
    {
        CreatePool();
    }
}
