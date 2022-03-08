using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{

    //public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("PlatformFall", 0.5f);

            //Debug.Log("Hello");
            //PlatformFall();
        }
    }

    void PlatformFall()
    {
        //if (!isGameOver)
        //{
        //GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;

        Destroy(transform.parent.gameObject, 1.0f);

        //isGameOver = true;
        //}
        //else if(isGameOver)
        //{
        //    GetComponentInParent<Rigidbody>().useGravity = false;
        //    GetComponentInParent<Rigidbody>().isKinematic = true;
        //}
    }
}
