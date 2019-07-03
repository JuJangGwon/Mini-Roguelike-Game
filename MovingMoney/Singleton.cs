using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Dir
{
    none,
    up,
    left,
    right,
    down
}
public enum Gamestate
{
    none,
    lose,
    win
}

public class Singleton : MonoBehaviour
{
    private static Singleton instance;


    public static Singleton getInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(Singleton)) as Singleton;
            }

            if (instance == null)
            {
                GameObject obj = new GameObject("obj");
                instance = obj.AddComponent(typeof(Singleton)) as Singleton;
            }

            return instance;
        }
    }

    public Dir Direction = Dir.none;
    public bool Game = false;
    public Gamestate GameState = Gamestate.none;
}