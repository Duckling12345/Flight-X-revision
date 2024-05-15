using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletColor : MonoBehaviour
{
    public Image image1;
    public Image image3;
    public GameObject image2;
    public void ChangeColor()
    {
        image1.color = new Color(0.2078f, 0.3098f, 0.549f);
        image3.color = new Color(0.2078f, 0.3098f, 0.549f);
    }
 
    public void HideBullet()
    {
        image2.SetActive(false);
    }
}
