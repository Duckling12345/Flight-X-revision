using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrayOutBullet : MonoBehaviour
{
    public Image Bullet;

    public void GrayOutImage()
    {
        Bullet.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
    }
}
