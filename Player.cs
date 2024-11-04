using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Player isimli kapsüle eklediğimiz CharacterController'a ulaşmak için bir değişken oluştur
    CharacterController karakter = null;
    //Yürüme hızı
    [SerializeField]
    float yurumeHizi = 100f;
    //mouse (fare) hassasiyeti. Bunu artırırsak fare hızı artar.
    [SerializeField]
    float fareHassasiyet = 500f;
    //yer çekimi miktarı
    [SerializeField]
    float yerCekimi = -0.05f;

    //karakterin Y yönündeki hareket miktarını belirten değişken
    float dikeyHareketMiktar = 0;
    //ziplama gücü [SerializeField] bunun editör ekranından düzenlenmesini sağlar.
    [SerializeField]
    float ziplamaGucu = 4;


    //Bu metot oyun başladığında 1 kez çalışır.
    void Start()
    {
        //CharacterController komponentini al.
        karakter = GetComponent<CharacterController>();
        dikeyHareketMiktar = yerCekimi;
    }



    //Bu metot ekran her çizildiğinde çalıştırılır.
    //Youn 100 FPS ile çalışıyor ise bu metot saniyede 100 kez çalışır.
    void Update()
    {
        //SOLA-SAĞA BAKMA KISMI
        //önce farenin sağ sol yöndeki hareketini al ve bunu hassasiyet değeri ile çarp.
        var mouseX = Input.GetAxis("Mouse X") * fareHassasiyet;
        //sağ sol yöndeki haret miktarınca karakteri Y ekseni etrafında döndür.
        transform.Rotate(0, mouseX*Time.deltaTime, 0);

        //YUKARI AŞAĞI BAKMA KISMI

        //önce farenin yukar-aşağı hareketini al ve bunu mouse hassasiyet değeri ile çarp.
        //Ancak harekt yönü ters olduğu için bunu bir de -1 ile çarpıp tersine çevir.
        var mouseY = Input.GetAxis("Mouse Y") * fareHassasiyet * -1;
        // Kamerayı X ekseni etrafında döndür
        Camera.main.transform.Rotate(mouseY*Time.deltaTime, 0, 0);


        //YÜRÜME BÖLÜMÜ
        if (Input.GetKey(KeyCode.W))
        {
            //Eğer W basılı ise yürüme hızını ileri yön ile çarp ve hareket ettir.
            karakter.Move(transform.forward * yurumeHizi*Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Eğer S basılı ise ileri yönü -1 ile çarparak geriye çevir sonra  yürüme hızını ile  çarp ve hareket ettir.
            karakter.Move(transform.forward * yurumeHizi * -1 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //sağ hareket yukarıdaki gibi
            karakter.Move(transform.right * yurumeHizi*Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //sola hareket sağ yönü -1 ile çarparak elde ediyoruz.
            karakter.Move(transform.right * yurumeHizi * -1 * Time.deltaTime);
        }
        //dikey hareketi gerçekleştir.
        karakter.Move(new Vector3(0, dikeyHareketMiktar, 0*Time.deltaTime));

        //ZIPLAMA
        if (karakter.isGrounded)
        {
            //karakter yere değiyor ise buraya girer.
            if (Input.GetKey(KeyCode.Space))
            {
                //zıplama hareketini yap.
                dikeyHareketMiktar = Mathf.Abs(ziplamaGucu * yerCekimi);
            }
        }

        //yukarı hareket yönü eğer yerçekiminden büyük ise onu sürekli olarak azalt.
        if (dikeyHareketMiktar>yerCekimi)
        {
            dikeyHareketMiktar = dikeyHareketMiktar - Mathf.Abs(yerCekimi/6);
        }
    }
}
