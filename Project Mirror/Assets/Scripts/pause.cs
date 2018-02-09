using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pause : MonoBehaviour {

    private Button yourButton;
    Button btn;

    void Start()
    {
         btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(Time.timeScale==1)
        {
            
            Time.timeScale = 0;

        }
        else if(Time.timeScale==0)
        {
            Time.timeScale = 1;
        }
    }
}
