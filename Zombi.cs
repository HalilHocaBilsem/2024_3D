using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zombi nesnesinde çalıştırılacak koddur.
/// Zombinin hasar alması için fırlatılan topun top tagine sahip olması gerekir.
/// Zombi kafası scripte tanımlanmalıdır.
/// </summary>
public class Zombi : MonoBehaviour
{

    public GameObject kafa;
    public int Can = 100;
    public bool CanliMi = true;



    void Update()
    {
        if (CanliMi==false)
        {
            return;
        }

        Vector3 directionToCamera = Camera.main.transform.position - transform.position;

        // Sadece Y ekseninde dönme işlemi yapılacak
        directionToCamera.y = 0;

        // Objeyi kameraya doğru yavaşça döndür
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);

        // Yavaşça dönüş
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 50 * Time.deltaTime);


        var ortaNokta =Vector3.Lerp(this.transform.position, Camera.main.transform.position,0.9f* Time.deltaTime);
        this.transform.position=ortaNokta;
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="top")
        {
            Can -= 5;
            if (Can<=0)
            {
                CanliMi = false;
        var rb=GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
