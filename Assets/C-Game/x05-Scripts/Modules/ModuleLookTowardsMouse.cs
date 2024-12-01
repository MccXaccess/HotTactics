using UnityEngine;

namespace MODULES_Z
{
    public class ModuleLookTowardsMouse
    {
        public float ModuleLookTowards(Vector3 target, Vector3 weaponPosition)
        {
            // Calculate the direction from the weapon to the target (mouse)
            Vector3 dir = target - weaponPosition;

            // Calculate the angle using Atan2. This returns the angle in radians.
            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            return rotZ;
        }
    }
}
