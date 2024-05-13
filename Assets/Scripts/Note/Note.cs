using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RhythmGame
{

    public class Note : MonoBehaviour
    {
        public float time;
        public float speed;

        bool startedShowing = false;

        public Conductor conductor = null;
        //他會全部生成，要想辦法讓他音樂下之後再開始判斷是否要顯示

        void Update()
        {

            //更改layer的層級
            if (conductor.musicIsPlaying)
            {
                if ((time - conductor.SongPositionTime) < 1f)
                {
                    float fadeAmount = (time - conductor.SongPositionTime);
                    Color color = gameObject.GetComponent<MeshRenderer>().material.color;
                    color = Color.Lerp(Color.red, Color.blue, fadeAmount);
                    gameObject.GetComponent<MeshRenderer>().material.color = color;

                    gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
                    gameObject.transform.GetChild(0).gameObject.tag = "Note";
                    gameObject.layer = LayerMask.NameToLayer("Default");
                    gameObject.tag = "Note";
                }

            }

            if (time - conductor.SongPositionTime <= -0.5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
