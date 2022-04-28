using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteraction : MonoBehaviour
{
    public abstract void Interact(GameObject Unit);
    public abstract void EndInteract();
}
