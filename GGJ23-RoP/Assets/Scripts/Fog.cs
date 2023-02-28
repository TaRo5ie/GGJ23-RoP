using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    GameObject player;
    bool isChasing;
    float speed;
    float rush_speed;
    float paceChangeSpeed;
    Rigidbody2D rb;
   

    // Start is called before the first frame update
    void Start()
    {
        
        isChasing = true;
        rush_speed = 10f;//�������ʱ������ٶ�
        speed = 2f;//��Ҳ���ʱ������ٶ�
        paceChangeSpeed = 0.05f; //�л��������ٶȣ�Խ����Խ���
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 runspeed = player.GetComponent<Rigidbody2D>().velocity;

        if (runspeed != Vector2.zero)
        {
            rb.velocity = new Vector2(player.transform.position.x - this.transform.position.x,
                player.transform.position.y - this.transform.position.y).normalized * Mathf.Lerp(rb.velocity.magnitude, rush_speed,paceChangeSpeed);
        }
        else
        {
            rb.velocity = new Vector2(player.transform.position.x - this.transform.position.x,
                player.transform.position.y - this.transform.position.y).normalized * Mathf.Lerp(rb.velocity.magnitude, speed, paceChangeSpeed);
        }





        float dis = Vector3.Distance(new Vector3(transform.position.x, transform.position.y,0), //Խ����������ģ��ܼ���Խ��
            new Vector3(player.transform.position.x, player.transform.position.y, 0));

        player.GetComponent<SpriteRenderer>().color = new Color(1,1,1,(dis/40)* (dis / 40) * (dis / 40) );//�����ı���ҵ�͸����
    }
}
