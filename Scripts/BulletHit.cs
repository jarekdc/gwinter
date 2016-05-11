using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

    public int bulletDamage = 10;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<Health>().Damage(bulletDamage);
            Destroy (gameObject);        
        }        
    }
}
