using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCoreController : MonoBehaviour
{
    public GameObject PosPoint;// Start is called before the first frame update
    public GameObject PickLockController;
    public float currentTime;
    public float Mag;
    public GameObject UpperHalf;
    public GameObject LatterHalf;
    public bool isDone;
    public AudioSource As;
    private float invokeTime;
   
    void Awake()
    {
        PosPoint.transform.parent = null;
        isDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDone)
        {
            Mag = (PosPoint.transform.position - UpperHalf.transform.position).magnitude;
            if (Mag < 0.2)
            {
                UpperHalf.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, Mag * 3, 1); 
                LatterHalf.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, Mag * 3, 1); 
            }
            if (Mag < 0.05)
            {
                invokeTime += Time.deltaTime;
                if (invokeTime > currentTime)
                {
                    PickLockController.GetComponent<PickLockController>().UnlockCount++;
                    invokeTime = 0;
                    UpperHalf.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
                    isDone = true;
                    LatterHalf.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
                    As.Play();
                }
            }
            else
            {
                invokeTime = 0;
            }
        }
    }
}
