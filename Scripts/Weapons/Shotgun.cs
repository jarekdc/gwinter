using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour {

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public GameObject ShotgunBullet;
    public float speed = 10f;
    public float spreadRange = 10f;
    public int bulletsQuantity = 20;

    void Attack()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            for (int i = 0; i < bulletsQuantity; i++)
            {
                GameObject bullet = (GameObject)Instantiate(ShotgunBullet, transform.position, transform.rotation);                
                float spread = Random.Range(-spreadRange, spreadRange);
                bullet.transform.Rotate(0f, 0f, spread);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * speed;
                Destroy(bullet, 1f);
            }            
        }
    }
}
