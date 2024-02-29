using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MatchmakingView : MonoBehaviourPunCallbacks
{
    private RoomList roomList = new RoomList();
    private List<RoomButton> roomButtonList = new List<RoomButton>();
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        // ロビーに参加するまでは、全てのルーム参加ボタンを押せないようにする
        canvasGroup.interactable = false;

        // 全てのルーム参加ボタンを初期化する
        int roomId = 1;
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<RoomButton>(out var roomButton))
            {
                roomButton.Init(this, roomId++);
                roomButtonList.Add(roomButton);
            }
        }
    }

    public override void OnJoinedLobby()
    {
        // ロビーに参加したら、ルーム参加ボタンを押せるようにする
        canvasGroup.interactable = true;
    }

    public override void OnRoomListUpdate(List<RoomInfo> changedRoomList)
    {
        roomList.Update(changedRoomList);

        // 全てのルーム参加ボタンの表示を更新する
        foreach (var roomButton in roomButtonList)
        {
            if (roomList.TryGetRoomInfo(roomButton.RoomName, out var roomInfo))
            {
                roomButton.SetPlayerCount(roomInfo.PlayerCount);
            }
            else
            {
                roomButton.SetPlayerCount(0);
            }
        }
    }

    public void OnJoiningRoom()
    {
        // ルーム参加処理中は、全てのルーム参加ボタンを押せないようにする
        canvasGroup.interactable = false;
    }

    public override void OnJoinedRoom()
    {
        // ルームへの参加が成功したら、UIを非表示にする
        gameObject.SetActive(false);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ルームへの参加が失敗したら、再びルーム参加ボタンを押せるようにする
        canvasGroup.interactable = true;
    }
}