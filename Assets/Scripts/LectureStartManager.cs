using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LectureStartManager : MonoBehaviour
{

    public GameObject StudentUI;
    public GameObject SuperviseUI;

    //public GameObject playerUI1;
    //public GameObject playerUI2;

    //public GameObject teacherUI1;
    //public GameObject teacherUI2;

    public void ActivateUI()
   {
        

        // 카메라 정면에 UI 활성화 시키기
        // 위치값
        
         
        Transform cameraTransform = Camera.main.transform;
        Vector3 cameraForward = cameraTransform.forward;
        float distance = 2f;
        Vector3 uiPosition = cameraTransform.position + cameraForward * distance;

        // 회전값
        Quaternion uiRotation = Quaternion.LookRotation(cameraForward);

        if (PhotonNetwork.NickName == "Supervisor")
        {
            Instantiate(StudentUI, uiPosition, uiRotation);
            /*teacherUI1.transform.position = uiPosition;
            teacherUI1.transform.rotation = uiRotation;
            teacherUI1.SetActive(true);

            teacherUI2.transform.position = uiPosition;
            teacherUI2.transform.rotation = uiRotation;
            teacherUI2.SetActive(true);
            */
        }
        else
        {
            Instantiate(SuperviseUI, uiPosition, uiRotation);
            /*
            playerUI1.transform.position = uiPosition;
            playerUI1.transform.rotation = uiRotation;
            playerUI1.SetActive(true);

            playerUI2.transform.position = uiPosition;
            playerUI2.transform.rotation = uiRotation;
            playerUI2.SetActive(true);
            */
        }
        
    }

    public void ResetScene() 
    {
        // 포톤 서버 연결 끊기
        PhotonNetwork.Disconnect();
        // 씬 리로드
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        
}
