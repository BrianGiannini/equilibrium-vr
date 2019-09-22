using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollActivation : MonoBehaviour
{

    private Collider myCollider;
    private Rigidbody myRigidbody;
    public List<Collider> collidingParts = new List<Collider>();
    public Animator animator;


    private void Awake()
    {
        SetInitialReferences();
    }

        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet_45mm_Bullet(Clone)") { 
            Debug.Log("enter collision");
            ActivateRagdoll();
            // how much the character should be knocked back
            var magnitude = 10000;
            // calculate force vector
            var force = transform.position - collision.transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
        }
    }

    void SetInitialReferences()
    {
        /*
        if(GetComponent<Collider>() != null)
        {
            myCollider = GetComponent<Collider>();
        }

        if (GetComponent<Rigidbody>() != null)
        {
            myRigidbody = GetComponent<Rigidbody>();
        }
        */
        Collider[] collidersChildren = this.gameObject.GetComponentsInChildren<Collider>();
        Collider[] collidersParents = this.gameObject.GetComponentsInParent<Collider>();

        collidingParts.AddRange(collidersChildren);
        collidingParts.AddRange(collidersParents);
    }

    void ActivateRagdoll()
    {
        animator.enabled = false;
        animator.avatar = null;

        foreach (Collider c in collidingParts)
        {
            c.isTrigger = false;
            c.attachedRigidbody.velocity = Vector3.zero;
        }
        /*
        if (myRigidbody != null)
        {
            Debug.Log("activate rigidbody");

            myRigidbody.isKinematic = false;
            myRigidbody.useGravity = true;
        }

        if (myCollider != null)
        {
            Debug.Log("activate collider");

            myCollider.isTrigger = false;
            myCollider.enabled = true;
        }
        */
    }
}
