using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어 HP를 좀비의 공격력 만큼 - 시키면 됨
        // 좀비가 공격했을 경우만 작동하게 해야한다.
        if (collision.gameObject.tag == "ZombieArm")
        {
            playerHP = playerHP - collision.transform.root.GetComponent<Zombie>().zombieDamage;

            if (playerHP <= 0)
            {
                // 게임 오버
                Manager.instance.GameOver();
            }
        }
    }
}
