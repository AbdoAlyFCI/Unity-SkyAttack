using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiserAttack : MonoBehaviour {

    [SerializeField]
    float LiserSpeed;


    private Rigidbody2D LiserBody;

    private Vector2 LiserVector;

    private Player getit;
	void Start () {
        getit = GameObject.Find("player").GetComponent<Player>();
        LiserBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        LiserBody.velocity = LiserVector * LiserSpeed;
		
	}
    public void Initialize(Vector2 vector)
    {
        this.LiserVector = vector;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="star")
        {
            getit.score += 10;   
            Destroy(gameObject);
        }
        if(other.tag=="mirror")
        {
            getit.score += 5;
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
