using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Text_UI : MonoBehaviour
{
    int suu1;
    int suu2;
    float ti = 0;
    tamacontroller tama;
    GameObject suu_ui1;
    GameObject suu_ui2;
    GameObject time;
    void Start()
    {
        tama = GameObject.FindObjectOfType<tamacontroller>();
        suu_ui1 = GameObject.Find("suu_text1");
        suu_ui2 = GameObject.Find("suu_text2");
        time = GameObject.Find("time");
        suu1 = Random.Range(1, 10);
        suu2= Random.Range(1, 10);
        suu_ui1.GetComponent<Text>().text = suu1+"";
        suu_ui2.GetComponent<Text>().text = suu2+"";
    }
    private void Update()
    {
        ti += Time.deltaTime;
        time.GetComponent<Text>().text = ti.ToString("F1") + "";
    }
    public void No_1()
    {
        tama.suu = suu1;
        suu1 = Random.Range(1, 10);
        suu_ui1.GetComponent<Text>().text = suu1 + "";

    }
    public void No_2()
    {
        tama.suu = suu2;
        suu2 = Random.Range(1, 10);
        suu_ui2.GetComponent<Text>().text = suu2 + "";
    }
}
