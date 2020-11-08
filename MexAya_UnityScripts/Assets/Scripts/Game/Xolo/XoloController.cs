using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XoloController : MonoBehaviour
{
    public GameObject marco;
    public GameObject player;

    public float timeToFinish = 0f;
    public bool isMoving = true;

    float nuevaX;
    private Vector3 startPos;
    private Vector3 endPos;
    private float lerpTime = 1;
    private float currentLerpTime = 0;

    public int startHp = 15;
    public GameObject vida;

    float bulletTimer;
    public float bulletCooldown = 0.3f;
    public bool inicio = true;
    int hp;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(-4f, transform.position.y);
        vida.GetComponent<TextMesh>().text = startHp.ToString();
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.instance.playerEnable)
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
        }
        


    }//______________________________________________________________________________________________________

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LevelController.instance.playerEnable)
        {
            //print("colisiona");
            if (other.tag == "waterBall" && bulletTimer <= 0)
            {
                bulletTimer = bulletCooldown;
                //lc.playSFX("spaceButton");
                hp--;
                //Debug.Log(hp);
                vida.GetComponent<TextMesh>().text = hp.ToString();
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                if (hp < 1)
                {
                    LevelController.instance.muerto = true;
                    Debug.Log("SE supone");
                }
            }
        }
        
    }

    public void ignoreColliders()
    {
        Physics2D.IgnoreCollision(marco.GetComponents<Collider2D>()[0], GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(marco.GetComponents<Collider2D>()[1], GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(player.GetComponents<Collider2D>()[0], GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(player.GetComponents<Collider2D>()[1], GetComponent<Collider2D>());
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
            nuevaX = Random.Range(-7.3f, 0.0f);

            startPos = transform.position;
            endPos = new Vector3(nuevaX, transform.position.y);

            currentLerpTime = 0f;

        }
    }
}
