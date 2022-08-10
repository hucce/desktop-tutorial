using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject gunParticle;
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
            gunParticle.GetComponent<ParticleSystem>().Play();
            bulletPos.GetComponent<AudioSource>().Play();
            GameObject bullet = GameObject.Instantiate(bulletObj);
            bullet.transform.position = bulletPos.transform.position;
            bullet.transform.rotation = bulletPos.transform.rotation;
            yield return new WaitForSeconds(waitSeconds);
        }
    }

    // UI

    public GameObject gameoverObj;
    public GameObject gameoverTextObj;
    public GameObject hpTextObj;
    public float waitStage;
    public string nextStage;
    private GameObject[] zombieObjs;

    public void GameOver()
    {
        gameoverObj.SetActive(true);
        gameoverTextObj.SetActive(true);
        StartCoroutine(CoStageReload());
    }

    public void GameClear()
    {
        gameoverObj.SetActive(true);
        gameoverTextObj.SetActive(true);
        gameoverTextObj.GetComponent<Text>().text = "GAME CLEAR";
        StartCoroutine(CoNextStage());
    }

    public void PlayerHP(int hp)
    {
        hpTextObj.GetComponent<Text>().text = hp.ToString();
    }

    private void Start()
    {
        zombieObjs = GameObject.FindGameObjectsWithTag("Zombie");
    }

    private void Update()
    {
        bool Clear = true;
        for(int i=0; i<zombieObjs.Length; i++)
        {
            if(zombieObjs[i].GetComponent<Zombie>().zombieDead == false)
            {
                Clear = false;
                break;
            }
        }

        if(Clear == true)
        {
            GameClear();
        }
    }

    private IEnumerator CoStageReload()
    {
        // ���ð����� ���
        yield return new WaitForSeconds(waitStage);
        // Ȱ��ȭ ���� ���� �̸��� ������ ��
        string sceneName = SceneManager.GetActiveScene().name;
        // �ش��ϴ� ���̸����� �ҷ����� ��
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator CoNextStage()
    {
        // ���ð����� ���
        yield return new WaitForSeconds(waitStage);
        // �ش��ϴ� ���̸����� �ҷ����� ��
        SceneManager.LoadScene(nextStage);
    }
}
