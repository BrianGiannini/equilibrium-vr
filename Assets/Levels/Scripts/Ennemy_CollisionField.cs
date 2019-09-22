using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_CollisionField : MonoBehaviour

{

    private Rigidbody rigidBodyStrikingMe;


    private void OnEnable()
    {
        SetInitialReferences();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            rigidBodyStrikingMe = other.GetComponent<Rigidbody>(); 


        }
    }

    void SetInitialReferences()
    {

    }

    void DisableThis()
    {
        gameObject.SetActive(false);
    }
}
