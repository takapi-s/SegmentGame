using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class SampleScene : MonoBehaviourPunCallbacks
{

    [SerializeField]
    public GameObject Panel;
    public InputField inputField;

    private void Start()
    {
        //inputField = GetComponent<InputField>();
    }

    public void InputText()
    {
        if (inputField == null || string.IsNullOrEmpty(inputField.text))
        {

            Debug.Log("null");
            return;
        }
        PhotonNetwork.NickName = inputField.text;

        PhotonNetwork.ConnectUsingSettings();
        Panel.SetActive(false);
      
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom()
    {
        //roomに入ったときに実行される
        //人数を確認する
        //2人以上ならゲーム開始ボタンを有効にする

    }
}