using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public string command;
    public GameObject grabbedObject;
    int id;
    bool moving;
    bool grabbed;

    private Renderer myRenderer;
    public Color grabColor;
    private Color originalColor;
    

    void Start()
    {
        id=0;
        moving=false;
        grabbed=false;

        myRenderer = grabbedObject.GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
    }

    IEnumerator moveF(char cmd)
    {
        for(int i=0; i<50;i++)
        {
            if (cmd=='U')
            {
                transform.Translate(0,0.02f,0);
                if (grabbed) grabbedObject.transform.Translate(0,0.02f,0);
            }
            else if (cmd=='D')
            {
                transform.Translate(0,-0.02f,0);
                if (grabbed) grabbedObject.transform.Translate(0,-0.02f,0);
            }
            else if (cmd=='F')
            {
                transform.Translate(0,0,0.02f);
                if (grabbed) grabbedObject.transform.Translate(0,0,0.02f);
            }
            else if (cmd=='G') 
            {
                grabbed=true;
                myRenderer.material.color=grabColor;
            }
            else if (cmd=='R') 
            {
                grabbed=false;
                myRenderer.material.color=originalColor;
            }

            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.2f);
        moving=false;
    }

    void Update()
    {
        if (!moving)
        {
            if(id < command.Length) 
            {
                StartCoroutine(moveF(command[id]));
                Debug.Log(command[id++]);
                moving=true;
            }
        }
    }
}
