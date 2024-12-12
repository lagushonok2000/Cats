using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickDestroy : MonoBehaviour
{
    [SerializeField] private float _realTimeDestroy;
    public void ClickOnCat(GameObject catObject)
    {
        int countChild = catObject.transform.childCount;

        for (int i = 0; i < countChild; i++)
        {
            if (catObject.transform.GetChild(i).GetComponent<Image>() != null)
            {
                catObject.transform.GetChild(i).gameObject.SetActive(false);
                break;
            }
        }
        StartCoroutine(RealDestroy(catObject));
    }

    private IEnumerator RealDestroy(GameObject catObject)
    {
        yield return new WaitForSeconds(_realTimeDestroy);
        Destroy(catObject);
    }
}
