using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// controls anti aliasing in the project
/// </summary>
public class AntiAliasing : MonoBehaviour
{
    [SerializeField] Dropdown dropdown;

    /// <summary>
    /// sets the anti aliasing level
    /// </summary>
    /// <param name="aaIndex"> the passed parameter </param>
    public void SetAntiAliasing(int aaIndex)
    {
        switch (aaIndex)
        {
            case 0:
                dropdown.value = 0;
                    break;
            case 1:
                dropdown.value = 1;
                break;
            case 2:
                dropdown.value = 2;
                break;
            default:
                break;
        }

        QualitySettings.antiAliasing = aaIndex;
    }


}
