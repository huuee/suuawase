using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kabetext : MonoBehaviour
{
    int Point = 0;
    int Target;
    TextMesh textMesh;
    GameObject parent;
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        parent = transform.parent.gameObject;
    }

    void Update()
    {
        Point = parent.GetComponent<kabecontroller>().Point;
        Target = parent.GetComponent<kabecontroller>().Target;

        textMesh.text = Point+"/"+Target;
    }
 }
