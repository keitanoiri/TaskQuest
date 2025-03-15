using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBigImage : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }
}
