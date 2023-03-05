using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corotins : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Attack3());
    }

    IEnumerator Attack3()
    {
        yield return new WaitForSecondsRealtime(1f);
    }
}
