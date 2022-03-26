using System;
using PersistentStorage.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace PersistentStorage
{
    public class SelectorGeneration : MonoBehaviour
    {
        [SerializeField] private SelectionButton m_SelectionButtonPrefab;

        private void Start()
        {
            Vector3 rawPosition = transform.position;
            Vector3 offset = Vector3.down * 2f;

            for (int i = 0; i < 5; i++, rawPosition += offset)
            {
                var selectionButton = Instantiate(m_SelectionButtonPrefab, rawPosition, Quaternion.identity, transform);
                selectionButton.Init(i); // don't transmit i+1 because of D in SOLID

                string index = i.ToString();
                Console.WriteLine((int.Parse(index) - 1).ToString());
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Vector3 rawPosition = transform.position;
            Vector3 size = new Vector3(2, 1, 1);

            for (int i = 0; i < 5; i++)
            {
                Vector3 position = new Vector3();
                position.x = rawPosition.x + size.x / 2f;
                position.y = rawPosition.x - size.x / 2f;
                position.z = 1;

                Gizmos.DrawCube(rawPosition, size);

                rawPosition += Vector3.down * 2f;
            }
        }
    }
}
