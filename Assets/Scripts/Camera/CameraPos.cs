using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public Transform wraith;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(wraith.position.x, 0.13f, 16.2f),
                                         Mathf.Clamp(wraith.position.y, 0.11f, 1.09f),
                                         transform.position.z);

    }

}
