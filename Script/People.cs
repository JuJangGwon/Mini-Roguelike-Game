using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour {

    int i = 1;
    bool ak;
    public GameObject text;

    Rigidbody2D rid2;

    void Start () {
        if (transform.position.x <= 0) i = 1;
        if (transform.position.x > 0) i = 2;

        rid2 = GetComponent<Rigidbody2D>();
    }
	    
	void Update () {
        if (i == 1) { rid2.velocity = new Vector2(100 * Time.smoothDeltaTime, 0); transform.rotation = Quaternion.Euler(0, 180, 0); }
        if (i == 2) { rid2.velocity = new Vector2(-100 * Time.smoothDeltaTime, 0); transform.rotation = Quaternion.Euler(0, 0, 0); }

            if (transform.position.x > 13 || transform.position.x < -13) Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "pf")
        {
            transform.position = new Vector3(0, 20, 0);
            text.SetActive(true);
            StartCoroutine(MoveCoroutine(text, new Vector2(0, 0), 2));
            gameObject.SetActive(false);
        }
    }
    IEnumerator MoveCoroutine(GameObject tx,Vector2 endPos, float duration)
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        while (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            tx.transform.localPosition = Vector2.Lerp(tx.transform.localPosition, endPos, Time.smoothDeltaTime*0.001f);
            yield return waitForEndOfFrame;
        }
        tx.transform.localPosition = endPos;
        yield return 0;
    }
}
