using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            var isin = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit carpilanNesne;

            var carptiMi = Physics.Raycast(isin, out carpilanNesne, 4);

            if (carptiMi == true)
            {
                carpilanNesne.rigidbody.AddForce(Camera.main.transform.forward * 5, ForceMode.VelocityChange);
            }
        }

    }
}
