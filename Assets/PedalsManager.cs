using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PedalsManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI displayedSpeed;
    [SerializeField]
    private float speedIncrement = 0.2f;

    [SerializeField]
    private Transform brakingGuide;


    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isAccelerating;
    private bool isBraking;
    // Start is called before the first frame update
    void Start()
    {
        isAccelerating = false;
        isBraking = false;
        speed = 0;
        displayedSpeed.text = speed.ToString();
        var oldPos = brakingGuide.localPosition;
        brakingGuide.localPosition = new Vector3(oldPos.x, oldPos.y, - 50f);
    }

    // Update is called once per frame
    void Update()
    {

        if (isAccelerating)
        {
            if (speed <= 50)
            {
                speedIncrement = 0.2f;
            }
            else if (speed > 50 && speed <= 100)
            {
                speedIncrement = 0.1f;
            }
            else if (speed > 100 && speed <= 150)
            {
                speedIncrement = 0.1f;
            }
            else
            {
                speedIncrement = 0;
            }
        }
        if (isBraking)
        {
            if (speed <= 0)
            {
                speedIncrement = 0;
            }
            else if (speed > 0 && speed <= 100)
            {
                speedIncrement = 0.2f;
            }
            else if (speed > 100 && speed <= 150)
            {
                speedIncrement = 0.1f;
            }
            else
            {
                speedIncrement = 0.05f;
            }
        }
        

        if (isAccelerating) 
        {
            speed += speedIncrement;
        }
        if (isBraking)
        {
            speed -= speedIncrement;
        }
        
        displayedSpeed.text = Math.Round(speed).ToString();


        var oldPos = brakingGuide.localPosition;
        brakingGuide.localPosition = new Vector3(oldPos.x, oldPos.y, speed/3.0f-50f);

    }


    public void OnAcceleratingStarted()
    {
        isAccelerating = true;
    }

    public void OnAcceleratingStopped()
    {
        isAccelerating = false;

    }

    public void OnBrakingStarted()
    {
        isBraking = true;
    }

    public void OnBrakingStopped()
    {
        isBraking = false;

    }
}
