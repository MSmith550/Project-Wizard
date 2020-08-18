using System;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAimWeapon : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShootLeft;
    public event EventHandler<OnShootEventArgs> OnShootRight;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 endPointPosition;
        public Vector3 shootPosition;
    }

    private Transform aimTransform;
    public Transform firePoint;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");

        //currently not working, not finding automaticlly
        //firePoint = transform.Find("FirePoint");
    }

    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }
    //aim if the weapon
    private void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDir = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    //handles the shooting
    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            OnShootLeft?.Invoke(this, new OnShootEventArgs
            {
                endPointPosition = firePoint.position,
                shootPosition = mousePosition,
            });
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            OnShootRight?.Invoke(this, new OnShootEventArgs
            {
                endPointPosition = firePoint.position,
                shootPosition = mousePosition,
            });
        }

    }
}
