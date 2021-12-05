using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceConroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeFace()
    {
        if (this.transform.localScale.x == 1)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
