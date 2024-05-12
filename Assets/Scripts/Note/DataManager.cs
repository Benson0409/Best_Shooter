using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace RhythmGame
{

    public class DataManager : MonoBehaviour
    {
        [SerializeField] private NoteSpawner noteSpawner = null;
        [SerializeField] private NoteController noteController = null;

        [SerializeField] private string savePath = null;
        [SerializeField] private string fileName = null;

        [ContextMenu("Save Note Data")]
        public void SaveNoteData()
        {
            string path = Path.Combine(savePath, fileName);

            string json = JsonUtility.ToJson(noteController.noteData, true);
            File.WriteAllText(path, json);
        }

        [ContextMenu("Load Note Data")]
        public void LoadNoteData()
        {
            string path = Path.Combine(savePath, fileName);

            string loadData = File.ReadAllText(path);
            NoteData noteData = JsonUtility.FromJson<NoteData>(loadData);
            noteSpawner.noteData = noteData;
        }

        public void changeFileName(string inputFileName)
        {
            fileName = inputFileName;
        }
    }
}
