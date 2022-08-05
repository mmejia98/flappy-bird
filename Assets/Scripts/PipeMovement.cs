using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    //moviento arriba/abajo de las tuberias (0=no movimiento)
    public float speed = 0;
    //tiempo del cambio del movimiento para las tuberias
    public float switchTime = 2;

    private float distanceToDestroy = 35;

    public float directionPipe = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(directionPipe == 1){
            GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        }
        if(directionPipe == -1){
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
        //ivocamos el metodo cada x segundos
        InvokeRepeating("SwitchMovement", 0, switchTime);
    }

    void SwitchMovement(){
        GetComponent<Rigidbody2D>().velocity *= -1; 
    }

    void Update(){
        float xcam = Camera.main.transform.position.x;
        float xpipe = this.transform.position.x;
        if(xcam > xpipe + distanceToDestroy){
            Destroy(this.gameObject);
        }
    }
}
