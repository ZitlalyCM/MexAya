using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XoloController : MonoBehaviour
{
    public GameObject marco;
    public GameObject player;

    public float timeToFinish = 0f;
    public bool isMoving = true;

    float nuevaX;
    private Vector3 startPos;
    private Vector3 endPos;
    private float lerpTime = 5;
    private float currentLerpTime = 0;

    public int startHp = 15;
    public GameObject vida;
    public float buffoCoolDown;

    float bulletTimer;
    int hp;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(-4f, transform.position.y);
        vida.GetComponent<TextMesh>().text = startHp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ignoreColliders();
        bulletTimer -= Time.deltaTime;

        if (isMoving)
        {
            move();
        }
        else
        {
            wait();  
        }


    }//______________________________________________________________________________________________________

    public void ignoreColliders()
    {
        Physics2D.IgnoreCollision(marco.GetComponents<Collider2D>()[0], GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(marco.GetComponents<Collider2D>()[1], GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public void move()
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
            isMoving = false;
            timeToFinish = 1f;
        }

        float Perc = currentLerpTime / lerpTime;
        transform.position = Vector3.Lerp(startPos, endPos, Perc);
    }
    public void wait()
    {
        timeToFinish -= Time.deltaTime;
        if (timeToFinish < 0)
        {
            isMoving = true;
            nuevaX = Random.Range(-7.0f, 4.0f);

            startPos = transform.position;
            endPos = new Vector3(nuevaX, transform.position.y);

            currentLerpTime = 0f;

        }
    }
}
