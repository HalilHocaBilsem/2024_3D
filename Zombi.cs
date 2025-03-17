using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// Bu scripti zombi nesnesine atayın. 
/// Zombinin kafa kısmını scripte atamanız gerekecektir.
/// </summary>
public class Zombi : MonoBehaviour
{
    //zombi kafa objesi
    public GameObject kafa;


    public int Can = 100;
    public bool CanliMi = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mermi")
        {
            Can -= 20;

        }
        var silah = collision.gameObject.GetComponent<Silah>();
        if (silah != null)
        {
            Can -= silah.Hasar;
        }
        if (Can <= 0)
        {
            CanliMi = false;
            var rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    void Update()
    {
        if (CanliMi)
        {

            // Kafayı kameraya döndür
            Vector3 direction = Camera.main.transform.position - kafa.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            kafa.transform.rotation = Quaternion.RotateTowards(kafa.transform.rotation, targetRotation, 70f * Time.deltaTime); // 



            // Zombiyi oyuncuya yaklaştır.
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, Camera.main.transform.position, 0.4f * Time.deltaTime); 
        }
    }

}
