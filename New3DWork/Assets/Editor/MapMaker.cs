using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEditor;
using System;

public class MapMaker : EditorWindow
{
  
  private Vector2 offset;

  private Vector2 drag;

  private List<List<Node>> nodes;

  private GUIStyle empty;

  Vector2 nodePos;

  [MenuItem("Window/MapMaker")]
  private static void OpenWindow()
  {
    MapMaker window = GetWindow<MapMaker>();
    window.titleContent = new GUIContent("Map Maker");
  }

  private void OnEnable()
  {
    empty = new GUIStyle();

    Texture2D icon = Resources.Load("IconText/Empty") as Texture2D;

    empty.normal.background = icon;

    SetUpNodes();
  }

  private void SetUpNodes()
  {
    nodes = new List<List<Node>>();

    for(int i =0; i < 20; i++)
    {
        nodes.Add(new List<Node>());

        for(int j = 0; j < 10; j++)
        {
          nodePos.Set(i * 30, j * 30);

          nodes[i].Add(new Node(nodePos, 30,30, empty));
        }
    }
  }

  private void OnGUI()
  {
    
    DrawGrid();
    DrawNodes();
    ProcessGrid(Event.current);

    if(GUI.changed)
    {
        Repaint();
    }
  }

  private void ProcessGrid(Event E)
  {
    
    drag = Vector2.zero;

    switch(E.type)
    {
        case EventType.MouseDrag :

        if(E.button == 0)
        {
            OnMouseDrag(E.delta);
        }

        break;
    }

  }

  private void DrawNodes()
  {
    for(int i =0; i < 20; i++)
    {
        for(int j = 0; j < 10; j++)
        {
            nodes[i][j].Draw();
        }
    }
  }

  private void OnMouseDrag(Vector2 Delta)
  {
    drag = Delta;

    GUI.changed = true;
  }

  private void DrawGrid()
  {
    
    int widthDivider = Mathf.CeilToInt(position.width / 20);

    int heightDivider = Mathf.CeilToInt(position.height / 20);

    Handles.BeginGUI();

    Handles.color = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    offset += drag;

    Vector3 newOffset = new Vector3(offset.x % 20, offset.y % 20, 0);

    for(int i =0; i < widthDivider; i++)
    {
        Handles.DrawLine(new Vector3(20 *i, -20, 0) + newOffset, new Vector3(20 * i, position.height, 0) + newOffset);
    }

    for(int i =0; i < heightDivider; i++)
    {
         Handles.DrawLine(new Vector3(-20 , 20*i, 0) + newOffset, new Vector3(position.width, 20*i, 0) + newOffset);
    }

    Handles.color = Color.white;
    Handles.EndGUI();

  }


}
