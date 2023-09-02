using SoulEater.Data;
using TMPro;
using UnityEngine;

namespace SoulEater.UI
{
    public class BattleCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _soulsText;
        [SerializeField] private GameObject _devConsole;
    
        private void Start()
        {
            _soulsText.text = PlayerPrefsData.GetSoulsCount().ToString();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _devConsole.SetActive(!_devConsole.activeInHierarchy);
            }
        }

        public void UpdateSoulsCount(int soulsCount)
        {
            _soulsText.text = soulsCount.ToString();
        }
    }
}
