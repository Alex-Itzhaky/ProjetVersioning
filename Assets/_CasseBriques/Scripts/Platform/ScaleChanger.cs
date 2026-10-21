using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [MinValue(0)]
    [SerializeField] private float _baseScale;
    [MinValue(0)]
    [SerializeField] private float _scaleTransitionTime;

    public float BaseScale => _baseScale;
    private void Reset()
    {
        _baseScale = 1f;
    }

    public void UpdateScale(float scale)
    {
        StartCoroutine(UpdateScaleCoroutine(scale));
    }

    private IEnumerator UpdateScaleCoroutine(float scale)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;
        while (elapsedTime < _scaleTransitionTime)
        {
            transform.localScale = Vector3.Lerp(startScale, new Vector3(scale, 1, 1), elapsedTime/_scaleTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = new Vector3(scale, 1, 1);
        
    }
}
