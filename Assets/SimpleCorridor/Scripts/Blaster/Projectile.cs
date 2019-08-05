using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float m_Lifetime = 5.0f;

    private Rigidbody m_Rigidbody = null;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        SetInnactive();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SetInnactive();
    }

    public void Launch(Blaster blaster)
    {
        // Position
        transform.position = blaster.m_Barrel.position;
        transform.rotation = blaster.m_Barrel.rotation;

        // Activate
        gameObject.SetActive(true);

        // Fire, and track
        m_Rigidbody.AddRelativeForce(Vector3.forward * blaster.m_Force, ForceMode.Impulse);
        StartCoroutine(TrackLifetime());
    }

    private IEnumerator TrackLifetime()
    {
        yield return new WaitForSeconds(m_Lifetime);
        SetInnactive();
    }

    public void SetInnactive()
    {
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;

        gameObject.SetActive(false);
    }
}
