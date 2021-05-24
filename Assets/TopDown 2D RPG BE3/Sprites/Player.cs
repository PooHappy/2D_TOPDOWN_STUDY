using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h, v;
    float moveSpeed = 3f;
    Vector3 moveVec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(h, v, 0) * Time.deltaTime * moveSpeed;
        transform.position += moveVec;
    }
}
