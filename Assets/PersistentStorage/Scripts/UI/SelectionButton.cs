#nullable enable
using System;
using JetBrains.Annotations;
using PersistentStorage.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PersistentStorage.UI
{
    public interface ISelectionButton
    {
        public void Init(int index); // normalized index [0,n-1]
    }
    
    [RequireComponent(typeof(Button))]
    public class SelectionButton : MonoBehaviour, ISelectionButton
    {
        // Dependencies
        [SerializeField, HideInInspector]
        private TextMeshProUGUI text;
        
        [SerializeField, HideInInspector]
        private Button button;
        
        private int _index;
        private SaveManager _saveManager;

        private void OnValidate()
        {
            button = GetComponent<Button>();
            text = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Awake()
        {
            _saveManager = SaveManager.Instance!; // [NRE] avoided by SEO
            button.onClick.AddListener(OnClick);
        }

        public void Init(int index)
        {
            _index = index;
            text.text = (index + 1).ToString();
        }
        
        private void OnClick()
        {
            _saveManager.Load(_index);
        }
    }
}