using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttackBehaviour 
{
    public delegate void attackMethod(GameObject beaten);
    public static void Create(Vector3 position, Quaternion rotation, GameObject createdObject, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomVector = new Vector3(Random.value, Random.value, Random.value);//�������� ��� ���������
            GameObject copyProjectile = MonoBehaviour.Instantiate(createdObject, position + randomVector, rotation);
            randomVector = new Vector3(Random.value, 2, Random.value);//��������� ��������
            copyProjectile.GetComponent<Rigidbody>().AddForce(5 * randomVector, ForceMode.Impulse);
        }
    }
}
