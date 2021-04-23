﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("等級")]
    [Tooltip("這是角色的等級")]
    public int lv = 1;
    [Header("移動速度"), Range(0, 300)]
    public float speed = 10.5f;
    public bool isDead = false;
    [Tooltip("這是角色的名稱")]
    public string cName = "男孩";
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形物件")]
    public Transform tra;
    [Header("偵測範圍")]
    public float rangeAttack = 2.5f;


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.4f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }


    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;
      

        tra.Translate(h * speed * Time.deltaTime, 0, 0);

       
    }

    private void Attack()
    {

    }

    private void  Hit()
    {
        
    }

    private void Dead()
    {

    }

    //
    private void Start()
    {
       
    }

    private void Update()
    {
        Move();
    }
}
