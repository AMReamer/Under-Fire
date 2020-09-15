using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	// Use this for initialization
    private int Life;
    
	void Start () {
        Life = 5;
	}
	
	// Update is called once per frame
	void Update () {
        if (Life <= 0) print("Dead");
	}

    void OnTriggerEnter2D (Collider2D touched)
    {
        print("Hit");
        if (touched.tag == "Bullet") Life--;
    }
}
