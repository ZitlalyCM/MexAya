using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHp = 40;
    public GameObject vida;
    public GameObject escudo;
    public float buffoCoolDown;

    int hp;
    int durabilidad = 4;

    // Start is called before the first frame update
    void Start()
    {
        vida.GetComponent<TextMesh>().text = startHp.ToString();
        escudo.GetComponent<TextMesh>().text = durabilidad.ToString();
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LevelController.instance.playerEnable)
        {
            //print("colisiona");
            if (other.tag == "waterBall")
            {
                //lc.playSFX("spaceButton");
                if (durabilidad < 1)
                {
                    hp -= 1;
                    vida.GetComponent<TextMesh>().text = hp.ToString();
                }
                else
                {
                    durabilidad -= 1;
                    escudo.GetComponent<TextMesh>().text = durabilidad.ToString();
                }

                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                if (hp <= 0)
                {
                    LevelController.instance.muerto = true;
                }
            }

            if (other.tag == "flor")
            {
                durabilidad += 1;
                escudo.GetComponent<TextMesh>().text = durabilidad.ToString();
                Destroy(other.gameObject);
            }
        }
        
    }
}
