using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Oyuncunun sağlık bilgisini gösterir.
/// Zombiye dokununca 10 can gider.
/// </summary>
public class OyuncuCa : MonoBehaviour
{
    //Can bilgisi yazılacak TextMeshPro alanıkd.
    public TMPro.TMP_Text canAlani;
    int Can = 100;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        canAlani.text = Can.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "zombi")
        {
            Can -= 10;
        }
    }
}
