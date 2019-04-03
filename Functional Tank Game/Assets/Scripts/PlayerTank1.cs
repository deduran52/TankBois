using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank1 : MonoBehaviour
{
    /* Private Variables */
    Transform target;
    PlayerTank2 opponentScript;

    /* Player Variables */
    public GameObject player;
    public float tankSpeed = 2.0f;
    public float startHealth = 100;
    public float currentHealth;
    public Image healthBar;

    /* Projectile Variable */
    public Rigidbody2D projectile;
    public GameObject projectileEmitter;
    public float projectileSpeed = 250;
    public float impactDelay;
    public bool firedProjectile;

    /* Turret Rotation */
    public GameObject turretRotation;
    public int turretAngle = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player2").transform;
        opponentScript = GameObject.FindWithTag("Player2").GetComponent<playerController2>();

        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /* Movement Controls */
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        /* Turret Controls */
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (turretAngle <= 180)
            {
                turretRotation.transform.Rotate(0, 0, 1);
                ++turretAngle;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (turretAngle > 0)
            {
                turretRotation.transform.Rotate(0, 0, -1);
                --turretAngle;
            }
        }

        /* Cannon Controls */
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D iP = Instantiate(projectile, projectileEmitter.transform.position, projectileEmitter.transform.rotation) as Rigidbody2D;
            iP.AddForce(projectileEmitter.transform.right * projectileSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (projectileSpeed <= 500)
                projectileSpeed += 25;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (projectileSpeed >= 0)
                projectileSpeed -= 25;
        }

        /* Destroying Tank */
        if(currentHealth = 0)
        {
            Destroy(GameObject);
            
        }

    }

    /* Damage Detection */
    void OnCollision2D(Collision2D coll)
    {

    }
}
