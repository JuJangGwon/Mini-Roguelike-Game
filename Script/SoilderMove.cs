using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Characterstate
{
    none,
    move,
    die
}

public class SoilderMove : MonoBehaviour {

    int b;
    float _time = 0;
    int pos = 0;
    bool moving = false;

    Rigidbody2D rid2;

    Characterstate state = Characterstate.none;

    void Start() {

        if (transform.position.x == 7.5) pos = 3;
        if (transform.position.x == 0) pos = 2;
        if (transform.position.x == -7.5) pos = 1;
        rid2 = GetComponent<Rigidbody2D>();
        rid2.velocity = Vector2.zero;
    }

    void Update() {
        if (state == Characterstate.none)
        {
            _time += Time.smoothDeltaTime;
            if (_time > 2.5f)
            {
                _time = 0;
                b = Random.Range(1, 3);
                if (b == 2) b = Random.Range(1, 3); state = Characterstate.move;
            }
        }
        if (state == Characterstate.move)
        {
            if (pos == 1) move(150);
            if (pos == 3) move(-150);
            if (pos == 2)
            {
                if (b == 1) move(150);
                else if (b == 2) move(-150);
            }
        }
    }

    void move(int dir)
    {
        if (moving == false)
        {
          
            moving = true;
        }
        else
        {
            _time += Time.smoothDeltaTime;
            if (_time < 3)
            {
                rid2.velocity = new Vector2(dir * Time.smoothDeltaTime, 0);
            }
            else
            {
                _time = 0;
                rid2.velocity = Vector2.zero;
                state = Characterstate.none;
                moving = false;
                if (dir == 150) pos++;
                else if (dir == -150) pos--;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "pf")
        {
            Destroy(gameObject,0.5f);
        }
    }
}
