using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform pfWeaponLeft;
    [SerializeField] private Transform pfWeaponRight;
    private void Awake()
    {
        GetComponent<PlayerAimWeapon>().OnShootLeft += PlayerShooting_OnShootLeft;
        GetComponent<PlayerAimWeapon>().OnShootRight += PlayerShooting_OnShootRight;
    }

    private void PlayerShooting_OnShootLeft(object sender, PlayerAimWeapon.OnShootEventArgs e)
    {
        Transform bulletTransform = Instantiate(pfWeaponLeft, e.endPointPosition, Quaternion.identity);

        Vector3 shootDir = (e.shootPosition - e.endPointPosition).normalized;
        bulletTransform.GetComponent<FireBall>().Setup(shootDir);

    }

    private void PlayerShooting_OnShootRight(object sender, PlayerAimWeapon.OnShootEventArgs e)
    {
        Transform bulletTransform = Instantiate(pfWeaponRight, e.endPointPosition, Quaternion.identity);

        Vector3 shootDir = (e.shootPosition - e.endPointPosition).normalized;
        bulletTransform.GetComponent<IceBolt>().Setup(shootDir);

    }
}
