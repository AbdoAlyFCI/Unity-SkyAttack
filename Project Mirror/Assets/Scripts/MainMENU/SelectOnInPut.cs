using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SelectOnInPut : MonoBehaviour {

    public EventSystem events;
    public GameObject select;
    private bool Bselect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Vertical")!=0&&Bselect==false)
        {
            events.SetSelectedGameObject(select);
            Bselect = true;
        }
	}
    private void OnDisable()
    {
        Bselect = false;
    }
}
