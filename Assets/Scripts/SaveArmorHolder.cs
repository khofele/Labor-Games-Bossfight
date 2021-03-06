using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveArmorHolder : MonoBehaviour
{
    private static SaveArmorHolder instance = null;

    // keep gameobject with armor references
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
