using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //UI
    public GameObject StartUI, checkUI, InTownUI, InDungeonUI, DungeonCheckUI, EndAllUI, EndDieUI;
    //¸Ê ¸ðµ¨
    public GameObject Town, Dungeon;
    //±×¶ó¿îµå ÀÎ½Ä
    public GameObject FinderT, FinderD;
    //°ÔÀÓ ¸ðµ¨µé
    public GameObject zombiePre;
    public GameObject bullet;
    public GameObject Dungeons;
    public Transform FirePos;

    public GameObject[] SpawnPoint;

    public float shootdelay = 2f;

    public bool inDgame = false;

    int UPdelay = 0;
    public float HP = 1;

    [SerializeField]int MaxZombie;
    int SpawnCount = 0;

    public TextMeshProUGUI killLog;
    public Slider playerHP;
    public int killCount = 0;
    public int hitCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Setup();
    }


    void Setup()
    {
        shootdelay -= (UPdelay * 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        playerHP.value = HP;
        if (inDgame)
        {
            killLog.text = killCount.ToString();
            if (HP <= 0)
            {
                EndDieUI.SetActive(true);
                StopAllCoroutines();
            }

            if (MaxZombie == killCount + hitCount && HP >= 0)
            {
                EndAllUI.SetActive(true);
            }
        }
    }

    public void StartUION()
    {
        StartUI.SetActive(true);
    }
    public void StartUIClick()
    {
        StartUI.SetActive(false);
        checkUI.SetActive(true);
        Town.SetActive(true);
    }
    public void StartsAllOFF()
    {
        checkUI.SetActive(false);
        InTownUI.SetActive(true);
    }
    public void DungeonCheckOFF()
    {
        DungeonCheckUI.SetActive(false);
        MaxZombie = Random.Range(3, 10);
    }
    public void DungeonGo()
    {
        Town.SetActive(false);
        InTownUI.SetActive(false);
        DungeonCheckUI.SetActive(true);
        Dungeon.SetActive(true);
    }

    public void DungeonStart()
    {
        InDungeonUI.SetActive(true);
        Dungeons.SetActive(true);
        inDgame = true;
        killCount = 0;
        StartCoroutine(Spawn());
    }

    public void DungeonEnd()
    {
        InDungeonUI.SetActive(false);
        Dungeons.SetActive(false);
        Dungeon.SetActive(false );
        EndDieUI.SetActive(false);
        EndAllUI.SetActive(false);
        StopAllCoroutines();
        inDgame = false;
    }

    public void FireButton()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(shootdelay);
        Instantiate(bullet, FirePos.position, Quaternion.identity);
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < MaxZombie; i++)
        {

            int ran = Random.Range(0, 3);
            Instantiate(zombiePre, SpawnPoint[ran].transform.position, Quaternion.Euler(-90, -180, 0));
            yield return new WaitForSeconds(3f);
        }
    }
}
