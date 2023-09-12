using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        Vector3 old = transform.position;
        transform.position = new Vector3(old.x, old.y, player.position.z + offset.z);

        // transform.position = player.position + offset;
    }
}
