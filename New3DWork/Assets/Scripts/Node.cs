using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
   
    private Rect rect;

    public GUIStyle style;

    public Node(Vector2 Position, float Width, float Height, GUIStyle DefaultStyle)
    {
        rect = new Rect(Position.x, Position.y, Width, Height);

        style = DefaultStyle;
    }

    public void Drag(Vector2 Delta)
    {
        rect.position += Delta;
    }

    public void Draw()
    {
        GUI.Box(rect, "", style);
    }

    public void SetStyle(GUIStyle NodeStyle)
    {
        style = NodeStyle;
    }

}
