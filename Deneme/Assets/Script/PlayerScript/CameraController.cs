using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Player player;

    [SerializeField]
    Collider2D boundsBox;

    private float halfY;
    private float halfX;
    void Awake()
    {
        player=Object.FindObjectOfType<Player>();
    }

    private void Start()
    {
        halfY = Camera.main.orthographicSize;
        halfX=halfY*Camera.main.aspect;
    }


    void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(
                Mathf.Clamp(player.transform.position.x,boundsBox.bounds.min.x+halfX,boundsBox.bounds.max.x-halfX),
                Mathf.Clamp(player.transform.position.y+1.5f, boundsBox.bounds.min.y+halfY, boundsBox.bounds.max.y-halfY),
                transform.position.z);

        }
    }
}
