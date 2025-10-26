using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public PoolManager pool;

    public PlayerController player;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
