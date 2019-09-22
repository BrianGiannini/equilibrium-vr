using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public List<T> Create<T>(GameObject prefab, int count)
         where T : MonoBehaviour
    {
        // New list
        List<T> newPool = new List<T>();

        // Create
        for (int i = 0; i < count; i++)
        {
            GameObject projectileObject = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            T newProjectile = projectileObject.GetComponent<T>();

            newPool.Add(newProjectile);
        }

        return newPool;
    }
}

public class ProjectilePool : Pool
{
    public List<Projectile> m_Projectiles = new List<Projectile>();

    public ProjectilePool(GameObject prefab, int count)
    {
        m_Projectiles = Create<Projectile>(prefab, count);
    }

    public void SetAllProjectiles()
    {
        foreach (Projectile projectile in m_Projectiles)
            projectile.SetInnactive();
    }
}
