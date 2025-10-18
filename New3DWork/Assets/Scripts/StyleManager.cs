using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ButtonStyle
{
    public Texture2D icon;
    public string buttonText;

    [HideInInspector]
    public GUIStyle nodeStyle;
}

public class StyleManager : MonoBehaviour
{
   public ButtonStyle[] buttonStyles;
}

