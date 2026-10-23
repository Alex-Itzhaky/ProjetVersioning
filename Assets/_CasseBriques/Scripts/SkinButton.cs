using TMPro;
using UnityEngine;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private Sprite _skin;
    [SerializeField] private TMP_Text _thisText;
    [SerializeField] private TMP_Text _otherText;
    [SerializeField] private const string NOT_SELECTED_TEXT = "SELECT";
    [SerializeField] private const string SELECTED_TEXT = "SELECTED!";

    [SerializeField] private GameObject _selectedEffect;
    [SerializeField] private GameObject _disableEffect;

    void Start()
    {
        if (_selectedEffect != null) _selectedEffect.SetActive(false);
        if (_disableEffect != null) _disableEffect.SetActive(false);
    }

    public void SelectSkin()
    {
        BallSelect.SelectSkin(_skin);
        _thisText.text = SELECTED_TEXT;
        _otherText.text = NOT_SELECTED_TEXT;

        SelectEffect();
    }

    public void SelectEffect()
    {
        if (_selectedEffect != null) _selectedEffect.SetActive(true);
        if (_disableEffect != null) _disableEffect.SetActive(false);
    }
}
