using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public int speed;
    Rigidbody2D body;
	// Use this for initialization
	void Start () {
         body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
        else if (Input.GetKey("down") || Input.GetKey("s"))
        {
            body.velocity = new Vector2(body.velocity.x, -speed);
        }
        else
        {
            body.velocity = new Vector2(body.velocity.x, 0.0f);
        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
        else if (Input.GetKey("left") || Input.GetKey("a"))
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(0.0f, body.velocity.y);
        }
	}
}
