using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RhythmGame
{

    public class PlayerController : MonoBehaviour
    {
        public TMP_Text scoreText;
        public Conductor conductor;
        public NoteSpawner noteSpawner;
        private int score = 0;

        void Update()
        {
            scoreText.text = score.ToString();
        }

        public void HitNote(GameObject obj)
        {
            Note note = obj.GetComponent<Note>();
            if (conductor.SongPositionTime - note.time < 0.4f)
            {
                print("Great");
                score += 5;
            }
            else if (conductor.SongPositionTime - note.time < 0.7f)
            {
                print("Good");
                score += 3;
            }
            else
            {
                print("none");
                score += 1;
            }
            Destroy(obj);
        }

    }
}
