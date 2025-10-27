using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int unitType;
    public int health;
    public float speed;
}

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;

    public SpawnData[] spawnData;

    private int level;

    private float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {

        timer += Time.deltaTime;

        //level = Mathf.Min(Mathf.FloorToInt(GameManager.Instance.gameTime / 10.0f), spawnData.Length - 1);

        level = Mathf.Min(Mathf.FloorToInt(GameManager.Instance.gameTime / 10.0f), spawnData.Length - 1);

        if (timer > spawnData[level].spawnTime)
        {
            timer = 0.0f;
            Spawn();
        }

    }

    private void Spawn()
    {
        GameObject enemy = GameManager.Instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }

}
