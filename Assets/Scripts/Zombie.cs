using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float distance;
    public int zombieHP = 100;
    private Vector3 playerPos = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<NavMeshAgent>().SetDestination(playerPos);
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(playerPos, this.transform.position);
        if (dis <= distance)
        {
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<Animator>().SetTrigger("Attack");
        }

        if(zombieHP <= 0)
        {
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<Animator>().SetTrigger("Dead");
        }
    }

    public void OnPointerEnter()
    {
        Manager.instance.Fire(true);
    }

    public void OnPointerExit()
    {
        Manager.instance.Fire(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        zombieHP = zombieHP - collision.gameObject.GetComponent<Bullet>().damage;
    }
}
