using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonManager : MonoBehaviour {


   public void direction(int i)
    {
        if (i == 1) Singleton.getInstance.Direction = Dir.up;
        if (i == 2) Singleton.getInstance.Direction = Dir.left;
        if (i == 3) Singleton.getInstance.Direction = Dir.right;
        if (i == 4) Singleton.getInstance.Direction = Dir.down;
        Debug.Log(Singleton.getInstance.Direction);
    }
}
