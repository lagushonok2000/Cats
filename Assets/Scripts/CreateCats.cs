using System.Collections;
using UnityEngine;

public class CreateCats : MonoBehaviour
{
    [SerializeField] public GameObject[] _prefabs;
    [SerializeField] private Transform _parent;
    [SerializeField] private LevelsSO _levelSO;

    public Hole[] Holes;


    public bool IsCreate = true;

    public IEnumerator ObjectsCreation()
    {
        IsCreate = true;
        while (IsCreate)
        {
            var a = Random.Range(_levelSO._timeCreate[Level.Current].x, _levelSO._timeCreate[Level.Current].y);
            Debug.Log(Level.Current);
            PlacesCheck();
            yield return new WaitForSeconds(a);
        }
    }    

    private void CreateObjects(Hole hole)
    {
        int indexPrefab = (Random.Range(0, _prefabs.Length));
        GameObject obj = Instantiate(_prefabs[indexPrefab], _parent);
        obj.transform.position = hole.transform.position;
        hole.IsFree = false;
        StartCoroutine(DestroyObjects(obj, hole));
    }
    public IEnumerator DestroyObjects(GameObject o, Hole hole)
    {
        yield return new WaitForSeconds(Random.Range(_levelSO._timeDestroy[Level.Current].x, _levelSO._timeDestroy[Level.Current].y));
        Destroy(o);
        hole.IsFree = true;
    }

    public void DestroyAllCats()
    {
        int countCats = _parent.childCount;
       
        StopAllCoroutines();

        for(int i = 0; i < Holes.Length; i++)
        {
            Holes[i].IsFree = true;
        }
        for(int i = _parent.childCount - 1; i >= 0; i--)
        {
            Destroy(_parent.GetChild(i).gameObject);
        }
    }

    private void PlacesCheck()
    {
        Hole[] freeHoles;
        int k = 0;

        for (int i = 0; i < Holes.Length; i++)
        {
            if (Holes[i].IsFree)
            {
                k++;
            }
        }

        freeHoles = new Hole[k];
        int freeIndex = 0;

        for (int i = 0; i < Holes.Length; i++)
        {
            if (Holes[i].IsFree)
            {
                freeHoles[freeIndex] = Holes[i];
                freeIndex++;
            }
        }
        if (freeHoles.Length > 0)
        {
            CreateObjects(freeHoles[Random.Range(0, freeHoles.Length)]);
        }    
    }
}
