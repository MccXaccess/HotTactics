using UnityEngine;

public class ModuleAttack : MonoBehaviour
{
    /*
    public void GunShoot(GameObject bulletPrefab, Vector3 ShootPointPosition, Quaternion shootPointRotation, Vector3 gunOffsetPosition, float recoilCurrent, float gunShootAccuracy)
    {   
        recoilCurrent = recoilCurrent / 50;

        float accuracyOffset = recoilCurrent * ((100 - gunShootAccuracy) / 100);

        float gunOffset = -gunOffsetPosition.x / 10;

        float range = Random.Range(-accuracyOffset - gunOffset, accuracyOffset + gunOffset);
        
        shootPointRotation = new Quaternion(shootPointRotation.x, shootPointRotation.y, shootPointRotation.z + range, shootPointRotation.w);

        Instantiate(bulletPrefab, ShootPointPosition, shootPointRotation);
    }*/

    public void GunShootModified(GameObject bulletPrefab, Vector3 shootPointPosition, Transform characterT, Vector3 cursorR, float recoilCurrent, float gunShootAccuracy)
    {   
        recoilCurrent = recoilCurrent / 50;

        float accuracyOffset = recoilCurrent * ((100 - gunShootAccuracy) / 100);

        float range = Random.Range(-accuracyOffset, accuracyOffset);
    
        Vector3 bulletDirection = characterT.TransformDirection(cursorR.normalized);

        Quaternion bulletRotation = Quaternion.LookRotation(bulletDirection);

        Quaternion shootPointRotation = new Quaternion(bulletRotation.x, bulletRotation.y, bulletRotation.z + range, transform.rotation.w);

        Instantiate(bulletPrefab, shootPointPosition, shootPointRotation);
    }

    public void MeleeAttack()
    {
        // MELEE ATTACK
    }
}