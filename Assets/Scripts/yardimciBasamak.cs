using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yardimciBasamak : MonoBehaviour
{
    public GameObject basamak;
    // Start is called before the first frame update
    void Start()
    {
        basamak.SetActive(false);
    }

    public void activatePanel()
    {
        basamak.SetActive(true);
    }
}
