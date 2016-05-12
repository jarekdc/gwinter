﻿using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

    public int bulletDamage = 10;
    public ParticleSystem bloodShotgun;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<Health>().Damage(bulletDamage);
            Instantiate(bloodShotgun, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.z + 180f, 270f, 180f));
            Destroy (gameObject);    
        }        
    }
}
