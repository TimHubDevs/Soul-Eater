using SoulEater.Data;
using TMPro;
using UnityEngine;

namespace SoulEater.UI
{
    public class BattleCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _soulsText;
    
        private void Start()
        {
            _soulsText.text = PlayerPrefsData.GetSoulsCount().ToString();
        }

        public void UpdateSoulsCount(int soulsCount)
        {
            _soulsText.text = soulsCount.ToString();
        }
    }
}
