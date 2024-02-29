using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class RoomView : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TextMeshProUGUI roomname;

    [SerializeField]
    private List<TextMeshProUGUI> playerTexts; // プレイヤーのテキストをリストで管理
    private List<Player> playersInRoom = new List<Player>(); // ルーム内のプレイヤーリスト
    public GameObject RoomViewer;
    public GameObject MatchmakingViewer;
    public Button startbutton;



    private void Start()
    {
        startbutton.interactable = false;
        roomname.text = "---";
        foreach (var playerText in playerTexts)
        {
            playerText.text = "nan";
        }
    }


    public void InactivateRoomView()//ゲーム開始ボタン
    {
        RoomViewer.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        roomname.text = PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName}が参加しました");
        UpdatePlayerList();
    }

    // 他プレイヤーがルームから退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"{otherPlayer.NickName}が退出しました");
        UpdatePlayerList();
    }
    private void UpdatePlayerList()
    {
        playersInRoom.Clear(); // プレイヤーリストをクリアしてから更新

        foreach (var player in PhotonNetwork.PlayerList)
        {
            playersInRoom.Add(player);
        }


        // プレイヤーテキストを更新
        for (int i = 0; i < playerTexts.Count; i++)
        {
            if (i < playersInRoom.Count)
            {
                playerTexts[i].text = $"player{i}: {playersInRoom[i].NickName}";
            }
            else
            {
                playerTexts[i].text = $"player{i}: nan";
            }
        }

        //二人以上のときはゲーム開始可能になる
        //開始ボタンはmasterクライアントのみ押せるようにする
        if (playersInRoom.Count >= 2 && PhotonNetwork.IsMasterClient)
        {
            startbutton.interactable = true; 
        }
        else
        {
            startbutton.interactable = false;
        }

    }



    public void RoomExit()//退出ボタン
    {
        PhotonNetwork.LeaveRoom();
        MatchmakingViewer.SetActive(true);

    }
}
