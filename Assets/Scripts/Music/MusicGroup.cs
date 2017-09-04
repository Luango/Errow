using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class MusicGroup : MonoBehaviour{
    public List<Transform> MusicNotes;

    public void SwitchPhase()
    {
        foreach (Transform note in MusicNotes)
        {
            note.DORotate(note.eulerAngles + new Vector3(90f, 0f, 0f), 1f);
        }
    }
}
