using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

    public GameObject pf;

    Vector2 touch_pos;
    void Update() {

        if (Input.GetMouseButtonDown(0))
        {

            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            create();

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("사망");
                }
                if (hit.collider.tag == "People")
                {
                    Debug.Log("인간");
                }
            }
        }
    }
    void create()
    {
        GameObject col = Instantiate(pf, Camera.main.ScreenToWorldPoint(Input.mousePosition),transform.rotation);
        col.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, 0);
        Destroy(col,0.2f);
    }
}
