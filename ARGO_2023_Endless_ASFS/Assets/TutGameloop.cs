using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutGameloop : MonoBehaviour
{
    public GameObject tip1;
    public GameObject tip2;
    public GameObject tip3;
    public GameObject tip4;
    public GameObject tip5;
    public GameObject tip6;
    public GameObject tip7;
    public GameObject tip8;
    public GameObject tip9;
    public GameObject yes;
    public GameObject no;
    public GameObject tipB;



    public GameObject enemy;
    public GameObject tumbleweed;
    public GameObject cacti;
    public Transform p1;


    public bool Ai = true;
    public bool obs = true;

    public int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (num == 1)
        {
            tip1.SetActive(true);
        }
        if (num == 2)
        {
            tip1.SetActive(false);
            tip2.SetActive(true);
        }
        if (num == 3)
        {
            tip2.SetActive(false);
            tip3.SetActive(true);
        }
        if (num == 4)
        {
            tip3.SetActive(false);
            tip4.SetActive(true);
        }
        if (num == 5)
        {
            tip4.SetActive(false);
            tip5.SetActive(true);
        }
        if (num == 6)
        {
            tip5.SetActive(false);
            tip6.SetActive(true);
            if(Ai == true)
            { 
                Instantiate(enemy, transform.position, transform.rotation);
                Ai = false;
            }
        }
        if (num == 7)
        {
            tip6.SetActive(false);
            tip7.SetActive(true);

        }
        if (num == 8)
        {
            tip7.SetActive(false);
            tip8.SetActive(true);
            if (obs == true)
            {
                GameObject o1 = Instantiate(cacti, transform.position, transform.rotation);
                GameObject o2 = Instantiate(tumbleweed, p1.position, transform.rotation);
                obs = false;
                Destroy(o1, 5);
                Destroy(o2, 5);
            }
        }
        if (num == 9)
        {
            tip8.SetActive(false);
            tipB.SetActive(false);
            tip9.SetActive(true);
            yes.SetActive(true);
            no.SetActive(true);

        }
    }

    public void tips1()
    {
        num++;
    }

    public void yesV()
    { 
        SceneManager.LoadScene("Tutorial");
    }

    public void noV()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
