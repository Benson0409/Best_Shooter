using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using TMPro;

namespace RhythmGame
{

    public class PlayerController : MonoBehaviour
    {
        public TMP_Text scoreText;
        public Conductor conductor;
        public NoteSpawner noteSpawner;
        private int score = 0;

        public GameObject perfectNote;
        public GameObject greatNote;
        public GameObject goodNote;

        void Update()
        {
            scoreText.text = score.ToString();
        }

        public void HitNote(GameObject obj)
        {
            Note note = obj.GetComponent<Note>();

            if (math.abs(conductor.SongPositionTime - note.time) < 0.2f)
            {
                print(conductor.SongPositionTime - note.time);
                print("Perfect!!");
                score += 5;

                Instantiate(perfectNote, note.GetComponent<Transform>().position, Quaternion.identity);
            }
            else if (math.abs(conductor.SongPositionTime - note.time) < 0.4f)
            {
                print(conductor.SongPositionTime - note.time);
                print("Great!");
                score += 3;

                Instantiate(greatNote, note.GetComponent<Transform>().position, Quaternion.identity);
            }
            else
            {
                print(conductor.SongPositionTime - note.time);
                print("Good");
                score += 1;

                Instantiate(goodNote, note.GetComponent<Transform>().position, Quaternion.identity);
            }
            Destroy(obj);
        }

    }
}
