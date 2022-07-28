using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject bulletObj;
    public GameObject bulletPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject bullet = GameObject.Instantiate(bulletObj);
        bullet.transform.position = bulletPos.transform.position;
    }
}
