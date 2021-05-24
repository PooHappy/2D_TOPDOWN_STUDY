using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record
{
    public int[] temp = new int[5];

    public int this[int index]
    {
        get {
            if (index >= temp.Length)
            {
                Debug.LogError("인덱스오류");
                return 0;
            }
            else
                return temp[index];
        }
        set { 
            if (index >= temp.Length) 
                Debug.Log("인덱스오류"); 
            else 
                temp[index] = value; 
        }
    }
}

public class Indexer : MonoBehaviour
{
    Record record = new Record();

    void Start()
    {
        //record[5] = 5;
        print(this.record[3] = 3);
        print(this.record[5] = 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
