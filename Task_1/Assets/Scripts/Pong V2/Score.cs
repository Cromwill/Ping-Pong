using UnityEngine;

namespace PongV2
{
    public class Score
    {
        private int _scorre;

        public System.Action<int> OnScorreChange, OnScorreAdd, OnScorreReduce;

        public int GetScore => _scorre;

        public void AddScorre(int value)
        {
            _scorre ++;
            OnScorreAdd?.Invoke(_scorre);
        }

        public void ReduceScorre(int value)
        {
            OnScorreReduce?.Invoke(_scorre);
        }
    }
}