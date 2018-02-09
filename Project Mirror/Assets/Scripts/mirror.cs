using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "liser")
        {
            Destroy(gameObject);
        }
    }
}
