using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject Text;


    int rands;
    public GameObject people_pf;

    float _time = 0;

    void Awake()
    {
      //  Text = GameObject.FindWithTag("losetext");
    }
	void Start () {
        rands = Random.Range(2, 5);
    }
	
	void Update () {
        _time += Time.smoothDeltaTime;
        
        if (_time > rands)
        {
            _time = 0;
            GameObject gb = Instantiate(people_pf);
            gb.transform.position = new Vector2(-10, 0);

            GameObject gb2 = Instantiate(people_pf);
            gb2.transform.position = new Vector2(9, 0);

            rands = Random.Range(2, 4);
        }
	}
    void finish()
    {

    }
}
