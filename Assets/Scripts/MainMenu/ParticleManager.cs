using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _freeAllCats;

    public void Particle()
    {
        _freeAllCats.Play();
    }
}
