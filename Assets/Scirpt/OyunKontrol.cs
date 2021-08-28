using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public GameObject gökyüzüBir;
    public GameObject gökyüzüIki;
    public GameObject engel;
    GameObject[] engelDizisi;
    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;
    float arkaPlanHız = -1.8f;
    float arkaPlanUzunluk = 0;
    float engelOlusturmaZaman = 0;
    int engelSayac = 0;

    void Start()
    {
        fizikBir = gökyüzüBir.GetComponent<Rigidbody2D>();
        fizikIki = gökyüzüIki.GetComponent<Rigidbody2D>();

        fizikBir.velocity = new Vector2(arkaPlanHız, 0);
        fizikIki.velocity = new Vector2(arkaPlanHız, 0);
        arkaPlanUzunluk = gökyüzüBir.GetComponent<BoxCollider2D>().size.x;

        for (int i = 0; i < engelDizisi.Length; i++)
        {
            engelDizisi[i] = Instantiate(engel, new Vector2(2.71f, 0), Quaternion.identity);
            Rigidbody2D engelFiziği = engelDizisi[i].AddComponent<Rigidbody2D>();
            engelFiziği.gravityScale = 0;
            engelFiziği.velocity = new Vector2(arkaPlanHız, 0);


        }
    }


    void Update()
    {
        if(gökyüzüBir.transform.position.x <= -arkaPlanUzunluk)
        {
            gökyüzüBir.transform.position += new Vector3(2 * arkaPlanUzunluk, 0);
        }
        if(gökyüzüIki.transform.position.x <= -arkaPlanUzunluk)
        {
            gökyüzüIki.transform.position += new Vector3(2 * arkaPlanUzunluk,0);
        }

        engelOlusturmaZaman = Time.deltaTime;
        if(engelOlusturmaZaman>=2f)
        {
            engelOlusturmaZaman = 0;
            float yEksen = Random.Range(0.17f, 2.18f);
            engelDizisi[engelSayac].transform.position = new Vector3(3, yEksen);
            engelSayac++;
            if(engelSayac==engelDizisi.Length)
            {
                engelSayac = 0;

            }
        }

        
    }
}
