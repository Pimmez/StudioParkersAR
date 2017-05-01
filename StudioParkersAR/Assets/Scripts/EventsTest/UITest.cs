using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour {

    public static void UIImageTrue()
    {
        Debug.Log("UIImage was called eventhough it wasn't in the scene");
    }

    public static void UIImageFalse()
    {
        Debug.Log("UIImage was called eventhough it wasn't in the scene");
    }

}
