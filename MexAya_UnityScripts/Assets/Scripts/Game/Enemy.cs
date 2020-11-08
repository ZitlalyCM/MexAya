
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Enemy : MonoBehaviour {
	public bool isMoving=false;
    public float timeToFinish = 0.0f;

    float nuevaY;
    private Vector3 startPos;
    private Vector3 endPos;
    private float lerpTime = 3;
    private float currentLerpTime = 0;
    // Use this for initialization

    void Start () {
        transform.position = new Vector3(10f, transform.position.y);
        startPos = transform.position;
        //Debug.Log(startPos + "   INICIAL " + isMoving);
    }
	
	// Update is called once per frame
	void Update () {
        if (LevelController.instance.playerEnable)
        {
            if (isMoving)
            {
                move();
            }
            else
            {
                wait();
            }
            //Debug.Log(timeToFinish + "   time " + isMoving);

        }

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
            nuevaY = Random.Range(-0.9f, 1.0f);

            startPos = transform.position;
            //Debug.Log(startPos + "   INICIAL");
            endPos = new Vector3(6f, nuevaY);

            currentLerpTime = 0f;

        }
    }
}
