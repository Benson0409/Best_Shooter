using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


namespace RhythmGame
{

    public class Note : MonoBehaviour
    {
        public float time;
        public float speed;

        public Conductor conductor = null;
        //他會全部生成，要想辦法讓他音樂下之後再開始判斷是否要顯示

        void Update()
        {

            //更改layer的層級
            if (conductor.musicIsPlaying)
            {
                if (math.abs(conductor.SongPositionTime - time) < 0.5)
                {
                    gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
                    gameObject.layer = LayerMask.NameToLayer("Default");
                }

            }

            if (time - conductor.SongPositionTime <= -1.5)
            {
                Destroy(gameObject);
            }
        }
    }
}
