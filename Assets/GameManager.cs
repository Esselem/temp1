using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ItemBox[] itemBoxes;
    public GameObject gameoverUI;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        int i;
        for(i=0;i<itemBoxes.Length;i++)
        {
            if (!itemBoxes[i].isOverlapped) break;
        }
        if (i==itemBoxes.Length) 
        {
            Debug.Log("Game Clear");
            isGameOver=true;
            gameoverUI.SetActive(true);
        }
    }
}
