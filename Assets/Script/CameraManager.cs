using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;

    [SerializeField] private float cameraMoveSpeed;
    [SerializeField] private BoxCollider2D bound;
    private GameObject player;  //캐릭터 
    private Camera _camera;     //Main Camera
    private Vector3 playerPos;  //player 위치

    //박스 콜라이더 영역의 최소, 최대 xyz값 
    private Vector3 minBound;
    private Vector3 maxBound;

    //카메라의 반너비, 반놃이
    private float halfWidth;
    private float halfHeight;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        _camera = GetComponent<Camera>();

        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfHeight = _camera.orthographicSize;
        // orthographicSize = 카메라의 높이/2
        halfWidth  = halfHeight * Screen.width / Screen.height;
        //Screen.width / Screen.height = 해상도 비율
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject != null)
        {
            playerPos.Set(player.transform.position.x, player.transform.position.y, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, playerPos, cameraMoveSpeed * Time.deltaTime);
            //Lerp(start, finish, speed)를 이용해 부드러운 카메라 무빙
        }
        float clampedX = Mathf.Clamp(transform.position.x, minBound.x + halfWidth,  maxBound.x - halfWidth );
        float clampedY = Mathf.Clamp(transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);
        //Clamp(value, min, max) = 계단함수?

        this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
    }
    #region SetBound
    [HideInInspector]
    public void SetBound(BoxCollider2D newBound)
    {
        bound = newBound;
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }
    #endregion SetBound
}
