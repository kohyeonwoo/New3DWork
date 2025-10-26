using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnData
{
    public int unitType;
    public float spawnTime;
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

        level = Mathf.FloorToInt(GameManager.Instance.gameTime / 10.0f);

        if (timer > (level == 0 ? 0.5f : 0.2f))
        {
            timer = 0.0f;
            Spawn();
        }

    }

    private void Spawn()
    {
        GameObject enemy = GameManager.Instance.pool.Get(level);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }

}
