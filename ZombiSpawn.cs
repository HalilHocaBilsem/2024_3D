using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Belirli bir konumdan zombi üretmek için kullanılır.
/// Boş bir gameobject veya collideri olmayan bir 3D nesne kullanılabilir.
/// </summary>
public class ZombiSpawn : MonoBehaviour
{

    public int Saniye;
    public DateTime SonSpawnTarih;
    public GameObject Zombi;

    void Start()
    {
        
    }

 
    void Update()
    {
        if (SonSpawnTarih.AddSeconds(Saniye)<DateTime.Now)
        {
           var yeniZombi= Instantiate(Zombi);
            yeniZombi.transform.position = this.gameObject.transform.position;
            SonSpawnTarih = DateTime.Now;
        }
    }
}
