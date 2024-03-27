using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmGame
{

    public class NoteController : MonoBehaviour
    {
        //用來新增NoteData 的資料
        public NoteData noteData = null;
        public Conductor conductor;
        public DataManager dataManager;

        private void Update()
        {
            //紀錄每一個節點出現的時間
            if (Input.GetKeyDown(KeyCode.Q))
            {
                noteData.trackData.Add(conductor.SongPositionTime);
            }
        }
    }
}
