using UnityEngine;

[CreateAssetMenu(fileName = "Gun Configuration", menuName = "Base Weapon Controller/Guns/Create New Configuration", order = 0)]
public class BaseGunControllerConfiguration : ScriptableObject
{
    [Header("Gun Base Mechanics Settings:")]
    [SerializeField] private GameObject _gunBulletPrefab;
    
    [SerializeField] private bool _gunAutoEnabled;
    [SerializeField] private bool _gunAbleToShoot;

    [SerializeField] private Vector3 _gunOffset;

    [SerializeField] private AudioClip _gunShootSound;
    [SerializeField] private AudioClip _gunReloadSound;

    [Header("Gun In Battle Action Mechanics Settings:")]
    [Range(0.0f, 25f)] [SerializeField] private float _gunReloadTime;
    [Range(0.0f, 25f)] [SerializeField] private float _gunShootCooldown;
    [Range(0.0f, 100f)] [SerializeField] private float _gunOnShootRecoilIncrease;
    
    [Header("Gun Ammo Settings:")]
    [SerializeField] private int _gunMagMaximumAmmo;

    [Header("Gun Aiming Settings:")]
    [Range(1f, 25f)] [SerializeField] private float _recoilMaximum;
    [Range(0.0f, 15f)] [SerializeField] private float _recoilMinimum; 
    [Range(0.0f, 25f)] [SerializeField] private float _recoilCooldownTime;

    #region Base Mechanics
    public GameObject GunBulletPrefab { get => _gunBulletPrefab; set => _gunBulletPrefab = value; }
    public AudioClip GunShootSound { get => _gunShootSound; set => _gunShootSound = value; }
    public AudioClip GunReloadSound { get => _gunReloadSound; set => _gunReloadSound = value; }
    public bool GunAutoEnabled { get => _gunAutoEnabled; set => _gunAutoEnabled = value; }
    public bool GunAbleToShoot { get => _gunAbleToShoot; set => _gunAbleToShoot = value; }


    public Vector3 GunOffset { get => _gunOffset; set => _gunOffset = value; }

    public float GunReloadTime { get => _gunReloadTime; set => _gunReloadTime = value; }
    public float GunShootCooldown { get => _gunShootCooldown; set => _gunShootCooldown = value; }
    public float GunOnShootRecoilIncrease { get => _gunOnShootRecoilIncrease; set => _gunOnShootRecoilIncrease = value; }
    #endregion

    #region Ammo
    public int GunMagMaximumAmmo { get => _gunMagMaximumAmmo; set => _gunMagMaximumAmmo = value; }
    #endregion

    #region Aiming
    public float RecoilMaximum { get => _recoilMaximum; set => _recoilMaximum = value; }
    public float RecoilMinimum { get => _recoilMinimum; set => _recoilMinimum = value; }
    public float RecoilCooldownTime { get => _recoilCooldownTime; set => _recoilCooldownTime = value; }
    #endregion
}