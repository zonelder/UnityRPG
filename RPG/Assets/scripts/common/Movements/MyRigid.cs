using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRigid : Rigidbody
{
    public new bool useGravity
    {
        get;
    }
    public MyRigid()
    {
        useGravity = false;
    }
}
