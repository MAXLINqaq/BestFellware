using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortController : MonoBehaviour
{
    public int hitCount;
    public Text text;
    public GameObject Bullet;
    public string[] Str;
    public float[] currentTime;
    public float invokTime = 0;
    public Sprite AngerFort;
    public Sprite EmoFort;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        if (hitCount > 2)
        {
            Destroy(this.gameObject);
            text.text = "";
        }
        else
        {
            text.text = Str[hitCount];
        }
        if (hitCount == 1)
        {
            spriteRenderer.sprite = AngerFort;
        }
        if (hitCount == 2)
        {
            spriteRenderer.sprite = EmoFort;
        }
        if (hitCount < 3)
        {
            invokTime += Time.deltaTime;
            if (invokTime > currentTime[hitCount])
            {
                Instantiate(Bullet, transform.position + new Vector3(0, 5, transform.position.z), transform.rotation);
                invokTime = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            hitCount++;
        }
    }
}
