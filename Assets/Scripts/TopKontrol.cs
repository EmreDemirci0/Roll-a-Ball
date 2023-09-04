using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    Rigidbody fizik;
    Vector3 baslangic;
    int sayac = 0;
    public int ToplanilacakObjeSayisi;
    public int hiz=5;
    public Text sayacText;
    public Text oyunbittiText;
    private float yatay;
    private float dikey;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        baslangic = transform.position;
    }

    void FixedUpdate()
    {
         yatay = Input.GetAxisRaw("Horizontal");
         dikey = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(yatay,0,dikey);

        fizik.AddForce(vec*hiz);
        if (sayac == ToplanilacakObjeSayisi)
        {//OYUN BITTI
            oyunbittiText.text = "OYUN BITTI";
            transform.position = baslangic;

        }

    }
    private void OnTriggerEnter(Collider col)
    {   
        if(col.gameObject.tag=="engel")
        {
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
            sayac++;
            sayacText.text = "Sayac=" + sayac;
            if(sayac==ToplanilacakObjeSayisi)
            {//OYUN BITTI
                oyunbittiText.text = "OYUN BITTI";
                transform.position = baslangic;
                
            }
        }
        
    }
}
