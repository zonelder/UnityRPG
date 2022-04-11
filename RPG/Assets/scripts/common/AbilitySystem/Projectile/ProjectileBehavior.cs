using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectileBehavior 
{
    public delegate void  attackMethod(GameObject beaten);
    public static void BlowUp(Vector3 position,float radius, attackMethod method )
    {
        //<blow up when destroy>
        Collider[] colliders = Physics.OverlapSphere(position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.isTrigger == true)
            {

                method(nearbyObject.gameObject);
            }

        }//</blow up when destroy>
    }
}
