using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LearnAttribute : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject _ball;
    [SerializeField] private bool _sosal;
    [SerializeField,ShowIf("_sosal")] private string _sss;


    private void Update()
    {
        Debug.Log("hgygyu");
    }

    [Button("������")]
    public void ChangeText()
    {
        text.text = "�������";
    }

    [Button("�������� ���")]
    private void ChangeName()
    {
        _ball.name = text.text;
    }
}
