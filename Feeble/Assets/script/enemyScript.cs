using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyScript : MonoBehaviour
{
    private Transform player;
    private float dis;
    public float moveSpeed;
    public float enemyRadius;

     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }


     void Update()
    {
        dis = Vector3.Distance(player.position, transform.position);
        if(dis <= enemyRadius)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }


        

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyRadius);
    }
}


