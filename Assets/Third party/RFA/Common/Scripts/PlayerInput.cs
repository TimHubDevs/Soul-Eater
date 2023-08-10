using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Retro.ThirdPersonCharacter
{
    public class PlayerInput : MonoBehaviour
    {
        public int souls;
        public TextMeshProUGUI SoulsText;

        private bool _attackInput;
        private bool _specialAttackInput;
        private Vector2 _movementInput;
        private bool _jumpInput;
        private bool _changeCameraModeInput;

        public bool AttackInput {get => _attackInput;}
        public bool SpecialAttackInput {get => _specialAttackInput;}
        public Vector2 MovementInput {get => _movementInput;}
        public bool JumpInput { get => _jumpInput; }
        public bool ChangeCameraModeInput {get => _changeCameraModeInput;}

        private void Start()
        {
            if (PlayerPrefs.HasKey("Souls"))
            {
                souls = PlayerPrefs.GetInt("Souls");
                SoulsText.text = souls.ToString();
            }
        }

        private void Update()
        {
            _attackInput = Input.GetMouseButtonDown(0);
            _specialAttackInput = Input.GetMouseButtonDown(1);

            _movementInput.Set(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
            _jumpInput = Input.GetButton("Jump");
            _changeCameraModeInput = Input.GetKeyDown(KeyCode.F);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Soul")
            {
                souls++;
                other.gameObject.SetActive(false);
                SoulsText.text = souls.ToString();
                PlayerPrefs.SetInt("Souls", souls);
            }
        }
    }
}