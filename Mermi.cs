using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fırlatılan mermilerin 4 saniye sonra yok olmalarını sağlar. 
/// Mermi objesine atanmalıdır.
/// </summary>
public class Mermi : MonoBehaviour
{

    DateTime olusturmaZamani;
 
    void Start()
    {
        olusturmaZamani = DateTime.Now;
    }

    void Update()
    {
        if (olusturmaZamani.AddSeconds(4)<DateTime.Now)
        {
            Destroy(this.gameObject);
        }
    }
}
