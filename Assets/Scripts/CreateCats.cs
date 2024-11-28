using System.Collections;
using UnityEngine;

public class CreateCats : MonoBehaviour
{
    [SerializeField] public Cat[] _cats;
    [SerializeField] private Transform _parent;
    [SerializeField] private LevelsSO _levelSO;

    public Hole[] Holes;


    public bool IsCreate = true;

    public IEnumerator ObjectsCreation()
    {
        IsCreate = true;
        while (IsCreate)
        {
            Debug.Log(Level.Current);
            PlacesCheck();
            yield return new WaitForSeconds(_levelSO.TimeCreate[Level.Current]);
        }
    }    

    private void CreateObjects(Hole hole)
    {
        int indexPrefab = ChooseCat();
        GameObject obj = Instantiate(_cats[indexPrefab].gameObject, _parent);
        obj.transform.position = hole.transform.position;
        hole.IsFree = false;
        StartCoroutine(DestroyObjects(obj, hole));
    }

    private int ChooseCat()
    {
        float cummulativeProbability = 0f;
        float random = Random.Range(0, 100f);

        if (ProbabilityCheck() == false)
        {
            Debug.LogError("Олег конченный");
            return 0;
        }

        for (int i = 0; i < _cats.Length; i++)
        {
            cummulativeProbability += _cats[i].Probability;

            if (random < cummulativeProbability)
            {
                return i;
            }
        }
        return 0;
    }

    private bool ProbabilityCheck()
    {
        float summProbability = 0f;

        for (int i = 0; i < _cats.Length; i++)
        {
            summProbability += _cats[i].Probability;
        }

        if (summProbability != 100f) return false;
        return true;
    }

    public IEnumerator DestroyObjects(GameObject o, Hole hole)
    {
        yield return new WaitForSeconds(_levelSO.TimeDestroy[Level.Current]);
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
