using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 델리게이트 : MonoBehaviour
{
    public delegate void ChainFunction(int value);
    //ChainFunction을 이용하는 모든 함수는 int value를 가져야함, 개수 통일
    public static event ChainFunction OnStart;
    //static을 선언하면 모든 스크립트에서 사용 가능.

    int power;
    int defence;

    public void SetPower(int value)
    {
        power += value;
        print("power 값이 " + value + " 만큼 증가" + power);
    }
    public void SetDefence(int value)
    {
        defence += value;
        print("defence 값이 " + value + " 만큼 증가" + defence);
    }
    // Start is called before the first frame update
    void Start()
    {
        //SetPower(5);
        //SetDefence(5);

        OnStart += SetPower;
        OnStart += SetDefence;

        //chain -= SetDefence;

        OnStart?.Invoke(5);
        //if(chain != null)
        //  chain(5)
    }
    private void OnDisable()
    {
        
    }
}
