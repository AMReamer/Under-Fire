using UnityEngine;
using System.Collections;

public class Clear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(transform.position.y) > 15.0f || Mathf.Abs(transform.position.x) > 15.0f) Destroy(gameObject);
	}
}
