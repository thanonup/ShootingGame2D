using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerCRL playerA;

    void Update()
    {
        if(playerA.Notshoot == true)
        {
            if (Input.GetButtonDown("Fire1")) { Shoot(); playerA.Shoota(); }
            else { playerA.Shootstop(); }
        }     
    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
