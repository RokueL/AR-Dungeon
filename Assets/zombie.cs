using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombie : MonoBehaviour
{
    public Slider zomHP;

    public Transform endpoint;
    Vector3 destination;

    float moveSpeed = 300f;
    public float HP = 1;


    Player player;
    GameManager Gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        float ranSpeed = Random.Range(200, 400);
        moveSpeed = ranSpeed;
        Gamemanager = GameObject.FindObjectOfType<GameManager>();
        player = GameObject.FindObjectOfType<Player>();
        endpoint = GameObject.Find("EndSpawn").transform;
        destination = endpoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 )
        {
            this.gameObject.SetActive(false);
            Gamemanager.killCount++;
        }
        else
        {
            zomHP.value = HP;
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            
        }

        if (!Gamemanager.inDgame)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("Arrow");
            HP -= Random.Range(0.2f, 0.5f);
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            Debug.Log("Hit");
            Destroy(this.gameObject);
            Gamemanager.HP -= 0.5f;
            Gamemanager.hitCount++;
        }
    }
}
