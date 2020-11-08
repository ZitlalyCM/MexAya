using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.instance.playerEnable)
        {
            Jump();
            if (LevelController.instance.nSaltos == 2)
            {
                if ((transform.position.x < -8.7 && Input.GetAxisRaw("Horizontal") == 1) || (transform.position.x > 8.6 && Input.GetAxisRaw("Horizontal") == -1) || (transform.position.x >= -8.7 && transform.position.x <= 8.6))
                {
                    transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0) * speed * Time.deltaTime;
                }
            }
            // Debug.Log(transform.position.y);
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (LevelController.instance.nSaltos > 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxisRaw("Horizontal")*2, 20f), ForceMode2D.Impulse);
                LevelController.instance.nSaltos--;
            }
        }
    }
}
