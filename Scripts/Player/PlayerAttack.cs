using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {

    public List<GameObject> meleeWeapons = new List<GameObject>();
    public List<GameObject> rangedWeapons = new List<GameObject>();
    public GameObject currentMeleeWeapon;
    public GameObject currentRangedWeapon;

    public bool shooting = false;
    public bool attack = false;
    Animator anim;
    

	// Use this for initialization
	void Start ()
    {
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        attack = Input.GetMouseButton(0);
        shooting = Input.GetMouseButton(1);
        anim.SetBool("shooting", shooting);

        if(attack)
        {
            if (shooting)
            {
                currentRangedWeapon.SendMessage("Attack");
            }
            else
            {
                currentMeleeWeapon.SendMessage("Attack");
            }           
        }
    }
}
