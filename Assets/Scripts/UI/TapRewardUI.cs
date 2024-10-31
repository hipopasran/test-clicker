using System.Collections;
using TMPro;
using UnityEngine;

public class TapRewardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private float _time;

    private Coroutine _move;

    public void SetValue(float value)
    {
        _countText.text = "+" + value.ToString();
    }
    
    public void Animate(Transform endPoint, System.Action callback)
    {
        var endPos = new Vector3(transform.position.x, endPoint.position.y, transform.position.z);
        gameObject.SetActive(true);
        StartMove(endPos, callback);
    }

    private void StartMove(Vector3 endPoint, System.Action callback)
    {
        if(_move != null) StopCoroutine(_move);
        _move = StartCoroutine(Move(_time, endPoint ,() =>
        {
            gameObject.SetActive(false);
            callback?.Invoke();
        }));
    }

    private IEnumerator Move(float delay, Vector3 endPoint, System.Action callback)
    {
        float time = 0;
        while (time < delay)
        {
            transform.position = Vector3.Lerp(transform.position, endPoint, time);
            _countText.alpha = Mathf.Lerp(_countText.alpha, 0, time);
            time += Time.deltaTime;
            yield return null;
        }
        
        callback?.Invoke();
    }
    
    private void OnEnable()
    {
        _countText.alpha = 1f;
    }
}
