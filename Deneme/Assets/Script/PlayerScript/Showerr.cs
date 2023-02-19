using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showerr : MonoBehaviour
{
    public Transform Showerr_;
    public GameObject Shower;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            Shoot2();
        }

    }
    public void Shoot2()
    {
        GameObject sil = Instantiate(Shower, transform.position, transform.rotation);
        Destroy(sil, 0.667f);
    }
}