using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Human : MonoBehaviour
{
    //protected : 상속 받은 클래스에서만 사용 가능.
    protected string humanName;
    protected int humanAge;

    // virtual 자식 클래스에서 재정의
    protected virtual void Info()
    {
        print("인간");
    }
    abstract protected void Name();
    //추상클래스화
    //자식 클래스에서 반드시 포함해야함.
    //abstract를 사용할 시, 이 클래스에도 abstract를 추가해야함.
}
