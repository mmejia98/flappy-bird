using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFollow : MonoBehaviour
{
    public Transform target;
    
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(target.position.x + 10, this.transform.position.y, this.transform.position.z);
    }
}
