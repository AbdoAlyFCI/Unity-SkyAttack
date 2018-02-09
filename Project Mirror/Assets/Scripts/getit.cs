using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getit : MonoBehaviour {
    private int hscore;
    private Text test;
	// Use this for initialization
	void Start () {
        test = gameObject.GetComponent<Text>();

        if (PlayerPrefs.HasKey("hscore"))
        {
            hscore = PlayerPrefs.GetInt("hscore");
        }
	}
	
	// Update is called once per frame
	void Update () {
        test.text = hscore.ToString();
	}
}
