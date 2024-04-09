using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    public FixedTouchField touchField;
    public CameraLook cameraLook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cameraLook.LockAxis = touchField.TouchDist;
    }
}
