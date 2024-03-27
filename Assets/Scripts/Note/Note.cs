using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RhythmGame
{


    public class Note : MonoBehaviour
    {
        public float time;
        public float speed;

        public Conductor conductor = null;

        void Update()
        {


            if (time - conductor.SongPositionTime <= -5)
            {
                Destroy(gameObject);
            }
        }
    }
}
