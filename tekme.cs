using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kup : MonoBehaviour
{

    void Update()
    {
        //eğer kullanıcı K tuşuna basarsa
        if (Input.GetKeyDown(KeyCode.K)==true)
        {
            Ray isin = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit carpilanNesne;
            if (Physics.Raycast(isin, out carpilanNesne, 5)==true)
            {
                if (carpilanNesne.rigidbody!=null)
                {
                    carpilanNesne.rigidbody.AddForce(Camera.main.transform.forward * 5, ForceMode.VelocityChange);
                }
            }
        }
       
    }
}
