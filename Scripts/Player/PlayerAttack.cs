using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public bool shooting = false;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        shooting = Input.GetMouseButton(1);
        anim.SetBool("shooting", shooting);
    }
}
