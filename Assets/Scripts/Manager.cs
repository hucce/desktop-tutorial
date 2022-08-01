using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance
    {
        get { return _instance; }
    }

    private static Manager _instance = null;

    private void Awake()
    {
        _instance = this;
    }


    public GameObject bulletObj;
    public GameObject bulletPos;
    public float waitSeconds;
    private bool shot = false;

    public void Fire(bool mShot)
    {
        shot = mShot;
        StartCoroutine(CoFire());
    }

    private IEnumerator CoFire()
    {
        while(shot == true)
        {
            GameObject bullet = GameObject.Instantiate(bulletObj);
            bullet.transform.position = bulletPos.transform.position;
            yield return new WaitForSeconds(waitSeconds);
        }
    }
}
