using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float attackPoint;

    public int penetratePoint;

    public void Init(float AttackPoint, int PenetratePoint)
    {
        this.attackPoint = AttackPoint;
        this.penetratePoint = PenetratePoint;
    }

}
