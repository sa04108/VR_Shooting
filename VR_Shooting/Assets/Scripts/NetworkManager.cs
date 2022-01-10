using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Awake() {
        // MasterClient�� PhotonNetwork.LoadLevel()�� ���� ���� ��ȯ�ϸ�, ���� �뿡 �ִ� �ٸ� �ο��鵵 ���� ���� ������ �̵������� ���ϴ� ����
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start() {
        Connect();
    }

    void Connect() {
        // �̹� ����� ���¶��(�������� ����� ��쵵 ����)
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.JoinRandomRoom(); // ������ �뿡 ����
        else {
            PhotonNetwork.ConnectUsingSettings(); // ���� ����
        }
    }

    #region PUN Callbacks
    // ������ ���� �� ���� ȣ��Ǵ� �Լ�
    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        // �̸��� null��, �ִ� �÷��̾� ���� 2���� ���� ����
        Debug.LogWarning("PhotonNetwork Error " + returnCode + ": " + message);
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
        Debug.Log("PhotonNetwork: Create New Room");
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.Instantiate("Controller", Vector3.zero, Quaternion.identity);
    }

    #endregion
}
