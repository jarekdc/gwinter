using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour{

    public float speed;
    public float maxSpeed = 3f;
    public bool moving;
    public Transform torso;
    float mouseSphere;
    int moveDirection;
    float inputX;
    float inputY;
    float a;
    PlayerAttack playerAttack;
    public bool shooting;

    // Use this for initialization
    void Start()
    {
        playerAttack = gameObject.GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ControlShooting();
    }

    void MovePlayer()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

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

        Vector3 input = new Vector3(inputX, inputY);
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;

        transform.Translate(moveAmount);

        if (inputX == 0 && inputY == 0)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
    }

    void ControlShooting()
    {
        // Speed reducing while shooting depending on the directions the character is facing and moving
        shooting = playerAttack.shooting;
        if (!shooting)
        {
            speed = maxSpeed;
        }

        if (moving && shooting)
        {
            Vector3 torsoRotation = torso.gameObject.transform.eulerAngles;
            mouseSphere = Mathf.Floor(torsoRotation.z / 22.5f);

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
                speed = (float)0.8 * maxSpeed;
            }
            else if (a >= 6 && a <= 9)
            {
                speed = (float)0.4 * maxSpeed;
            }
            else
            {
                speed = (float)0.6 * maxSpeed;
            }
        }
    }
}