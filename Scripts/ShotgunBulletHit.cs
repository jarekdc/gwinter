using UnityEngine;
using System.Collections;

public class ShotgunBulletHit : MonoBehaviour {

    public int bulletDamage = 10;
    public ParticleSystem bloodShotgun;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<Health>().Damage(bulletDamage);
            Instantiate(bloodShotgun, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.z + 180f, 270f, 180f));
            Destroy (gameObject, 0.1f);    
        }        
    }
}
