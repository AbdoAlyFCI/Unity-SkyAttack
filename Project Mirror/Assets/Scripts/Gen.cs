using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen : MonoBehaviour {

    [SerializeField]
    private float UpEdge;   //اقصي ارتفاع

    [SerializeField]
    private float DownEdge;    //ادني ارتفاع

    public GameObject[] objecttogen;  //الاشياء المراد انتاجها

    public float spawnMin = 1f;  //ادني وقت
    public float spawnMax = 2f;  //اقصي وقت

	// Use this for initialization
	void Start () {

        Spawn();
	}
	
    private void Spawn()
    {
        transform.position = new Vector3(transform.position.x + 5, Random.Range(DownEdge, UpEdge), transform.position.z);
        Instantiate(objecttogen[Random.Range(0, objecttogen.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin,spawnMax));
    }


}
