using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRay : Spell
{
    public override IEnumerator Use()
    {
        while (IsUse == true)
        {
            if (Enemy != null)
            {
                Vector3 direction = transform.position - Enemy.transform.position;
                Vector3 force = direction * TargetAccelerationForce * Time.fixedDeltaTime;
                RayRender.SetPosition(0, transform.position);

                Enemy.ApplyPlayerSpell(-force, transform.position, -Power);
                RayRender.SetPosition(1, Enemy.transform.position);                
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
