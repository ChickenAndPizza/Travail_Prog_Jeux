using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldEnd : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        Attackable attackable = col.gameObject.GetComponent<Attackable>();
        if (attackable != null)
        {
            attackable.Attacked(100);
        }
    }
}
