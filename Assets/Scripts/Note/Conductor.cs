using System;
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
        [SerializeField] GameObject gameOverCanva;

        private void Update()
        {
            if (musicIsPlaying && audioSource.time >= audioSource.clip.length)
            {
                GameOver();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Switch");
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

        private void GameOver()
        {
            //暫停遊戲時間
            Time.timeScale = 0;
            //顯示GameOver面板，並將鼠標顯現出來
            gameOverCanva.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
