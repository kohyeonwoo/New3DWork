using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public GameObject[] prefabs;

    private List<GameObject>[] pools;

    private void Awake()
    {

        pools = new List<GameObject>[prefabs.Length];
    
        for(int i =0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }

        Debug.Log(pools.Length);
    }

    public GameObject Get(int Index)
    {
        GameObject select = null;

        foreach(GameObject Item in pools[Index])
        {
            if(!Item.activeSelf)
            {
                select = Item;
                select.SetActive(true);
                break;
            }
        }

        if(!select)
        {
            select = Instantiate(prefabs[Index], transform);
            //select = Instantiate(prefabs[Index]);
            pools[Index].Add(select);
        }

        return select;
    }

}
