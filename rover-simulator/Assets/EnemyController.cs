using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < Camera.main.transform.position.z) {
            Destroy(this.gameObject);
        }
    }
}
