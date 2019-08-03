using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pauseGame()
    {
        Debug.Log("entered");
        Time.timeScale = 0.05f;
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        pauseGame();
    }


   
}
