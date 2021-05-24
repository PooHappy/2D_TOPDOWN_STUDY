using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //static public PlayerMovement instance;

    [SerializeField] private LayerMask layerMask;        // Raycast시 사용될 Layer
    [SerializeField] public GameObject bow;             // 활 GameObject 객체
    private GameObject scanObject;

    private float bowSpeed = 13;        // 활 속도
    private float bowDelay = 0.7f;      // 활 공격 딜레이
    private float h, v;                 //Horizontal & Vertical
    private float moveSpeed;            //Player Move Speed
    private Vector3 moveVec;            //
    private Animator anime;             //
    private Vector3 attackVector;
    private Vector3 dirVec;
    private Vector3 vector;             //
    private bool isAttack;              //

    private Rigidbody2D rigid;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        moveSpeed = 10;
        h = v = 0;
        anime = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Distance_Attack();


    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        vector.Set(h, v, 0);

        Vector3 start = transform.position;

        Vector3 end = start + new Vector3(h * moveSpeed * Time.deltaTime, v * moveSpeed * Time.deltaTime, 0);
        
        if (isRaycastHit(start, end))
        {
            return;
        }

        if (h != 0 || v != 0)
        {
            moveVec = new Vector3(h, v, 0);
            moveSpeed = Input.GetKey(KeyCode.LeftShift) ? 6 : 3;
            anime.SetBool("Walking", true);
            anime.SetFloat("DirX", h);
            anime.SetFloat("DirY", v);
            transform.position += moveVec * moveSpeed * Time.deltaTime;
        }
        else
        {
            anime.SetBool("Walking", false);
        }
        if (v == 1)
            dirVec = Vector3.up;
        else if (v == -1)
            dirVec = Vector3.down;
        else if (h == -1)
            dirVec = Vector3.left;
        else if (h == 1)
            dirVec = Vector3.right;
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Shop"));

        if (rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;
        else
            scanObject = null;

        if(Input.GetButtonDown("Jump") && scanObject != null)
        {

        }
    }
    private void Distance_Attack()
    {
        if(Input.GetKey(KeyCode.X))
        {
            if(!isAttack)
            {
                isAttack = true;
                StartCoroutine("BowAttackDelay");
            }
        }
    }
    IEnumerator BowAttackDelay()
    {
        Quaternion rotation;
        Vector2 vector2;

        anime.SetTrigger("Attacking");
        anime.SetFloat("AttX", vector.x);
        anime.SetFloat("AttY", vector.y);

        attackVector = vector;

        if (vector.x > 0)
            rotation = Quaternion.Euler(0, 0, 0);
        else if (vector.x < 0)
            rotation = Quaternion.Euler(0, 0, 180);
        else if (vector.y > 0)
            rotation = Quaternion.Euler(0, 0, 90);
        else
            rotation = Quaternion.Euler(0, 0, 270);

        if (vector.x != 0 && vector.y != 0)
            rotation = getBowRotation();

        if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0))
            rotation = getBowRotation();

        vector2 = new Vector2(vector.x, vector.y).normalized;
        GameObject bow = null;

        if ((vector2.x > 0 && vector2.y == 0) || (vector2.x < 0 && vector2.y == 0))
            bow = Instantiate(this.bow, transform.position + new Vector3(0, -0.25f, 0), rotation);
        else
            bow = Instantiate(this.bow, transform.position, rotation);

        Rigidbody2D bowRigid = bow.GetComponent<Rigidbody2D>();
        bowRigid.AddForce(vector2 * bowSpeed, ForceMode2D.Impulse);

        yield return new WaitForSeconds(bowDelay);

        isAttack = false;
    }
    private Quaternion getBowRotation()
    {
        Quaternion rotation;

        if (vector.x > 0 && vector.y > 0)
        {
            rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (vector.x > 0 && vector.y < 0)
        {
            rotation = Quaternion.Euler(0, 0, 315);
        }
        else if (vector.x < 0 && vector.y > 0)
        {
            rotation = Quaternion.Euler(0, 0, 135);
        }
        else
        {
            rotation = Quaternion.Euler(0, 0, 225);
        }

        return rotation;
    }
    private bool isRaycastHit(Vector3 start, Vector3 end)
    {
        RaycastHit2D hit = Physics2D.Linecast(start, end, layerMask);

        if (hit.transform != null)
            return true;
        else
            return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Attacked")
        {

        }
    }
}
