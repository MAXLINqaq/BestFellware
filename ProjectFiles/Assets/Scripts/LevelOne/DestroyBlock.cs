using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            GameObject.Find("Main Camera").SendMessage("ShakeOnEnable");
        }
    }
}
