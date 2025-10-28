using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public int id;
    public int prefabId;
    public float attackPoint;
    public int count;
    public float speed;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        switch (id)
        { 
             case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
          default:
                break;
        }

    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 50;
                Batch();
                break;
            default:
                break;
         
        }

    }

    private void Batch()
    {
        for(int i = 0; i < count; i++)
        {
            Transform bullet = GameManager.Instance.pool.Get(prefabId).transform;
            bullet.parent = transform;
            bullet.GetComponent<Bullet>().Init(attackPoint, -1);
        }
    }

}
