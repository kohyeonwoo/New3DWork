using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rigid;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private FixedJoystick joystick;

    [SerializeField]
    private float moveSpeed;

    public float maxHealth;

    public float currentHealth;

    private void Start()
    {
        maxHealth = currentHealth;

        rigid = this.GetComponent<Rigidbody>();

        animator = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector3(joystick.Horizontal * moveSpeed,
           rigid.velocity.y, joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            this.transform.rotation = Quaternion.LookRotation(rigid.velocity);

            animator.SetBool("bMove", true);
        }
        else
        {
            animator.SetBool("bMove", false);
        }
    }

}
