using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PongV2
{
    public class ScoreDrawer : MonoBehaviour
    {
        private Text ScoreText;

        private void Start()
        {
            ScoreText = GetComponent<Text>();
        }

        public void ChangeScore(int value)
        {
            if(ScoreText == null) ScoreText = GetComponent<Text>();

            ScoreText.text = "Scorre: " + value;
        }
    }
}
