#nullable enable
using TMPro;
using UnityEngine;

namespace PersistentStorage.Manager
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private TextMeshProUGUI? currentNumberText;
        [SerializeField, HideInInspector] private SaveManager? saveManager;

        protected override void Awake()
        {
            base.Awake();

            SaveGame.CurrentNumberChanged += OnCurrentNumberChanged;
            
            saveManager = SaveManager.Instance;
            saveManager!.SaveLoaded += OnSaveLoaded; // [NRE] is fine because of SEO
        }

        private void OnSaveLoaded(SaveGame saveGame)
        {
            currentNumberText.text = saveGame.CurrentNumber.ToString();
        }

        private void OnCurrentNumberChanged(SaveGame saveGame, int newNumber)
        {
            currentNumberText.text = newNumber.ToString();
        }
    }
}
