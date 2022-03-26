using PersistentStorage.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace PersistentStorage.UI
{
    public class SaveButton : MonoBehaviour
    {
        // Dependencies
        [SerializeField, HideInInspector] private Button m_Button;
        
        private SaveManager _saveManager;

        private void OnValidate() => TryGetComponent(out m_Button);

        private void Awake()
        {
            _saveManager = SaveManager.Instance!; // [NRE] avoided by SEO
            m_Button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _saveManager.CurrentSaveGame?.Save();
        }
    }
}