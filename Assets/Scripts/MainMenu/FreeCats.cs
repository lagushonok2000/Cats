using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FreeCats : MonoBehaviour
{
    [SerializeField] private GameObject _prison;
    [SerializeField] private FreeCatsButton _freeCatsButton;
    [SerializeField] private LevelsSO _levelSO;
    [SerializeField] private TMP_Text _allPointsText;
    [SerializeField] private TMP_Text _freeCatsCountsText;
    [SerializeField] private TMP_Text _staticText;
    [SerializeField] private FreeCatsAnimation _freeCatsAnimation;
    public Action End;
    public int FreeCatsCounts { get; private set; }
    public int AllPoints { get; private set; }
    private Coroutine _catsCountsDecreaseCoroutine;


    private void Start()
    {
        _freeCatsButton.Down += FreeCatsButtonDown;
        _freeCatsButton.Up += FreeCatsButtonUp;
        InitFreeCatsCount();
        InitAllPoints();
        _freeCatsAnimation.Init();

        if (PlayerPrefs.HasKey(SaveKeys.EndGame) == true)
        {
            _prison.SetActive(false);
            _freeCatsButton.gameObject.SetActive(false);
            _freeCatsCountsText.gameObject.SetActive(false);
        }
    }

    private void InitFreeCatsCount()
    {
        if (PlayerPrefs.HasKey(SaveKeys.FreeCatsCounter))
        {
            FreeCatsCounts = PlayerPrefs.GetInt(SaveKeys.FreeCatsCounter);
        }
        else
        {
            FreeCatsCounts = _levelSO.DefaultCatscounter;
            PlayerPrefs.SetInt(SaveKeys.FreeCatsCounter, FreeCatsCounts);
            PlayerPrefs.Save();
        }
        UpdateTextCatsCounts();
    }
    private void InitAllPoints()
    {
        if (PlayerPrefs.HasKey(SaveKeys.AllPoints))
        {
           AllPoints = PlayerPrefs.GetInt(SaveKeys.AllPoints);
        }
        else
        {
            AllPoints = 0;
            PlayerPrefs.SetInt(SaveKeys.AllPoints, AllPoints);
            PlayerPrefs.Save();
        }
        UpdateTextCatsCounts();
    }

    private IEnumerator CatCountsDecrease()
    {
        while(true)
        {
            if (AllPoints <= 0)
            {
                AllPoints = 0;
                break;
            }

            AllPoints--;
            FreeCatsCounts--;

            if (FreeCatsCounts <= 0)
            {
                FreeCatsCounts = 0;
                EndFreeCounts();
                UpdateTextCatsCounts();
                break;
            }

            UpdateTextCatsCounts();
            _freeCatsAnimation.ChangeNumbersOfCats();

            yield return new WaitForSeconds(_levelSO.SpendTime);
        }

    }

    private void Save()
    {
        PlayerPrefs.SetInt(SaveKeys.FreeCatsCounter, FreeCatsCounts);
        PlayerPrefs.SetInt(SaveKeys.AllPoints, AllPoints);
        PlayerPrefs.Save();
    }

    private void UpdateTextCatsCounts()
    {
        _allPointsText.text = AllPoints.ToString();
        _freeCatsCountsText.text = FreeCatsCounts.ToString();
    }

    private void EndFreeCounts()
    {
        End?.Invoke();
        _freeCatsButton.gameObject.SetActive(false);
        _allPointsText.gameObject.SetActive(false);
        _freeCatsCountsText.gameObject.SetActive(false);
        _staticText.gameObject.SetActive(false);
        FreeCatsButtonUp();
        PlayerPrefs.SetInt(SaveKeys.EndGame, 1);
        PlayerPrefs.Save();
    }

    private void FreeCatsButtonDown()
    {
        _catsCountsDecreaseCoroutine = StartCoroutine(CatCountsDecrease());
    }

    private void FreeCatsButtonUp()
    {
        if (_catsCountsDecreaseCoroutine != null) StopCoroutine(_catsCountsDecreaseCoroutine);
        Save(); 
    }
}
