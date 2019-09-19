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
    public SteamVR_Action_Vibration hapticVibrationAction;

    void Start()
    {
        m_Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isReloading)
            return;

        if (fireAction.GetStateDown(m_Pose.inputSource))
        {
            // shoot when not in pause time
            //print("Fire triggered " + animator.GetBool("Fire"));

            print("Down");

            if (Time.timeScale != 0 && animator.GetBool("Fire") == false)
            {
                Fire();
            }
        }

        if (fireAction.GetStateUp(m_Pose.inputSource))
        {
            print("Up");
            // animator.SetBool("Fire", false);

        }
    }

    private void Fire()
    {
        print("FIRE !");
        animator.SetBool("Fire", true);
        // play fire sound
        StartCoroutine(PlaySound());        
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(0.05f);
        audioSource.PlayOneShot(audioClip, 0.1F);
        //Pulse(1, 150, 75, SteamVR_Input_Sources.RightHand);
    }

    private void SetReady() {
        animator.SetBool("Fire", false);
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticVibrationAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse " + source.ToString());
    }

}
