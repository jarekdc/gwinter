using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Update ()
    {
        Destroy(gameObject, lifetime);
	}

}
