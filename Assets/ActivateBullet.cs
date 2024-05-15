using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBullet : MonoBehaviour
{
    public GameObject image3;
    public GameObject image2;


    public void activateBullet()
    {
        image3.SetActive(true);
    }

    public void removeImage()
    {
        image2.SetActive(false);
    }



}
