using SoulEater.UI;
using SoulEater.Data;
using UnityEngine;

namespace SoulEater.Logic
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private BattleCanvas _battleCanvas;
        private PlayerData _playerData;

        private void Start()
        {
            if (_battleCanvas == null)
            {
                _battleCanvas = FindObjectOfType<BattleCanvas>();
            }

            _playerData = new PlayerData(PlayerPrefsData.GetSoulsCount());
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Soul")
            {
                _playerData.SoulsCount++;
                other.gameObject.SetActive(false);
                
                //ui
                _battleCanvas.UpdateSoulsCount(_playerData.SoulsCount);
                
                PlayerPrefsData.SetSoulsCount(_playerData.SoulsCount);
            }
        }
    }
}