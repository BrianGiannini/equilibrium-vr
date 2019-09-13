using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;


    public float shotPower = 100f;
    private readonly float explosionPower = 15f;
    private readonly float explosionRadius = 1f;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
     
    }

    void Shoot()
    {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        GameObject tempFlash;
       Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>()
            .AddForce(barrelLocation.forward * shotPower, ForceMode.VelocityChange); //VeocityChange ignore mass, Impulse using mass
       tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

       // Destroy(tempFlash, 0.5f);
        //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
       
    }

    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        // AddExplosionForce : Power, transform.position, radius
        casing.GetComponent<Rigidbody>()
            .AddExplosionForce(explosionPower, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f),
            explosionRadius, 0, ForceMode.VelocityChange); 
        casing.GetComponent<Rigidbody>()
            .AddTorque(new Vector3(0, Random.Range(10f, 50f), Random.Range(1f, 100f)), ForceMode.VelocityChange);
    }


}
