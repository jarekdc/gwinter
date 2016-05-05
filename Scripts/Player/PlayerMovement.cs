using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;
    public bool moving;
    public Transform torso;
    float mouseSphere;
    int moveDirection;
    float a;
    PlayerAttack playerAttack;
    public bool shooting;

    // Use this for initialization
    void Start () {
        playerAttack = gameObject.GetComponent<PlayerAttack>();
    }
	
	// Update is called once per frame
	void Update () {
        // Basic movement
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(speed * inputX, speed * inputY, 0) * Time.deltaTime;
        transform.Translate(movement);

        if (inputX == 0 && inputY == 0)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }

        // Speed reducing while shooting depending on the directions the character is facing and moving
        shooting = playerAttack.shooting;
        if (!shooting)
        {
            speed = 3f;
        }

        if (moving && shooting)
        {
            Vector3 torsoRotation = torso.gameObject.transform.eulerAngles;
            mouseSphere = Mathf.Floor(torsoRotation.z / 22.5f);

            if (inputX > 0 && inputY == 0)
            {
                moveDirection = 1;
            }
            else if (inputX > 0 && inputY > 0)
            {
                moveDirection = 2;
            }
            else if (inputX > 0 && inputY < 0)
            {
                moveDirection = 8;
            }
            else if (inputX == 0 && inputY > 0)
            {
                moveDirection = 3;
            }
            else if (inputX == 0 && inputY < 0)
            {
                moveDirection = 7;
            }
            else if (inputX < 0 && inputY == 0)
            {
                moveDirection = 5;
            }
            else if (inputX < 0 && inputY > 0)
            {
                moveDirection = 4;
            }
            else if (inputX < 0 && inputY < 0)
            {
                moveDirection = 6;
            }
            else
            {
                moveDirection = 0;
            }

            a = mouseSphere - (moveDirection * 2 - 2);
            if (a > 15)
            {
                a -= 16;
            }
            else if (a < 0)
            {
                a += 16;
            }

            // How much is the speed reduced: walking forwards, strafing, backwards
            if ((a >= 0 && a <= 2) || (a >= 13 && a <= 15))
            {
                speed = 2.4f;
            }
            else if (a >= 6 && a <= 9)
            {
                speed = 1f;
            }
            else
            {
                speed = 1.8f;
            }
        }
    }
}
