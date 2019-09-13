using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System;

public class SpeedController : MonoBehaviour
{
    float fixedDeltaTime;
    float timeScale;

    public SteamVR_Action_Boolean slowMod = null;
    private SteamVR_Behaviour_Pose pose = null;
    private int slowFactorTime;

    float audioClipPitch;
    float saveAudioClipPitch;


    void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
        timeScale = Time.timeScale;
        pose = GetComponentInParent<SteamVR_Behaviour_Pose>();

        audioClipPitch = GetComponent<ShootHandgun>().audioSource.pitch;
        saveAudioClipPitch = audioClipPitch;
    }

    void Update()
    {    
        // slowmo Test system
        if (slowMod.GetStateDown(pose.inputSource))
        {
            if (slowFactorTime == 16)
            {
                GetComponent<ShootHandgun>().audioSource.pitch = saveAudioClipPitch;
                slowFactorTime = 0;
            } else if (slowFactorTime == 0)
            {
                slowFactorTime = 1;
            } else
            {
                slowFactorTime *= 2;
                GetComponent<ShootHandgun>().audioSource.pitch = (float) Math.Round(GetComponent<ShootHandgun>().audioSource.pitch * 0.7, 2);
            }

            if (slowFactorTime == 0)
            {
                Time.timeScale = 0;
                Time.fixedDeltaTime = Time.timeScale * .02f;
            } else
            {
                Time.timeScale = timeScale / slowFactorTime;
                Time.fixedDeltaTime = Time.timeScale * .02f;
            }
        }
    }
}
