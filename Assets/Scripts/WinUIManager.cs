using UnityEngine;

public class WinUIManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public void OnWin()
    {
        target.SetActive(true);
    }
}
