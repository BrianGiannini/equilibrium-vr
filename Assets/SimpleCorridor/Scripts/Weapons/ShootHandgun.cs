using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System;


public class ShootHandgun : MonoBehaviour

{
    private bool isReloading = false;
    public SteamVR_Action_Boolean fireAction = null;
    private Animator animator = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        m_Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if (fireAction.GetStateDown(m_Pose.inputSource))
        {
            if (Time.timeScale != 0)
            {
                animator.SetBool("Fire", true);
                Fire();
            }
        }
    }

    private void Fire()
    {
        // audioSource.pitch = (float) Math.Round(audioSource.pitch * 0.8, 2);
        audioSource.PlayOneShot(audioClip, 0.5F);            
     }
}
