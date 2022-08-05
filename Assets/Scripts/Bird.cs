using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    //velocidad del pajaro
    public float speed = 5f;
    //fuerza de salto del pajaro
    public float force = 300;
    // Start is called before the first frame update
    void Start()
    {
        //moviento a la derecha del pajaro
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        //gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void Update()
    {
        //salto del pajaro
        if(Input.GetKeyDown(KeyCode.Space)){
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }
        
        //Para movil
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        //reiniciar nivel
        if(collision.gameObject.tag == "Finish") SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
