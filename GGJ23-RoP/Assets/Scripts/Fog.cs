using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    GameObject player;
    public bool isChasing;
    float speed;
    Rigidbody2D rb;
   

    // Start is called before the first frame update
    void Start()
    {
        isChasing = false;
        speed = 5f;
        player = GameObject.Find("Player");
        //    rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKey(KeyCode.Space))
      //  {
            if (isChasing)
                isChasing = false;
            else
                isChasing = true;
     //   }

        if (isChasing)
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }

       else
        {
            float step = 1f * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
            // rb.velocity = player.GetComponent<Rigidbody2D>().velocity;

        }


    }
}
