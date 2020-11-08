

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BulletSpawnData[] spawnDatas;
    public GameObject enemigo;
    public RectTransform panel;
    public bool isSequenceRandom;
    int index = 0;
    float timer;
    float[] rotations;

    void Start()
    {
        timer = GetSpawnData().cooldown;
        //Debug.Log(timer);
        rotations = new float[8];
    }

    // Update is called once per frame
    void Update()
    {   
        if(LevelController.instance.playerEnable){
            //Debug.Log(index + " " + Time.deltaTime);
            if (timer <= 0)
            {
                SpawnBullets();
                timer = GetSpawnData().cooldown;
                if(isSequenceRandom){
                    index = Random.Range(0, spawnDatas.Length); 
                    if(index==3){
                        index= 0;
                    }
                }
                
            }
            timer -= Time.deltaTime;
            
        }
        
    }

    BulletSpawnData GetSpawnData(){
        return spawnDatas[index];
    }
    // Select a random rotation from min to max for each bullet
    public float[] RandomRotations()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            rotations[i] = Random.Range(GetSpawnData().minRotation, GetSpawnData().maxRotation);
        }
        return rotations;

    }
    
    // This will set random rotations evenly distributed between the min and max Rotation.
    public float[] DistributedRotations()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            
            if (GetSpawnData().numberOfBullets >1){
                var fraction = (float)i / ((float)GetSpawnData().numberOfBullets - 1);
                var difference = GetSpawnData().maxRotation - GetSpawnData().minRotation;
                var fractionOfDifference = fraction * difference;
                rotations[i] = fractionOfDifference + GetSpawnData().minRotation; // We add minRotation to undo Difference
                
            }
            else{
                rotations[i]=90;
            }
            
        }
        //foreach (var r in rotations) print(r);
        return rotations;
    }
    public GameObject[] SpawnBullets()
    {
        
        if (GetSpawnData().isRandom)
        {
            // This is in Update because we want a random rotation for each bullet each time
            RandomRotations();
        }else{
			DistributedRotations();
            
        }
		
        // Spawn Bullets
        GameObject[] spawnedBullets = new GameObject[GetSpawnData().numberOfBullets];
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            
            spawnedBullets[i] = Instantiate(GetSpawnData().bulletResource,panel);
            spawnedBullets[i].transform.position = enemigo.transform.position;
            var b= spawnedBullets[i].GetComponent<Bullet>();
            b.rotation = rotations[i];
            b.speed = GetSpawnData().bulletSpeed;
            b.velocity = GetSpawnData().bulletVelocity;
			Destroy(spawnedBullets[i],GetSpawnData().lifeTime);
        }
        return spawnedBullets;
    }
}