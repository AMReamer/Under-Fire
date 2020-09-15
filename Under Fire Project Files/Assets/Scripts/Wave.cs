using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
    private Rigidbody2D body;
	// Use this for initialization
	void Start () 
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.y >= 3.2f) body.velocity = new Vector2(2, -5);
        if (transform.position.y <= -3.2f) body.velocity = new Vector2(2, 5);
	}
}
