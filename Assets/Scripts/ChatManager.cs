using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ChatManager : MonoBehaviourPunCallbacks
{
    public GameObject m_Content;
    public GameObject m_ActionButton;
    public TextMeshProUGUI outputText;
    PhotonView photonview;

    GameObject m_ActionButton_Frontplate;
    GameObject m_Frontplate_AnimatedContent;
    GameObject m_AnimatedContent_Text;

    string m_strUserName;


    void Start()
    {
        Screen.SetResolution(960, 600, false);
        PhotonNetwork.ConnectUsingSettings();
        m_ActionButton_Frontplate = m_ActionButton.transform.GetChild(2).gameObject;
        m_Frontplate_AnimatedContent = m_ActionButton_Frontplate.transform.GetChild(0).gameObject;
        m_AnimatedContent_Text = m_Frontplate_AnimatedContent.transform.GetChild(1).gameObject;

        photonview = GetComponent<PhotonView>();
        m_strUserName = PhotonNetwork.LocalPlayer.NickName;
    }

    // 포톤 서버룸 조인시 채팅창에 connect user 로그 띄우기
    public override void OnJoinedRoom()
    {
        m_strUserName = PhotonNetwork.LocalPlayer.NickName;
        AddChatMessage("connect user : " + PhotonNetwork.LocalPlayer.NickName);
    }

    // 채팅 추가
    void AddChatMessage(string message)
    {
        GameObject goText = Instantiate(m_ActionButton, m_Content.transform);

        m_ActionButton_Frontplate = goText.transform.GetChild(2).gameObject;
        m_Frontplate_AnimatedContent = m_ActionButton_Frontplate.transform.GetChild(0).gameObject;
        m_AnimatedContent_Text = m_Frontplate_AnimatedContent.transform.GetChild(1).gameObject;

        m_AnimatedContent_Text.GetComponent<TextMeshProUGUI>().text = message;
    }

    // 채팅창 내용 전송하기
    public void SetInputReturn()
    {
        string strMessage = m_strUserName + " : " + outputText.text;
        photonview.RPC("RPC_Chat", RpcTarget.All, strMessage);
        Debug.Log("connect user : " + PhotonNetwork.LocalPlayer.NickName);
    }

    [PunRPC]
    void RPC_Chat(string message)
    {
        Debug.Log("RPC_Chat : " + message);
        AddChatMessage(message);
    }

}