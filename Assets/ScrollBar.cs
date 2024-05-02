using UnityEngine;
using UnityEngine.UI;

public class ScrollbarController : MonoBehaviour
{
    public Scrollbar scrollbar;

    void Start()
    {
        scrollbar.value = 0f; // Set the scrollbar value to zero
    }
}
