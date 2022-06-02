using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsSettings : MonoBehaviour
{
    [SerializeField] private float _arrowsRadius;
    [SerializeField] private float _arrowsLenght;
    [SerializeField] private GameObject _yArrow;
    [SerializeField] private GameObject _xArrow;
    [SerializeField] private GameObject _zArrow;

    private void OnEnable()
    {
        Vector3 newScale = new Vector3(_arrowsRadius, _arrowsLenght, _arrowsRadius);
        _yArrow.transform.localScale = newScale;
        _yArrow.transform.localPosition = new Vector3(0, _arrowsLenght, 0);

        _xArrow.transform.localScale = newScale;
        _xArrow.transform.localPosition = new Vector3(_arrowsLenght, 0, 0);

        _zArrow.transform.localScale = newScale;
        _zArrow.transform.localPosition = new Vector3(0, 0, _arrowsLenght);

    }
}
