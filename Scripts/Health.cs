using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int currentHealth;
    public int maxHealth = 100;
    public int minHealth = 1;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Damage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < minHealth)
        {
            currentHealth = 0;
            Debug.Log("I'm dead");
        }
    }
}
