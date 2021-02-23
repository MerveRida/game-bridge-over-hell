using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateJewels : MonoBehaviour
{
    Vector3 rotate;
    
    void Update()
    {
        rotate= new Vector3(0, 45, 0);
        transform.Rotate(rotate * Time.deltaTime);
    }
}
