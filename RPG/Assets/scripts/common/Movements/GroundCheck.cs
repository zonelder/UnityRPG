using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[RequireComponent(typeof(Collider))]
public class GroundCheck : MonoBehaviour
{
    // this check based on raycasting around space iin meaning to find any closed enouthh collider, so it can create some bugs in a future 
    public bool Check
    {
        // check there are any collider(exept users collider) that too close to users collider
        get => Physics.OverlapCapsule(transform.position- Vector3.up*0.55f, transform.position + Vector3.up * 0.5f,0.55f).Count<Collider>()>1;
    }
}
