using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class movement : MonoBehaviour
{
    public bool canMove;
    public bool use;//если персонаж взаимодействует с чем-то
    private bool isstay;//може в дальнейшем пригодиться, пока не исключаем

    [SerializeField]
    private Jump _jump;
    private Rigidbody PlayerRigit;
    private GameObject cam;

    private  int speed;
    private static int defaultSpeed=6;

    private int perpendicularMove;//переменные для анимирования и фиксация движения персонажа,могут принимать значения(-1,0,1)
    private int moveForward;

    private Vector3 _surfaceNormal;
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
        canMove = true;
        speed= defaultSpeed;
        PlayerRigit = gameObject.GetComponent<Rigidbody>();
        cam = transform.Find("playerCam").gameObject;
        isstay = true;
    }
    private void Move(Vector3 direction)
    {
        if (direction == Vector3.zero)
        {
            isstay = true;
            return;
        }


        isstay = false;
        Vector3 directionAlongSurface = Project(direction.normalized);
        Vector3 offSet =directionAlongSurface.normalized * speed * Time.deltaTime;
        PlayerRigit.MovePosition(PlayerRigit.position + offSet);
    }
    private void Rotate(Vector3 lookTo)
    {
        if (!isstay)//если двигаюсь(когда мы стоим персонаж не привязан к повороту камеры и мы можем его осматривать)
        {       
                transform.forward = lookTo;//поворациваем по направлению движения
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
        Vector3 lookTo = Vector3.zero;
        if (Input.GetKey(KeyCode.R))
        {
            use = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))//спринт
        {
            speed = defaultSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = defaultSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveForward = 1;
            direction += cam.transform.forward;
            lookTo += cam.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed = defaultSpeed / 2;
            moveForward = -1;
            direction -= cam.transform.forward;
            lookTo += cam.transform.forward;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveForward = 0;
            speed = defaultSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            perpendicularMove = -1;
            direction -= cam.transform.right;
            if (moveForward != 0)
                lookTo -= moveForward * cam.transform.right;
            else
                lookTo -= cam.transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            perpendicularMove = 1;
            direction += cam.transform.right;
            if(moveForward!=0)
            lookTo += moveForward * cam.transform.right;
            else
                lookTo += cam.transform.right;
        }


        direction.y = 0;//чтобы не выбло вертикальных компонент из-за положения камеры
        lookTo.y = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            _jump.StartJump(direction, speed);
        }

        Move(direction);

        Rotate(lookTo);
   
}
    private void Update()
    {
        perpendicularMove = 0;
        moveForward = 0;
        use = false;
        if (canMove)
        {
            ReadInput();
        }
    }
     
    public void RotateByCamera()
    {
        Vector3 cameraForward = cam.transform.forward;
        cameraForward.y = 0;
        transform.forward =cameraForward;
    }
}
