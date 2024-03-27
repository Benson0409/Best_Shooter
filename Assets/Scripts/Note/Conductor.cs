using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RhythmGame
{
    public class Conductor : MonoBehaviour
    {
        public float SongPositionTime => audioSource.time;
        //此種的寫法簡略
        //public float v()
        //{
        //    return audioSource.time;

        //}

        [SerializeField] private AudioSource audioSource = null;
        [SerializeField] private Slider slider;
        public bool musicIsPlaying = false;

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!musicIsPlaying)
                {
                    PlayMusic();
                    musicIsPlaying = !musicIsPlaying;
                }
                else
                {
                    PauseMusic();
                    musicIsPlaying = !musicIsPlaying;
                }
            }

            if (audioSource.isPlaying)
            {
                float songProgress = audioSource.time / audioSource.clip.length;
                slider.value = songProgress;
            }
        }

        public void PlayMusic()
        {
            audioSource.Play();
        }

        public void PauseMusic()
        {
            audioSource.Pause();
        }
    }
}
