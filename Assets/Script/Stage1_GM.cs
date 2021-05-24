using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_GM : MonoBehaviour
{
    CameraManager cc;
    public BoxCollider2D bound;
    // Start is called before the first frame update
    private void Awake()
    {
        cc = FindObjectOfType<CameraManager>();
    }
    void Start()
    {
        cc.SetBound(bound);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
