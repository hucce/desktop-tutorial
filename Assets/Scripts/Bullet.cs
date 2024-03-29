using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
