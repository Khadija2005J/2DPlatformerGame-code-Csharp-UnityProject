using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light sceneLight;
    private void OnMouseDown()
    {
        if (sceneLight != null)
        {
            sceneLight.enabled = !sceneLight.enabled;
        }
    }
}
