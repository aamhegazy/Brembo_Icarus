using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PedalsManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI displayedSpeed;
    [SerializeField]
    private float speedIncrement = 0.2f;



    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isAccelerating;

    // Start is called before the first frame update
    void Start()
    {
        isAccelerating = false;
        speed = 0;
        displayedSpeed.text = speed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAccelerating) 
        {
            speed += speedIncrement;
            displayedSpeed.text = speed.ToString();
        }
    }


    public void OnAcceleratingStarted()
    {
        isAccelerating = true;
    }

    public void OnAcceleratingStopped()
    {
        isAccelerating = false;

    }
}
