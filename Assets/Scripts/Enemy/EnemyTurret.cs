using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyShoot))]
public class EnemyTurret : Enemy
{
    public float projectileFireRate;
    float timeSinceLastFire;
    EnemyShoot shootScript;
    public Transform player;
    private bool isFlipped;
    private float distanceFromPlayer;
    public Transform rangeLeft;
    public Transform rangeRight;

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);

        if (curClips[0].clip.name != "Shoot")
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetTrigger("Shoot");
            }
        }

        distanceFromPlayer = (player.position.x - transform.position.x);

        if (distanceFromPlayer >= 0 && isFlipped == false)
        {
            sr.flipX = !sr.flipX;
            isFlipped = true;
        }
        else if (distanceFromPlayer <= 0 && isFlipped == true)
        {
            sr.flipX = !sr.flipX;
            isFlipped = false;
        }

        if (player.position.x - rangeLeft.position.x < 0)
        {
            anim.SetBool("NotInRange", true);
        }
        else if (player.position.x - rangeRight.position.x > 0)
        {
            anim.SetBool("NotInRange", true);
        }
        else 
        {
            anim.SetBool("NotInRange", false);
        }
    }

    public override void Start()
    {
        base.Start();

        shootScript = GetComponent<EnemyShoot>();
        shootScript.OnProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
        
    }

    public override void Death()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        shootScript.OnProjectileSpawned.RemoveListener(UpdateTimeSinceLastFire);
    }

    void UpdateTimeSinceLastFire()
    {
        timeSinceLastFire = Time.time;
    }
}
