using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerFirepos : MonoBehaviour
{
    private Vector3 moveDir;
    public GameObject bulletFprepab;
    public GameObject firePos;
    public GameObject bulletFprepab2;
    private bool isSkillChange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
          
            if(isSkillChange == false)
            {
                isSkillChange = true;
            }
            else
            {
                isSkillChange = false;
            }
        }
        if(isSkillChange == false)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Bujuck();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Bujuck();
            }
        }
        else
        {
            Sword();
        }
        

        void Sword()
        {

        }
        void Bujuck()
        {
            GameObject bullet = Instantiate(bulletFprepab);
            bullet.transform.position = firePos.transform.position;
        }



        int value = UnityEngine.Random.Range(0, 10);
        if (value < 3) // 30% 확률
        {
            // 플레이어 위치 - 내 위치
            GameObject target = GameObject.Find("Enemy");
            moveDir = target.transform.position - transform.position;
            moveDir.Normalize();
        }
        else // 70% 확률
        {
            moveDir = Vector3.left;
        }

        int value2 = UnityEngine.Random.Range(0, 10);
        if (value2 < 3) // 30% 확률
        {
            // 플레이어 위치 - 내 위치
            GameObject target = GameObject.Find("Enemy");
            moveDir = target.transform.position - transform.position;
            moveDir.Normalize();
        }
        else // 70% 확률
        {
            moveDir = Vector3.right;
        }
    }
}
