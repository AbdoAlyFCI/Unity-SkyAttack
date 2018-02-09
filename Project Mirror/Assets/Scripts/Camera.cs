using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    [SerializeField]
    private Transform playerPostion;   //نجيب موضع الاعب في كل مره

	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerPostion.position.x + 4.5f, 0, -10);
	}
}
