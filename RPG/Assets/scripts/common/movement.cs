using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public bool canMove;
    public GameObject player;
    public GameObject cam;
    //���� ������� ������ �� ������� ������������ �������� ����� ���� ����� ��������� �������� �� ������ � �������� � ������ �������
    public static int speed = 6;
    public static int _speed;
    public int rotation = 250; //�������� ��������� ���������
    public int jump = 3; //������ ������
    public static float x = 0.0f; //���� �������� ��������� �� ��� x
    public bool use;//���� �������� ��������������� � ���-��
    public int perpendicularMove ;
    public int moveForward;
    public Vector3 direction = new Vector3(0, 0, 0);
    //public Animation anim = GetComponent<Animation>();
    bool isstay = true;

    public int Speed()
    {
        return speed;
    }
    void Start()
    {
        canMove = true;
        _speed = speed;
        player = (GameObject)this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        perpendicularMove = 0;
        moveForward = 0;
        use = false;
        direction = Vector3.zero;
        Vector3 lookTo = Vector3.zero;
        if (canMove)
        {
            isstay = true;
                if (Input.GetKey(KeyCode.R)) //���� ������ W
                {
                    use = true;
                }
                    if (Input.GetKey(KeyCode.LeftShift)) //���� ������ ����� Shift
                {
                    speed = _speed * 2; //����������� �������� �����������(���)
                }
                if (Input.GetKeyUp(KeyCode.LeftShift)) //���� ���������
                {
                    speed = _speed; //���������� ����������� ��������
                }
                if (Input.GetKey(KeyCode.W)) //���� ������ W
                {
                    moveForward = 1;
                    direction +=cam.transform.forward;
                    lookTo+= cam.transform.forward;
            }
                if (Input.GetKey(KeyCode.S))
                {
                    speed = _speed / 2;
                    moveForward = -1;
                    direction -= cam.transform.forward;
                    lookTo += cam.transform.forward;
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    moveForward = 0;
                    speed = _speed; //���������� c���������� ��������
                }
                if (Input.GetKey(KeyCode.A))
                {
                    perpendicularMove = -1;
                    direction -= cam.transform.right;
                    lookTo -= moveForward*cam.transform.right;
            }
                if (Input.GetKey(KeyCode.D))
                {
                    perpendicularMove = 1;
                    direction += cam.transform.right;
                    lookTo += moveForward * cam.transform.right;
            }
                if (Input.GetKey(KeyCode.Space))
                {
                    direction += cam.transform.up;
            }
            if(direction!=Vector3.zero)
            {
                isstay = false;
                player.transform.position += (direction.normalized) * speed * Time.deltaTime;
            }
            
            if (!isstay)//���� ��������

            {
                 Quaternion rotate = Quaternion.Euler(0, x, 0); //������� ����� ���������� ���� Quaternion ��� ��������� ���� ��������


                player.transform.rotation = rotate; //������������ ��������

                if(lookTo!=Vector3.zero)
                player.transform.forward = new Vector3(lookTo.x,0,lookTo.z);  //new Vector3(direction.x, 0, direction.z);
            }
        }
        
    }
     
}
