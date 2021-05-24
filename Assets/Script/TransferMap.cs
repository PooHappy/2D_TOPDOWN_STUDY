using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (transferMapName == "Stage1")
            {
                collision.gameObject.transform.position = new Vector2(-38.89f, -14.98f);
            }
            SceneManager.LoadScene(transferMapName);
        }
    }
}
