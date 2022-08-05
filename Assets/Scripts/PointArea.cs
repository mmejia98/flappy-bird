using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointArea : MonoBehaviour
{
    private UIManager manager;
    void Start(){
        manager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "bird"){
            manager.AddPoint();
        }
    }
}
