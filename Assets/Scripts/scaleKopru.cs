using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleKopru : MonoBehaviour
{
    Vector3 kopru;

    // Start is called before the first frame update
    void Start()
    {
        kopru = transform.localScale;
        int counter = MovePlayer.getCounter();
        kopru.x = kopru.x + ((counter/100));
        kopru.z = kopru.z + ((counter/100));
        transform.localScale = kopru;
    }

    
}
