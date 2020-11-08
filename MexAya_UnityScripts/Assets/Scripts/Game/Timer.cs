using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft = 65f;
    public GameObject contador;
    // Start is called before the first frame update
    void Start()
    {
        contador.GetComponent<TextMesh>().text = timeLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            contador.GetComponent<TextMesh>().text = (timeLeft).ToString("0");
        }
        
        if(timeLeft < 0)
        {
            LevelController.instance.win = true;
            //GANASTE YAAAY
        }
    }
}
