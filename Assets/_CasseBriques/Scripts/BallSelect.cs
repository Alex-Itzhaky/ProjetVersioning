using UnityEngine;

public class BallSelect : MonoBehaviour
{
    public static Sprite CurrentSkin { get; private set; }
    
    public static void SelectSkin(Sprite skin) => CurrentSkin = skin;
}
