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
                //生成位置用物體的範圍的隨機位置
                // 在範圍內隨機選擇一個位置
                Vector3 spawnPosition = new Vector3(Random.Range(-9f, 9f), Random.Range(0.2f, 6f), 1.9f);

                // 生成音符並指定位置和旋轉
                Note note = Instantiate(notePrefab, spawnPosition, Quaternion.identity);
                note.transform.rotation = Quaternion.Euler(270f, 0f, 0f);
                note.time = f;
                note.conductor = conductor;
                playerController.conductor = conductor;
            }

        }


    }
}
