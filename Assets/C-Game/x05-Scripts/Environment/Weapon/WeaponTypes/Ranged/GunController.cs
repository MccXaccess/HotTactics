using UnityEngine;

public class GunController : MonoBehaviour
{
    public BaseGunControllerConfiguration gunConfigs;
    [Space(10)]
    [SerializeField] private Transform _gunShootPoint;

    [Header("Gun Ammo Settings")]
    [SerializeField] private int _gunTotalAmmo;
    [SerializeField] private int _gunMagCurrentAmmo;

    public Transform GunShootPoint { get => _gunShootPoint; set => _gunShootPoint = value; }

    public int GunTotalAmmo { get => _gunTotalAmmo; set => _gunTotalAmmo = value; }
    public int GunMagCurrentAmmo { get => _gunMagCurrentAmmo; set => _gunMagCurrentAmmo = value; }
}