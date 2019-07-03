using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
// 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1
// 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1
// 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1
// 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1
// 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1
// 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1
// 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 3
// 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1
// 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1


    // 2 = 벽 / 1 = O

public class movingmoney : MonoBehaviour {


    public GameObject RedScreen;
    public GameObject whileScreen;


    public GameObject Camera;

    public GameObject tileHouse;

    int MyPositionx = 1;
    int MYPositionY = 1;

    int[,] kts = new int[10, 20];

    float _time = 0;

    public GameObject seet;
    public GameObject seet2;
    public GameObject seet3;

    public GameObject Character;
    Animator Character_anim;

    public GameObject monster;
    Animator monster_anim;

    public GameObject monster1;
    Animator monster1_anim;

    public GameObject monster2;
    Animator monster2_anim;

    public GameObject monster3;
    Animator monster3_anim;

    public GameObject monster4;
    Animator monster4_anim;

    public GameObject monster5;
    Animator monster5_anim;

    int asd = 0;

    void Start () {
        Singleton.getInstance.Game = true;
        Character_anim = Character.GetComponent<Animator>();
        monster_anim = monster.GetComponent<Animator>();
        monster1_anim = monster1.GetComponent<Animator>();
        monster2_anim = monster2.GetComponent<Animator>();
        monster3_anim = monster3.GetComponent<Animator>();
        monster4_anim = monster4.GetComponent<Animator>();
        monster5_anim = monster5.GetComponent<Animator>();

        Character.transform.position = new Vector3(-6.1f, -6.1f, -1);
        Character.transform.localRotation = Quaternion.Euler(0, 0, 0);
        for (int i = 0; i< 10; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                kts[i,j] = 1;
            }
        }
        for (int i = 0; i < 20; i++)
        {
            kts[0,i] = 2;
            kts[9,i] = 2;
        }
        for (int i = 0; i < 10; i++)
        {
            kts[i,0] = 2;
            kts[i,19] = 2;
        }
        kts[9, 18] = 3;
        for(int i = 0; i< 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (kts[j, i] == 2 || kts[j, i] == 3) { GameObject gb2 = Instantiate(seet, new Vector3(i * 1.4f - 8, j * 1.4f - 8, 0), transform.rotation); gb2.transform.SetParent(tileHouse.transform); }
                if (kts[j, i] == 1) { GameObject gb2 = Instantiate(seet2, new Vector3(i * 1.4f - 8, j * 1.4f - 8, 0), transform.rotation); gb2.transform.SetParent(tileHouse.transform); }
            }
        }
        GameObject gb = Instantiate(seet3, new Vector3((18 - 1) * 1.4f - 8, 9 * 1.4f - 8, -1), transform.rotation); gb.transform.SetParent(tileHouse.transform);
    }
	
	// Update is called once per frame
	void Update () {
        if (Singleton.getInstance.Game == true)
        {
            followingCamera();
            if (Singleton.getInstance.Direction != Dir.none)
            {
                if (MoveCheck(Singleton.getInstance.Direction) == true)
                {
                    Character.transform.position = new Vector3(MyPositionx * 1.3f - 7.5f, MYPositionY * 1.3f - 7.4f, -1);
                    Singleton.getInstance.Direction = Dir.none;
                    PlayOneShot();
                    MosnterMove(monster, 6, 5);
                    MosnterMove(monster1, 5, 8);
                    MosnterMove(monster2, 6, 15);
                    MosnterMove(monster3, 7, 18);
                    MosnterMove2(monster4, 11, 8);
                    MosnterMove2(monster5, 15, 3);

                    asd++;
                }
            }
            Debug.Log(MyPositionx + "," + MYPositionY);
        }
        else
        {
            _time += Time.smoothDeltaTime;
            if(_time > 3)                 /// 여기에 신전환 넣어
            if (Singleton.getInstance.GameState == Gamestate.lose) RedScreen.SetActive(true);
            if (Singleton.getInstance.GameState == Gamestate.win) whileScreen.SetActive(true);

        }
    }
    void MosnterMove(GameObject monster,int startPoint,int xpos)
    {
        if(asd == 0)
        {
            monster.transform.position = new Vector3(xpos * 1.4f - 8, startPoint * 1.4f - 8, -1);
            monster.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (asd == 1)
        {
            monster.transform.position = new Vector3(xpos * 1.4f - 8, (startPoint-1) * 1.4f - 8, -1);
        }
        else if (asd == 2)
        {
            monster.transform.position = new Vector3(xpos * 1.4f - 8, (startPoint-2) * 1.4f - 8, -1);
        }
        else if (asd == 3)
        {
            monster.transform.position = new Vector3(xpos * 1.4f - 8, (startPoint-1) * 1.4f - 8, -1);
            monster.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (asd == 4)
        {
            monster.transform.position = new Vector3(xpos * 1.4f - 8, startPoint * 1.4f - 8, -1);
            asd = -1;
        }
    }
    void MosnterMove2(GameObject monster, int startPoint, int ypos)
    {
        if (asd == 0)
        {
            monster.transform.position = new Vector3(startPoint * 1.4f - 8, ypos * 1.4f - 8, -1);
            monster.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (asd == 1)
        {
            monster.transform.position = new Vector3((startPoint-1) * 1.4f - 8, ypos  * 1.4f - 8, -1);
        }
        else if (asd == 2)
        {
            monster.transform.position = new Vector3((startPoint-2) * 1.4f - 8, ypos * 1.4f - 8, -1);
        }
        else if (asd == 3)
        {
            monster.transform.position = new Vector3((startPoint-1) * 1.4f - 8, ypos * 1.4f - 8, -1);
            monster.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (asd == 4)
        {
            monster.transform.position = new Vector3(startPoint * 1.4f - 8, ypos * 1.4f - 8, -1);
            asd = -1;
        }
    }
    bool MoveCheck(Dir dr)
    {
        if (dr == Dir.up)
        {
            if (kts[MYPositionY + 1,MyPositionx] == 2) return false;
        }
        if (dr == Dir.down)
        {
            if (kts[MYPositionY - 1,MyPositionx] == 2) return false;
        }
        if (dr == Dir.left)
        {
            if (kts[MYPositionY ,MyPositionx-1] == 2) return false;
        }
        if (dr == Dir.right)
        {
            if (kts[MYPositionY,MyPositionx + 1] == 2) return false;
        }
        //
        if (dr == Dir.up)
        {
            MYPositionY += 1;
            Character.transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (dr == Dir.down)
        {
            MYPositionY -= 1;
            Character.transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        if (dr == Dir.left)
        {
            MyPositionx -= 1;
            Character.transform.localRotation = Quaternion.Euler(0, 0, 90);

        }
        if (dr == Dir.right)
        {
            MyPositionx += 1;
            Character.transform.localRotation = Quaternion.Euler(0, 0, 270);

        }
        return true;
    }

    void followingCamera()
    {
        Camera.transform.position = Vector3.Lerp(transform.position,new Vector3(Character.transform.position.x, Character.transform.position.y, -10),Time.smoothDeltaTime*4);
    }

    void PlayOneShot()
    {
        Character_anim.SetTrigger("move");
        monster_anim.SetTrigger("move");
        monster1_anim.SetTrigger("move");
        monster2_anim.SetTrigger("move");
        monster3_anim.SetTrigger("move");
        monster4_anim.SetTrigger("move");

    }
}
