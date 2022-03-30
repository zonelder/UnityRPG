using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableInteraction : MonoBehaviour//ScriptableObject
{
    public abstract void Interact(GameObject Unit);
    public abstract void EndInteract();
}
