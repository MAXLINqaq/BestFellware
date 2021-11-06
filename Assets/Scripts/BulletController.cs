using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public GameObject PhoneController;
    void Awake()
    {
        this.transform .parent = null;
        PhoneController = GameObject.Find("PhoneController");
    }


    void Update()
    {
        transform.position = transform.position + new Vector3(0, Time.deltaTime * speed,0);
        if(transform .position.y>5)
             Destroy(this.gameObject);
        if (PhoneController.GetComponent<PhoneController>().RingingCount==3)
            Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject  );
            Destroy(coll.gameObject);
        }
    }

}
