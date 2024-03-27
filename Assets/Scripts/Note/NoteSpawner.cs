using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmGame
{
    public class NoteSpawner : MonoBehaviour
    {
        [SerializeField] private Conductor conductor = null;

        [SerializeField] private Note notePrefab = null;
        [SerializeField] private PlayerController playerController = null;

        [SerializeField] private Transform range = null;





        public NoteData noteData = null;

        private void Awake()
        {
            SpawnAllNotes();

        }

        //讓節點隨者音樂來進行生成
        public void SpawnAllNotes()
        {
            foreach (float f in noteData.trackData)
            {

                // 獲取物體的尺寸
                float objectWidth = range.position.x;
                float objectHeight = range.position.y;
                float objectDepth = range.position.z;

                // 根據物體的尺寸定義生成範圍的大小
                Vector3 spawnRange = new Vector3(objectWidth * 2, objectHeight * 2, objectDepth * 2);

                // 在範圍內隨機選擇一個位置
                Vector3 spawnPosition = transform.position + new Vector3(
                    Random.Range(-spawnRange.x / 2, spawnRange.x / 2),
                 Random.Range(-spawnRange.y / 2, spawnRange.y / 2),
                    Random.Range(-spawnRange.z / 2, spawnRange.z / 2)
                );
                //生成位置用物體的範圍的隨機位置
                Note note = Instantiate(notePrefab, spawnPosition, Quaternion.identity);
                note.time = f;
                note.conductor = conductor;
                playerController.conductor = conductor;
            }


        }
    }
}
