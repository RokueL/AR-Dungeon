using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Transform endpoint;
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        endpoint = GameObject.Find("EndPos").transform;
        destination = endpoint.position;
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //destination = endpoint.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, 5000f * Time.deltaTime);
    }
}
