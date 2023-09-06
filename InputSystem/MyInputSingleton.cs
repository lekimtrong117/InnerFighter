using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInputSingleton : MySingleton<MyInputSingleton>
{
    public MyInput myInput;
    private void Awake()
    {
        myInput = new MyInput();
    }
    public void Reload()
    {
        
    }
    public void Reset()
    {
        myInput=null;
        myInput = new MyInput();
    }
    // Start is called before the first frame update
}
