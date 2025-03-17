using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zombi nesnesi üzerinde çalışacak scripttir. 
/// Zombi kafasının scripte tanımlanması gerekmektedir. 
/// Zombinin hasar alması için fırlatılan topların mermi tagine sahip olması gerekir.
/// </summary>
public class Zombi : MonoBehaviour
{
  
    public int Can = 100; 
    public bool CanliMi = true;

    public GameObject Kafa;
    void Start()
    {
        CanliMi = true;
        Can = 100;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mermi")
        {
            Can = Can - 10;

            if (Can <= 0)
            {
                CanliMi = false;
                var rb = GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
            }
        }
    }


    void Update()
    {
        if (CanliMi == true)
        {
            Vector3 hedef = Vector3.Lerp(this.gameObject.transform.position, Camera.main.transform.position, 0.5f * Time.deltaTime);
            this.transform.position = hedef;

            Kafa.transform.LookAt(Camera.main.transform.position);
        }
    }
}
