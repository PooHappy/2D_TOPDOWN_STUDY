using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABC<T>
{
    public T var;
    public T[] array;
}

public class T : MonoBehaviour
{
    ABC<string> a; 
    ABC<float> b;

    void Print <T> (T value) //where T : class -- 제약사항 추가
    {
        print(value);
    }
    private void Start()
    {
        Print<string>("abc");
        Print<int>(5);

        a.var = "abc";
        a.array = new string[1];
        a.array[0] = "abc";

        b.var = 4.9f;
        b.array = new float[1];
        b.array[0] = 4.8f;
        
    }
}
