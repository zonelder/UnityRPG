using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshRenderer))]
public  class SelectableKey:MonoBehaviour,ISelectable
{
    [SerializeField]
    private  Material _unselectMaterial;
    [SerializeField]
    private  Material _selectMaterial;
    [SerializeField]
    private Material _mouseOverMaterial;

    private MeshRenderer _mesh;
    public int Index;

    [SerializeField]private GameObject _arrowsOnSelected;
    private GameObject _instantiatedArrows;
   
    public void Select()
    {
       _mesh.material= _selectMaterial;
       _instantiatedArrows= Instantiate(_arrowsOnSelected,transform);
    }


    public void Deselect()
    {
        _mesh.material = _unselectMaterial;
        Destroy(_instantiatedArrows);
    }

    private void OnEnable()
    {
        _mesh = GetComponent<MeshRenderer>();
    }
}
