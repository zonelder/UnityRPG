using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class movement : MonoBehaviour
{
    public bool _canMove;
    public bool use;//если персонаж взаимодействует с чем-то
    private bool isStay;
    private bool _canRotate;

    private Jump _jump;
    private Rigidbody _playerRigit;
    private GameObject _cam;
    private GroundCheck _IsGround;
    private  int speed;
    private static int s_defaultSpeed=6;
    private Vector3 _surfaceNormal;
    public event MoveMethods OnMove;

    public void DisableRotation() => _canRotate = false;
    public void EnableRotation() => _canRotate = true;
    public void DisableMove() => _canMove = false;
    public void EnableMove() => _canMove = true;
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

    private void OnCollisionStay(Collision collision)//OnCollisionStay use  cause we can stay on huge surface with changing normals along it;
    {
        _surfaceNormal = collision.contacts[0].normal;
    }
    private void Start()
    {
        _canMove = true;
        speed= s_defaultSpeed;
        _playerRigit = gameObject.GetComponent<Rigidbody>();
        _cam = transform.Find("playerCam").gameObject;
        _IsGround = GetComponent<GroundCheck>();

        _jump = GetComponent<Jump>();
        _jump.OnStartJump += DisableRotation;
        _jump.OnEndJump += EnableRotation;
        isStay = true;
    }
    private void Move(Vector3 direction)
    {

        if (direction == Vector3.zero)
        {
            isStay = true;
            return;
        }
        if (!_IsGround.Check)
            return;
        isStay = false;
        _canRotate = true;
        Vector3 directionAlongSurface = Project(direction.normalized);
        _playerRigit.velocity = directionAlongSurface.normalized * speed;
        OnMove?.Invoke(directionAlongSurface.normalized * speed);
        
    }
    private void Rotate(Vector3 lookTo)
    {
        if (!isStay && lookTo!=Vector3.zero && _canRotate)//если двигаюсь(когда мы стоим персонаж не привязан к повороту камеры и мы можем его осматривать)
        {       
                transform.forward = lookTo;
            //сюда бы корутину которая постепенно будет поворачивать игрока
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _surfaceNormal * 5);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + Project(transform.forward)* 5);
    }

    private void ReadInput()
    {
        Vector3 direction = Vector3.zero;
        direction += Input.GetAxis("Vertical") *_cam.transform.forward;
        direction += Input.GetAxis("Horizontal") * _cam.transform.right;
        if (Input.GetKey(KeyCode.R))
        {
            use = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = s_defaultSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = s_defaultSpeed;
        }
        direction.y = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            _jump.StartJump(direction, speed);
        }

        Move(direction);
        Rotate(direction);
   
}
    private void Update()
    {
        use = false;
        if (_canMove)
        {
            ReadInput();
        }
    }

}
public delegate void MoveMethods(Vector3 velocity);