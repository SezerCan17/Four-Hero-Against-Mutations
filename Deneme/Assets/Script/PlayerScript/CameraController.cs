using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Player player;

    [SerializeField]
    Collider2D boundsBox;
    void Awake()
    {
        player=Object.FindObjectOfType<Player>();
    }

    
    void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(
                Mathf.Clamp(player.transform.position.x,boundsBox.bounds.min.x,boundsBox.bounds.max.x),
                Mathf.Clamp(player.transform.position.y+1.5f, boundsBox.bounds.min.y, boundsBox.bounds.max.y),
                transform.position.z);

        }
    }
}
