using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramda : MonoBehaviour
{
    /*
    delegate void MyDelegate();
    MyDelegate myDelegate;
    int a = 5;
    int b = 5;

    int sum;

    void Add()
    {
        sum = a + b;
        Back();
    }
    void Print()
    {
        print(sum);
    }
    void Back()
    {
        sum = 0;
    }
    private void Start()
    {
        myDelegate = Add;
        //무명 메소드
        //반드시 델리게이트를 통해 호출.
        myDelegate += delegate() { print(sum); };
        //람다식
        myDelegate += () => print(sum);

        myDelegate += Print;
        myDelegate += Back;

    }*/
    delegate void MyDelegate<T>(T a, T b);
    MyDelegate<int> myDelegate;

    private void Start()
    {
        myDelegate += (int a, int b) => print(a + b);

        myDelegate(3, 5);
    }
}
