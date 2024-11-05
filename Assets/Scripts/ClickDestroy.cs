using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDestroy : MonoBehaviour
{
    public void ClickOnCat(GameObject catObject)
    {
        Destroy(catObject);
    }
}
