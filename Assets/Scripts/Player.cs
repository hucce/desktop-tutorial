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
        // �÷��̾� HP�� ������ ���ݷ� ��ŭ - ��Ű�� ��
        // ���� �������� ��츸 �۵��ϰ� �ؾ��Ѵ�.
        if (collision.gameObject.tag == "ZombieArm")
        {
            playerHP = playerHP - collision.transform.root.GetComponent<Zombie>().zombieDamage;

            if (playerHP <= 0)
            {
                // ���� ����
                Manager.instance.GameOver();
            }
        }
    }
}
