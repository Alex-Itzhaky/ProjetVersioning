using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    private float _baseScale;
    [MinValue(0)]
    [SerializeField] private float _scaleTransitionTime;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _boxCollider;

    public float BaseScale => _baseScale;
    private void Start()
    {
        _baseScale = _spriteRenderer.size.x;
    }

    public void UpdateScale(float scale)
    {
        StartCoroutine(UpdateScaleCoroutine(scale));
    }

    private IEnumerator UpdateScaleCoroutine(float scale)
    {
        Vector2 startScale = _spriteRenderer.size;
        Vector3 startTrScale = _boxCollider.localScale;
        float elapsedTime = 0f;
        while (elapsedTime < _scaleTransitionTime)
        {
            _spriteRenderer.size = Vector2.Lerp(startScale, new Vector2(scale, _spriteRenderer.size.y), elapsedTime/_scaleTransitionTime);
            transform.localScale = Vector3.Lerp(startTrScale, new Vector3(scale, 1, 1), elapsedTime / _scaleTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _spriteRenderer.size = new Vector2(scale, _spriteRenderer.size.y);
        transform.localScale = new Vector3(scale, 1, 1);
    }
}
