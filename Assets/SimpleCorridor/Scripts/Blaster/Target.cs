using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Color m_FlashDamageColor = Color.white;

    private MeshRenderer m_MeshRenderer = null;
    private Color m_OriginalColor = Color.white;

    private int m_MaxHealth = 2;
    private int m_Health = 0;

    private void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_OriginalColor = m_MeshRenderer.material.color;
    }

    private void OnEnable()
    {
        ResetHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
            Damage();
    }

    private void Damage()
    {
        StopAllCoroutines();
        StartCoroutine(Flash());

        RemoveHealth();
    }

    private IEnumerator Flash()
    {
        m_MeshRenderer.material.color = m_FlashDamageColor;

        WaitForSeconds wait = new WaitForSeconds(0.1f);
        yield return wait;

        m_MeshRenderer.material.color = m_OriginalColor;
    }

    private void RemoveHealth()
    {
        m_Health--;
        CheckForDeath();
    }

    private void ResetHealth()
    {
        m_Health = m_MaxHealth;
    }

    private void CheckForDeath()
    {
        if (m_Health <= 0)
            Kill();
    }

    private void Kill()
    {
        gameObject.SetActive(false);
    }
}
