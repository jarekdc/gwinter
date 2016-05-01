using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;
    public bool moving;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate () {
        // Basic movement
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(speed * inputX, speed * inputY, 0) * Time.deltaTime;
        transform.Translate(movement);

        if(inputX == 0 && inputY == 0)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
    }
}
