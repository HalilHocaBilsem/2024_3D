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

        if (Input.GetKeyUp(KeyCode.K))
        {

            var isin = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit carpanNesne;

            bool carptiMi = Physics.Raycast(isin, out carpanNesne, 5);

            if (carptiMi == true)
            {
                if (carpanNesne.rigidbody != null)
                {
                    carpanNesne.rigidbody.AddForce(Camera.main.transform.forward*5, ForceMode.VelocityChange);
                }


            }

        }

    }
}
