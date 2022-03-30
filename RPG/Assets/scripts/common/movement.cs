using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public bool canMove;
    public GameObject player;
    public GameObject cam;
    //надо держать вектор по которму перемещается персонаж чтобы тело могло двигаться свободно от камеры и смотреть в нужную сторону
    public static int speed = 6;
    public static int _speed;
    public int rotation = 250; //Скорость пповорота персонажа
    public int jump = 3; //Высота прыжка
    public static float x = 0.0f; //угол поворота персонажа по оси x
    public bool use;//если персонаж взаимодействует с чем-то
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
                if (Input.GetKey(KeyCode.R)) //Если нажать W
                {
                    use = true;
                }
                    if (Input.GetKey(KeyCode.LeftShift)) //Если зажать левый Shift
                {
                    speed = _speed * 2; //Увеличиваем скорость перемещения(бег)
                }
                if (Input.GetKeyUp(KeyCode.LeftShift)) //Если отпустить
                {
                    speed = _speed; //Возвращаем стандартное значение
                }
                if (Input.GetKey(KeyCode.W)) //Если нажать W
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
                    speed = _speed; //Возвращаем cтандартное значение
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
            
            if (!isstay)//если двигаюсь

            {
                 Quaternion rotate = Quaternion.Euler(0, x, 0); //Создаем новую переменную типа Quaternion для задавания угла поворота


                player.transform.rotation = rotate; //Поворачиваем персонаж

                if(lookTo!=Vector3.zero)
                player.transform.forward = new Vector3(lookTo.x,0,lookTo.z);  //new Vector3(direction.x, 0, direction.z);
            }
        }
        
    }
     
}
