using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        playerHealth health = coll.gameObject.GetComponent<playerHealth>();
        if(health)
        {
            health.HurtPlayer(1);
        }

        Destroy(gameObject);
    }
}
