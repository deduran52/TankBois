using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public float Impactdelay = 1;

    private void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, Impactdelay);
        }
        else if(other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject, Impactdelay);
        }
        else if(other.gameObject.CompareTag("Tank"))
        {
            Destroy(gameObject, Impactdelay);
        }

    }
    
}

