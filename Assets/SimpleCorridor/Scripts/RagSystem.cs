using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagSystem : MonoBehaviour
{
    public List<Collider> ragdollParts = new List<Collider>();
    public List<Collider> collidingParts = new List<Collider>();

    public Animator animator;
    private Rigidbody rigid;
    public Rigidbody RIGID_BODY
    {
        get
        {
            if (rigid == null)
            {
                rigid = GetComponent<Rigidbody>();
            }
            return rigid;
        }
    }

    private void Awake()
    {
        SetRagdollParts();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("entering trigger " + collider.gameObject.name);

        if (ragdollParts.Contains(collider))
        {
            return;
        }


        /*
        if (!collidingParts.Contains(collider))
        {
            collidingParts.Add(collider);
        }*/
    }
    /*
    private void OnTriggerExit(Collider collider)
    {
        if (collidingParts.Contains(collider))
        {
            collidingParts.Remove(collider);
        }
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "Bullet_45mm_Bullet(Clone)")
        {
            TurnOnRagdoll();
        }
    }

    private void SetRagdollParts()
    {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

        foreach(Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                c.isTrigger = true;
                ragdollParts.Add(c);
            }
        }
    }

    private void TurnOnRagdoll()
    {
        Debug.Log("Ragdoll turned on");
        RIGID_BODY.useGravity = false;
        RIGID_BODY.velocity = Vector3.zero;


        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        animator.enabled = false;
        animator.avatar = null;

        foreach(Collider c in ragdollParts)
        {
            c.isTrigger = false;
            c.attachedRigidbody.velocity = Vector3.zero;
        }
    }

}
