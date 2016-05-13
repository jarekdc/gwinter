using UnityEngine;
using System.Collections;

public class THHammer : MonoBehaviour {

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public int damage = 100;
    public Collider2D hitRange;
    Animator anim;

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
            anim.SetTrigger("meleeAttack");
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<Health>().Damage(damage);
            Debug.Log("Im hit");
        }
    }
}
