using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    public void AutoDestroy()
    {
        Destroy(this.gameObject);
    }
}
