using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPlayer : MonoBehaviour
{
    Rigidbody rb;
    public int jumpSpeed = 10;
    bool isTouching = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("In if block");
            Vector3 balljump = new Vector3(0.0f, 70.0f, 0.0f);
            rb.AddForce(balljump * jumpSpeed);
            isTouching = false;
        }
        
    }

    private void OnCollisionStay()
    {
        Debug.Log("Touched");
        isTouching = true;
    }

    public void atlamaHiziniKatla()
    {
        jumpSpeed = jumpSpeed * 2;
    }
}
