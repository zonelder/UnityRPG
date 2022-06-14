using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class movement : MonoBehaviour
{
    public bool Use;//если персонаж взаимодействует с чем-то

    private UnitMove _moveStrategy;
    private UnitRotation _rotationStrategy;
    private Jump _jump;
    private GroundCheck _IsGround;

    private Rigidbody _playerRigit;
    private GameObject _cam;

    private  int speed;
    private  int _defaultSpeed=6;
    private Vector3 _surfaceNormal;
  
    public UnitMove GetMoveStrategy() => _moveStrategy;

    public void RotateByCamera()
    {
        Vector3 cameraForward = _cam.transform.forward;
        cameraForward.y = 0;
        transform.forward = cameraForward;
    }
    private Vector3 Project(Vector3 forward)
    {
        return forward - Vector3.Dot(forward, _surfaceNormal) * _surfaceNormal;
    }

    private void OnCollisionStay(Collision collision)
    {
        // OnCollisionStay use  cause we can stay on huge surface with changing normals along it;
        _surfaceNormal = collision.contacts[0].normal;
    }
    private void Start()
    {
        speed= _defaultSpeed;
        _playerRigit = gameObject.GetComponent<Rigidbody>();
        _cam = transform.Find("playerCam").gameObject;
        _IsGround = GetComponent<GroundCheck>();

        _jump = GetComponent<Jump>();
        _rotationStrategy = new WalkRotation();
        _moveStrategy = new WalkMove();
        _jump.OnStartJump += _rotationStrategy.DisableRotation;
        _jump.OnEndJump += _rotationStrategy.EnableRotation;

    }
   

    private void FormDirection()
    {
        Vector3 direction = Input.GetAxis("Vertical") *_cam.transform.forward;
        direction += Input.GetAxis("Horizontal") * _cam.transform.right;
        if (Input.GetKey(KeyCode.R))
        {
            Use = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = _defaultSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = _defaultSpeed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _jump.StartJump(direction, speed);
        }
        if(_IsGround.Check)
        {
            direction.y = 0;
            _moveStrategy.Move(Project(direction.normalized).normalized * speed, _playerRigit);
            _rotationStrategy.Rotate(direction, transform);
        }
}
    private void Update()
    {
        Use = false;
        if(_moveStrategy.IsMoveable)
            FormDirection();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _surfaceNormal * 5);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + Project(transform.forward).normalized * 5);
    }
}
