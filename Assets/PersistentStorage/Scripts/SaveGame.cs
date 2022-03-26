#nullable enable
using System;
using System.IO;
using JetBrains.Annotations;
using PersistentStorage.Manager;
using UnityEngine;

namespace PersistentStorage
{
    [Serializable]
    public class SaveGame
    {
        [SerializeField] private int index;
        [SerializeField] private int currentNumber;

        public int Index
        {
            get => index;
            set => index = value;
        }

        public int CurrentNumber
        {
            get => currentNumber;
            
            set
            {
                currentNumber = value;
                CurrentNumberChanged?.Invoke(this, value);
            }
        }

        public static event Action<SaveGame, int>? CurrentNumberChanged;

        private static string GetPath(int index) => Path.Combine(SaveManager.SavesPath, "Save000" + index + ".json");
        
        public static SaveGame Load(int index)
        {
            string path = GetPath(index);

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                var saveGame = JsonUtility.FromJson<SaveGame>(json);
                Debug.Log($"Loaded from {path}");

                return saveGame;
            }
            else
            {
                return new SaveGame {Index = index, CurrentNumber = 0};
            }
        }

        public void Save()
        {
            string path = GetPath(Index);
            string json = JsonUtility.ToJson(this, prettyPrint: true);
            
            File.WriteAllText(path, json);

            Debug.Log($"Saved to {path}");
        }
    }
}