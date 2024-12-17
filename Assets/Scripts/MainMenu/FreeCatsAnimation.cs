using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCatsAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] _cats;
    [SerializeField] private Transform[] _placesForCats;
    [SerializeField] private Transform _parent;
    [SerializeField] private FreeCats _freeCats;
    [SerializeField] private int _percentOfCats = 200;
    [SerializeField] private Transform _doorPoint;
    [SerializeField] private AudioSource _runCatsAudio;
    [SerializeField] private Animator _kletkaAnimator;
    private List<GameObject> _catsOnCanvas;
    private int _previousNumberOfCats;

    public void Init()
    {
        int number = _freeCats.FreeCatsCounts / _percentOfCats + 1;
        
        _catsOnCanvas = new List<GameObject>();

        if (number > _placesForCats.Length)
        {
            number = _placesForCats.Length;
        }

        _previousNumberOfCats = number;

        for (int i = 0; i < number; i++)
        {
            var cat = Instantiate(_cats[Random.Range(0, _cats.Length)], _parent);
            cat.transform.position = _placesForCats[i].position;
            _catsOnCanvas.Add(cat);
            StartCoroutine(PrisonAnimationDelay(cat.GetComponent<Animator>()));
        }

        _freeCats.End += KletkaFall;
        _freeCats.End += LastCat;
    }

    private void KletkaFall()
    {
        _kletkaAnimator.SetTrigger("EndKletka");
    }

    private void LastCat()
    {
        RunAnimation();
        Destroy(_catsOnCanvas[0]);
        _catsOnCanvas.RemoveAt(0);
    }

    private IEnumerator PrisonAnimationDelay(Animator cat)
    {
        var delay = Random.Range(0, 0.5f);
        yield return new WaitForSeconds(delay);
        cat.SetTrigger("InPrison");
    }

    public void ChangeNumbersOfCats()
    {
        int number = _freeCats.FreeCatsCounts / _percentOfCats + 1;

        if (number > _placesForCats.Length)
        {
            number = _placesForCats.Length;
        }

        //Debug.Log(number);
        //if (number < _placesForCats.Length - 2) number += 1;
        //Debug.Log(number);

        RunAnimation();

        if (_previousNumberOfCats == number) return;

        _previousNumberOfCats = number;

        Destroy(_catsOnCanvas[_catsOnCanvas.Count - 1]);
        _catsOnCanvas.RemoveAt(_catsOnCanvas.Count - 1);
    }

    private void RunAnimation()
    {
        var runCat = Instantiate(_cats[Random.Range(0, _cats.Length)], _doorPoint);
        runCat.transform.position = _doorPoint.position;
        runCat.GetComponent<Animator>().SetTrigger("Run");
        _runCatsAudio.Play();
    }

}
