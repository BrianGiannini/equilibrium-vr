using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Haptic : MonoBehaviour
{
    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean trackpadAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trackpadAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
        }
        if (trackpadAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Pulse(1, 150, 75, SteamVR_Input_Sources.RightHand);
        }
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);

        print("Pulse " + source.ToString());
    }
}
