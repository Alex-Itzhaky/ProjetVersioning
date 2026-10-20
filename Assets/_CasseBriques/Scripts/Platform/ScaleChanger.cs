using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [MinValue(0)]
    [SerializeField] private float _baseScale;
    [MinValue(0)]
    [SerializeField] private float _scaleTransitionTime;

    private void Reset()
    {
        _baseScale = 1f;
    }

    public void UpdateScale(float scale, float duration)
    {
        StartCoroutine(UpdateScaleCoroutine(scale, duration));
    }

    private IEnumerator UpdateScaleCoroutine(float scale, float duration)
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
        startScale = transform.localScale;
        yield return new WaitForSeconds(duration);
        elapsedTime = 0f;
        while (elapsedTime < _scaleTransitionTime)
        {
            transform.localScale = Vector3.Lerp(startScale, new Vector3(_baseScale, 1, 1), elapsedTime/_scaleTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = new Vector3(_baseScale, 1, 1);
    }
    
    [Button(("Test le changement de scale (x2 pendant 3s)"), enabledMode:EButtonEnableMode.Playmode)]
    private void ScaleChangeTest()
    {
        UpdateScale(2, 3);
    }
}
