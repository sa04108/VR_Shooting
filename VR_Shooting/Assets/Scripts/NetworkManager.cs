using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Awake() {
        // MasterClient가 PhotonNetwork.LoadLevel()을 통해 씬을 전환하면, 같은 룸에 있는 다른 인원들도 같이 같은 씬으로 이동할지를 정하는 변수
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start() {
        Connect();
    }

    void Connect() {
        // 이미 연결된 상태라면(오프라인 모드인 경우도 포함)
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.JoinRandomRoom(); // 무작위 룸에 참가
        else {
            PhotonNetwork.ConnectUsingSettings(); // 새로 연결
        }
    }

    #region PUN Callbacks
    // 서버에 연결 된 직후 호출되는 함수
    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        // 이름이 null인, 최대 플레이어 수가 2명인 룸을 생성
        Debug.LogWarning("PhotonNetwork Error " + returnCode + ": " + message);
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
        Debug.Log("PhotonNetwork: Create New Room");
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.Instantiate("Controller", Vector3.zero, Quaternion.identity);
    }

    #endregion
}
