using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamatext : MonoBehaviour
{
    tamacontroller tama;
    TextMesh textMesh;
    void Start()
    {
        textMesh=GetComponent<TextMesh>();
        tama = GameObject.FindObjectOfType<tamacontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = tama.suu+"";
    }
}
