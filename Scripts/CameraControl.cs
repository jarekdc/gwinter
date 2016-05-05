using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public GameObject player;
    public float mFollowRate = 1.0f;
    public bool followPlayer = true;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		Camera.main.orthographicSize = 4f;
	}
	
	// Update is called once per frame
	void Update () {
        if (followPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 0, -10), Time.deltaTime * mFollowRate);
        }
    }

    public void setFollowPlayer(bool val)
    {
        followPlayer = val;
    }
 }
