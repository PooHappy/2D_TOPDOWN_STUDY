using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Distance_Monster : MonoBehaviour
{
    public GameManager GM;

    public GameObject _bullet;

    private bool isAttack = false;
    private GameObject player = null;
    private Vector3 playerPos;
    private Vector3 calcplayerPos;
    private Vector3 nowPlayerPos;
    private Vector3 toPlayerPos;
    private float Distance = 0f;
    private bool isChecking = false;
    private float cosCeta = 0f;
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        if (player == null)
            return;
    }

    void Update()
    {
        Find();
    }
    void Find()
    {
        playerPos = player.transform.position;

        toPlayerPos = (playerPos - transform.position).normalized;

        if ((Mathf.Abs(Vector3.Distance(playerPos, transform.position)) <= 5) && !isAttack && !isChecking)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        isAttack = true;
        bullet = Instantiate(_bullet);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();

        Vector3 dirVec = toPlayerPos;

        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        isChecking = true;
        calcplayerPos = player.transform.position;
        Distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        yield return new WaitForSeconds(3f);
        isAttack = false;
    }
}
