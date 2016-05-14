using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class THHammer : MonoBehaviour {

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public int damage = 100;
    public Collider2D hitRange;
    public List<GameObject> targetsHit;
    Animator anim;
    public ParticleSystem meleeBlood;

    void Start()
    {
        hitRange.enabled = false;
        anim = GetComponentInParent<Animator>();
    }

    void Attack()
    {
        if (Time.time > nextFire && !anim.GetCurrentAnimatorStateInfo(0).IsName("THHammerAttack"))
        {
            nextFire = Time.time + fireRate;
            targetsHit.Clear();
            anim.SetTrigger("meleeAttack");
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            GameObject go = coll.gameObject;
            if(!targetsHit.Contains(go))
            {
                targetsHit.Add(go);
                go.GetComponent<Health>().Damage(damage);
                Instantiate(meleeBlood, go.transform.position, Quaternion.identity);
                Debug.Log("Im hit");
            }            
        }
    }
}
