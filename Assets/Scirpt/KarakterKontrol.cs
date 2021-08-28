using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    SpriteRenderer animasyonSprite;
    public Sprite[] animasyonDizi;
    Rigidbody2D fizik;
    int animasyonSayac = 0;
    bool animasyonKontrol = true;
    float animasyonZamani = 0;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        animasyonSprite = GetComponent<SpriteRenderer>();
        
    }
    void Update()
    {
        Animasyon();
        Hareket();
    }

    void Animasyon()
    {
        if (animasyonKontrol)
        {
            animasyonSprite.sprite = animasyonDizi[animasyonSayac];
            animasyonSayac++;
            if (animasyonSayac == animasyonDizi.Length)
            {
                animasyonSayac--;
                animasyonKontrol = false;
            }
        }
        else
        {
            animasyonSprite.sprite = animasyonDizi[animasyonSayac];
            animasyonSayac--;
            if (animasyonSayac == 0)
            {
                animasyonKontrol = true;
            }
        }
    }
    void Hareket()
    {
        if(Input.GetMouseButtonDown(0))
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, 180));
        }
        if(fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        if(fizik.velocity.y<0)
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
    }
}
