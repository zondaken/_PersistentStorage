using PersistentStorage.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace PersistentStorage.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class IncButton : MonoBehaviour
    {
        // Dependencies
        [SerializeField, HideInInspector]
        private Button button;
        
        private SaveManager _saveManager;
        
        private void OnValidate() => TryGetComponent(out button);

        private void Awake()
        {
            _saveManager = SaveManager.Instance;
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (_saveManager.CurrentSaveGame != null)
            {
                _saveManager.CurrentSaveGame.CurrentNumber++;
            }
        }
    }
}