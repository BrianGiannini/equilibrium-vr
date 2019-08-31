using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System;

public class SpeedController : MonoBehaviour
{
    float _fixedDeltaTime;
    float _timeScale;

    public SteamVR_Action_Boolean slowMod = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    private int slowFactorTime;

    float audioClipPitch;
    float saveAudioClipPitch;


    void Start()
    {
        _fixedDeltaTime = Time.fixedDeltaTime;
        _timeScale = Time.timeScale;
        m_Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();

        audioClipPitch = GetComponent<ShootHandgun>().audioSource.pitch;
        saveAudioClipPitch = audioClipPitch;
    }

    void Update()
    {    
        // slowmo Test system
        if (slowMod.GetStateDown(m_Pose.inputSource))
        {
            if (slowFactorTime == 8)
            {
                GetComponent<ShootHandgun>().audioSource.pitch = saveAudioClipPitch;
                slowFactorTime = 0;
            } else if (slowFactorTime == 0) {
                slowFactorTime = 1;
            } else
            {
                slowFactorTime *= 2;
                GetComponent<ShootHandgun>().audioSource.pitch = (float) Math.Round(GetComponent<ShootHandgun>().audioSource.pitch * 0.7, 2);
            }

            // Time.fixedDeltaTime = _fixedDeltaTime / slowFactorTime;
            if (slowFactorTime == 0)
            {
                Time.timeScale = 0;
            } else
            {
                Time.timeScale = _timeScale / slowFactorTime;
            }
        }
    }
}
