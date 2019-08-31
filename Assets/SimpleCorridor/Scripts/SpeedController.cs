using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SpeedController : MonoBehaviour
{
    float _fixedDeltaTime;
    float _timeScale;
    public SteamVR_Action_Boolean slowMod = null;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.fixedDeltaTime = _fixedDeltaTime;
            Time.timeScale = _timeScale;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.fixedDeltaTime = _fixedDeltaTime / 2;
            Time.timeScale = _timeScale / 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Time.fixedDeltaTime = _fixedDeltaTime / 5;
            Time.timeScale = _timeScale / 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Time.fixedDeltaTime = _fixedDeltaTime / 10;
            Time.timeScale = _timeScale / 10;
        }
    }
}
