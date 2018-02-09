using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour {

    private Rigidbody2D starmove; //علشان تتحرك نحيه الشمال
    [SerializeField]
    private float starspeed;
	// Use this for initialization
	void Start () {
        starmove = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        starmove.velocity = Vector2.left * starspeed ;
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="liser")
        {
            Destroy(gameObject);
        }
    }
}
