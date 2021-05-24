using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract public class A : MonoBehaviour
{
    abstract public void ABC();
}
//다중상속할때 interface
//함수, 프로퍼티, 인덱서, 이벤트
//선언만.
interface ITest
{
    void DEF();

    int Salary { get; set; }
}
interface ITest2 : ITest
{

}
public class Interface : A, ITest2
{
    public int Salary {
        get {return 0; }
        set {; }
    }

    //abstract는 재정의할 시 override
    public override void ABC()
    {
        print("aa");
    }
    //interface는 재정의할 시 추가로 붙는것 X
    public void DEF()
    {
        print("bb");
    }
}
