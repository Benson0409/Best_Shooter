using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmGame
{
    [System.Serializable]
    public class NoteData
    {
        //除存節點出現的時間，後面可以增加次數
        public List<float> trackData = new List<float>();
    }
}
