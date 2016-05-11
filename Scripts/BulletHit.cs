using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log(coll.gameObject.tag);
        }        
    }
}
