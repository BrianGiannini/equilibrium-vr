using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


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
            animator.SetBool("Fire", true);
            Fire();
        }

       

    }

    private void Fire()
    {
        audioSource.PlayOneShot(audioClip, 0.5F);            
     }
}
