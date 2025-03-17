using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Tanımlanan Mermi nesnesinin kopyasını oluşturup ileriye fırlatır.
/// </summary>
public class AtesEt : MonoBehaviour
{
    public GameObject Mermi;
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var yeniTop=Instantiate(Mermi);
            yeniTop.transform.position=Camera.main.transform.position;

            var rb=yeniTop.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward*40, ForceMode.VelocityChange);
        }
    }
}
