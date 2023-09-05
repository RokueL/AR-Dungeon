using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider PlayerHPUI;
    float HP = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHPUI.value = HP;
    }

    public void Hit()
    {
        HP -= Random.Range(0.3f, 0.6f);
    }
}
