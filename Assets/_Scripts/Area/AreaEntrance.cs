using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugManager;

public class AreaEntrance : MonoBehaviour
{
    [SerializeField] private string transitionName;

    private void Start()
    {
        if (transitionName == SceneManagement.Instance.SceneTransitionName)
        {
            PlayerControl.Instance.transform.position = this.transform.position;
            CameraController.Instance.SetPlayerCameraFolow();
           UIFade.Instance.FadeToClear();
        }
    }
}
