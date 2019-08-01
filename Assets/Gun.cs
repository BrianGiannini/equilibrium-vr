using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Gun : MonoBehaviour
{
    private SteamVR_TrackedController Controller;
    private bool audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Controller = GetComponent<SteamVR_TrackedController>();
        //Controller.PadClicked += onPadClicked;
        //Controller.PadUnclicked += onPadUnclicked;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
