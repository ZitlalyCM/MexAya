using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgManager : MonoBehaviour
{
    Vector3 startPos;
    public float speed = 2f;
    public GameObject bg2;
    public float largo = 8.6f;
    // Start is called before the first frame update


    void Start()
    {
        startPos = new Vector3(0, 0);
        //Debug.Log(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1,0)* speed * Time.deltaTime;
        if(bg2.transform.position.x <= 0)
        {
            //Debug.Log(startPos);
            transform.position = startPos;
        }
    }
}
