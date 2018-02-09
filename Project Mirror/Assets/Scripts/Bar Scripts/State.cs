using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class State {
    [SerializeField]
    private bar_time bar;

    [SerializeField]
    private float maxVAL;


    public float MaxVAL
    {
        get { return maxVAL; }
        set
        {
            maxVAL = value;
            bar.MaxValue = maxVAL;
        }
    }
    [SerializeField]
    private float currentVAL;

    public float CurrentVAL
    {
        get { return currentVAL; }
        set
        {
            currentVAL = value;
            bar.Value = currentVAL;
        }
    }

    public void Initialize()
    {
        this.MaxVAL = maxVAL;
        this.CurrentVAL = CurrentVAL;
    }
}
