using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ball;
    Vector3 offSet;

    public float lerpRate;


    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        offSet = ball.transform.position - transform.position;

        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 position = transform.position;
        //Vector3 targetPosition = transform.position + offSet;
        Vector3 targetPosition = ball.transform.position - offSet;
        //assigning new or temp value of the camera position in the position Vector
        position = Vector3.Lerp(position, targetPosition, lerpRate * Time.deltaTime);

        transform.position = position;
    }
}
