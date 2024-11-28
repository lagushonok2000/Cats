using System.Collections.Generic;
using UnityEngine;

public class FreeCatsAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] _freeCats;
    [SerializeField] private Transform[] _placesForCats;
    [SerializeField] private Transform _parent;
    [SerializeField] private FreeCatsCounter _freeCatsCounter;
    [SerializeField] private int _percentOfCats = 100;
    [SerializeField] private Transform _doorPoint;
    private List<GameObject> _catsOnCanvas;
    private int _previousNumberOfCats;

    public void Init()
    {
        int number = _freeCatsCounter.Counter / _percentOfCats;
        _previousNumberOfCats = number;
        Debug.Log(number);
        _catsOnCanvas = new List<GameObject>();

        for(int i = 0; i < number; i++)
        {
            var cat = Instantiate(_freeCats[Random.Range(0, _freeCats.Length)], _parent);
            cat.transform.position = _placesForCats[i].position;
            Debug.Log(_placesForCats[i].name);
            _catsOnCanvas.Add(cat);
            cat.GetComponent<Animator>().SetTrigger("InPrison");
        }
    }

    public void ChangeNumbersOfCats()
    {
        int number = _freeCatsCounter.Counter/_percentOfCats;

        RunAnimation();

        if (_previousNumberOfCats == number) return;

        _previousNumberOfCats = number;

        Destroy(_catsOnCanvas[_catsOnCanvas.Count - 1]);
        _catsOnCanvas.RemoveAt(_catsOnCanvas.Count - 1);

        
    }

    private void RunAnimation()
    {
        var runCat = Instantiate(_freeCats[Random.Range(0, _freeCats.Length)], _doorPoint);
        runCat.transform.position = _doorPoint.position;
        runCat.GetComponent<Animator>().SetTrigger("Run");
    }
}
