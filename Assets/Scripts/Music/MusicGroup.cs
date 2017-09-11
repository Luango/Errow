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
        if (MusicManager.Pause == false)
        {
            float buttonRotateAngle = GameObject.Find("MusicManager").GetComponent<MusicManager>().buttonRotation;
            MusicManager.Pause = true;
            foreach (Transform note in MusicNotes)
            {
                var rotation = note.rotation;
                rotation *= Quaternion.Euler(0, buttonRotateAngle, 0);
                note.DORotate(rotation.eulerAngles, 0.8f).OnComplete(() => MusicManager.Pause = false);
            }
        }
    }
}
