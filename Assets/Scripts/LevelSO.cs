using UnityEngine;

    [CreateAssetMenu(fileName = "LevelsSO", menuName = "Config/LevelsSO", order = 0)]
    public class LevelsSO : ScriptableObject
    {
        public int[] TimeOnLevel;
        public int[] VictoryPoints;
        public Vector2[] _timeCreate;
        public Vector2[] _timeDestroy;
    }
