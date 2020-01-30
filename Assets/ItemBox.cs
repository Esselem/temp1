using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOverlapped=false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GoalPoint")
        {
            Debug.Log("gp1");
            isOverlapped=true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "GoalPoint")
        {
            Debug.Log("gp2");
            isOverlapped=false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "GoalPoint")
        {
            isOverlapped=true;
        }
    }
}

