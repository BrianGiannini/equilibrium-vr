using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FadeWallSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("HeadCollider"))
        {
            SteamVR_Fade.Start(Color.black, 1f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("HeadCollider"))
        {
            SteamVR_Fade.Start(Color.clear, 1f);
        }
    }
}
