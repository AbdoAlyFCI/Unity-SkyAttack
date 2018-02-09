using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    [SerializeField]
    private GameObject playerplace;

    [SerializeField]
    private GameObject picplace;
	void Start () {
		if(playerplace.transform.position.x>picplace.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + 30f, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (playerplace.transform.position.x > picplace.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + 30f, 0, 0);
        }
	}
}
