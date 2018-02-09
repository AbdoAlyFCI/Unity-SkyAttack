using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bar_time : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}
    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }

    private float Map(float value, float inMin, float inMAX, float outMIN, float outMAX)
    {
        return (value - inMin) * (outMAX - outMIN) / (inMAX - inMin) + outMIN;
    }
}
