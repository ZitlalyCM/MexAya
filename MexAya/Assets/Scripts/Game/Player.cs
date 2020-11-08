using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHp = 40;
    public GameObject vida;
    public float buffoCoolDown;

    float bulletTimer;
    int hp;

    // Start is called before the first frame update
    void Start()
    {
        vida.GetComponent<TextMesh>().text = startHp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;
    }
}
