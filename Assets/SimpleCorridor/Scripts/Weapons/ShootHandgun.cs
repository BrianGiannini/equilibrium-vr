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
            if (Time.timeScale != 0)
            {
                animator.SetBool("Fire", true);
                Fire();
            }
        }

        if (fireAction.GetStateUp(m_Pose.inputSource))
        {
            animator.SetBool("Fire", false);
        }
    }

    private void Fire()
    {
        // play fire sound
        audioSource.PlayOneShot(audioClip, 0.05F);
        // StartCoroutine(ShakeHaptic());
        //Pulse(0.2f, 150, 0.1f, SteamVR_Input_Sources.LeftHand);

    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticVibrationAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse " + source.ToString());
    }

    IEnumerator ShakeHaptic()
    {
        // wait time before shake controller
        yield return new WaitForSeconds(0.1f);
        Pulse(0.2f, 150, 0.1f, SteamVR_Input_Sources.RightHand);
    }

}
