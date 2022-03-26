#nullable enable
using System;
using System.IO;
using UnityEngine;

namespace PersistentStorage.Manager
{
    public class SaveManager : Singleton<SaveManager>
    {
        public SaveGame? CurrentSaveGame { get; private set; }

        public event Action<SaveGame>? SaveLoaded;

        public static string SavesPath => Path.Combine(Application.persistentDataPath, "saves");

        protected override void Awake()
        {
            base.Awake();

            if (!Directory.Exists(SavesPath))
            {
                Directory.CreateDirectory(SavesPath);
            }
        }

        public void Load(int index)
        {
            if (CurrentSaveGame != null)
            {
                CurrentSaveGame.Save();
            }

            CurrentSaveGame = SaveGame.Load(index);

            SaveLoaded?.Invoke(CurrentSaveGame);
        }
    }
}