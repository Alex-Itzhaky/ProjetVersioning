using TMPro;
using UnityEngine;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private Sprite _skin;
    [SerializeField] private TMP_Text _thisText;
    [SerializeField] private TMP_Text _otherText;
    [SerializeField] private const string NOT_SELECTED_TEXT = "SELECT";
    [SerializeField] private const string SELECTED_TEXT = "SELECTED!";

    public void SelectSkin()
    {
        BallSelect.SelectSkin(_skin);
        _thisText.text = SELECTED_TEXT;
        _otherText.text = NOT_SELECTED_TEXT;
    }
}
