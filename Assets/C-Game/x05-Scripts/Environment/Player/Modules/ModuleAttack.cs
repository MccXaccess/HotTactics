using UnityEngine;

public class ModuleAttack : MonoBehaviour
{

    //public void GunShoot(GameObject bulletPrefab, Vector3 ShootPointPosition, Quaternion shootPointRotation, Vector3 gunOffsetPosition, float recoilCurrent, float gunShootAccuracy)
    //{
    //    recoilCurrent = recoilCurrent / 50;

    //    float accuracyOffset = recoilCurrent * ((100 - gunShootAccuracy) / 100);

    //    float gunOffset = -gunOffsetPosition.x / 10;

    //    float range = Random.Range(-accuracyOffset - gunOffset, accuracyOffset + gunOffset);

    //    shootPointRotation = new Quaternion(shootPointRotation.x, shootPointRotation.y, shootPointRotation.z + range, shootPointRotation.w);

    //    Instantiate(bulletPrefab, ShootPointPosition, shootPointRotation);
    //}

    public void GunShoot(GameObject bulletPrefab, Vector3 ShootPointPosition, Quaternion shootPointRotation, Vector3 gunOffsetPosition, float recoilCurrent, float gunShootAccuracy)
    {
        // Adjust recoil for more natural gun movement. Scaling it down by 50 and tweaking it for smoother recoil behavior.
        recoilCurrent = Mathf.Clamp(recoilCurrent / 50, 0.1f, 1.5f);  // Ensures recoil stays within a reasonable range.

        // Calculate the accuracy offset based on the current recoil and the gun's accuracy.
        float accuracyOffset = recoilCurrent * ((100 - gunShootAccuracy) / 100);

        // Gun's horizontal offset (this simulates the gun's horizontal shift due to recoil).
        float gunOffset = -gunOffsetPosition.x / 10;

        // Randomly distribute recoil within a range based on recoil amount and gun accuracy.
        float horizontalRecoil = Random.Range(-accuracyOffset - gunOffset, accuracyOffset + gunOffset);
        float verticalRecoil = Random.Range(-accuracyOffset, accuracyOffset);

        // Apply the recoil offsets to the rotation. This simulates the gun "kicking" in both directions.
        shootPointRotation = new Quaternion(
            shootPointRotation.x + verticalRecoil,  // Vertical recoil applied here.
            shootPointRotation.y + horizontalRecoil,  // Horizontal recoil applied here.
            shootPointRotation.z,  // Keep z-axis (rotation around the gun axis) unchanged.
            shootPointRotation.w
        );

        // Instantiate the bullet with the altered rotation.
        Instantiate(bulletPrefab, ShootPointPosition, shootPointRotation);

        // After the shot, apply recoil recovery over time. This gradually resets the gun's rotation.
        // recoilCurrent = Mathf.Lerp(recoilCurrent, 0, Time.deltaTime * 5f);  // Smooth recoil recovery (can tweak the factor).
    }


    //public void GunShootModified(GameObject bulletPrefab, Vector3 shootPointPosition, Transform characterT, Vector3 cursorR, float recoilCurrent, float gunShootAccuracy)
    //{
    //    recoilCurrent /= 50;

    //    float accuracyOffset = recoilCurrent * ((100 - gunShootAccuracy) / 100);

    //    float range = Random.Range(-accuracyOffset, accuracyOffset);

    //    Vector3 bulletDirection = characterT.TransformDirection(cursorR.normalized);

    //    Quaternion bulletRotation = Quaternion.LookRotation(bulletDirection);

    //    Quaternion shootPointRotation = new Quaternion(bulletRotation.x, bulletRotation.y, bulletRotation.z + range, transform.rotation.w);

    //    Instantiate(bulletPrefab, shootPointPosition, shootPointRotation);
    //}

    public void MeleeAttack()
    {
        // MELEE ATTACK
    }
}