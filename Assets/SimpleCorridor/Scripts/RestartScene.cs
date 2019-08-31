using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
using System;

public class RestartScene : MonoBehaviour
{
    public SteamVR_Action_Boolean restartButton = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    void Start()
    {
        m_Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
    }

    void Update()
    {
        if (restartButton.GetStateDown(m_Pose.inputSource))
        {
            Debug.Log("restart ");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}
