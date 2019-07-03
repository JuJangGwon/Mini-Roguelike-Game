using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "monster")
        {
            Singleton.getInstance.Game = false;
            Singleton.getInstance.GameState = Gamestate.lose;
        }
        if (col.gameObject.tag == "potal")
        {
            Singleton.getInstance.Game = false;
            Singleton.getInstance.GameState = Gamestate.win;
        }
    }
}
