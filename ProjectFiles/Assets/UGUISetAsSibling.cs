using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUISetAsSibling : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        this.transform.SetAsLastSibling();
    }
    // Update is called once per frame

}
