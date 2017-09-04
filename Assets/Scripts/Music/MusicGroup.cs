using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class MusicGroup : MonoBehaviour{
    public List<Transform> MusicNotes;
    public float orientationOffset;

    public void SwitchPhase()
    {
        MusicManager.Pause = true;
        foreach (Transform note in MusicNotes)
        {
            note.DORotate(note.eulerAngles + new Vector3(90f, 0f, 0f), 0.8f).OnComplete(() => MusicManager.Pause = false);
        }
    }
}
