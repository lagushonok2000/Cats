using UnityEngine;

public class HolesShuffle : MonoBehaviour
{
    [SerializeField] public CreateCats _objectsClass;

    public void Shuffle()
    {
        System.Random random = new System.Random();
        for (int i = _objectsClass.Holes.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            var temp = _objectsClass.Holes[j];
            _objectsClass.Holes[j] = _objectsClass.Holes[i];
            _objectsClass.Holes[i] = temp;
        }
    }
}
