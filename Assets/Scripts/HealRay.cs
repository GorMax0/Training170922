using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRay : Spell
{ 
    public override void Use()
    {
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            hit.rigidbody.AddForceAtPosition(ray.direction * Power, hit.point,ForceMode.Impulse);
        }
    }
}
