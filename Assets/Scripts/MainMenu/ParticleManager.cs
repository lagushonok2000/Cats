using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _freeAllCats;
    [SerializeField] private FreeCats _freeCats;

    private void Start()
    {
        _freeCats.End += Particle;
    }

    private void Particle()
    {
        _freeAllCats.Play();
    }
}
