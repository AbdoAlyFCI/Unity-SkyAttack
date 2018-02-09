using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour {
     public Text test;
     [SerializeField]
     private GameObject player;

     private Player getit;
	// Use this for initialization
	void Start () {
        test = gameObject.GetComponent<Text>();
        getit = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        test.text = (getit.score).ToString();

	}
}
