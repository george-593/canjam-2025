using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public void Toggle(GameObject target)
    {
        target.SetActive(!target.activeSelf);
    }
}
