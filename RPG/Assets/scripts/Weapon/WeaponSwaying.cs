using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwaying : MonoBehaviour
{
    // римитивная реализация. лучше заставить обьект именно инертно дввигаться в сторону нужной точки
    private Rigidbody _unitRigid;
    private Sheath _sheath;
    private Vector3 _stableLocalPosition;
    private Vector3 _weaponOffset;
    [SerializeField] private float _maxOffsetDistance;


    private void Update()
    {
        SmoothMove(_stableLocalPosition + CalculateOffsetDirection(_unitRigid.velocity)*_maxOffsetDistance);
    }
    private void Awake()
    {
        Vector3 startOffset = new Vector3(0, 0, -0.5f);
        _stableLocalPosition = transform.parent.localPosition+startOffset;
        _unitRigid = transform.parent.transform.parent.gameObject.GetComponent<Rigidbody>();

        _sheath = transform.parent.GetComponent<Sheath>();
    }

    private Vector3 CalculateOffsetDirection(Vector3 velocity) =>transform.parent.InverseTransformDirection(-velocity.normalized);

    private void SmoothMove(Vector3 requiredPosition)
    {
        transform.localPosition += (requiredPosition - transform.localPosition) * Time.deltaTime;
    }
}
