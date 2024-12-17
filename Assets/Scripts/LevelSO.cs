using UnityEngine;

    [CreateAssetMenu(fileName = "LevelsSO", menuName = "Config/LevelsSO", order = 0)]
    public class LevelsSO : ScriptableObject
    {
        public int[] TimeOnLevel;
        public int[] VictoryPoints;
        public float[] TimeCreate;
        public float[] TimeDestroy;
        public float SpendTime;
        public int DefaultCatscounter;
    }
