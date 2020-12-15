using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ConnectRoom : MonoBehaviourPunCallbacks
{
    private int multiplayerSceneIndex = 1;
    private static string roomName = "gamers";

    // All fields that are required to Join the proper room
    [SerializeField]
    Button joinButton;

    [SerializeField]
    private int RoomSize;

    // Creating a new instance of this script
    public static ConnectRoom m_Instance = null;
    public static ConnectRoom connectRoom
    {
        get
        {
            if (m_Instance == null)
                m_Instance = (ConnectRoom)FindObjectOfType(typeof(ConnectRoom));
            return m_Instance;
        }
    }

    // This is called when the script is initially opened, before any frames
    private void Awake()
    {
        m_Instance = this;
        Connect();
    }

    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // TODO:
    // Edit this method to allow user to select a private lobby.
    public void setPrivateLobby(string privateLobby)
    {
        roomName = privateLobby;
    }

    // This is called when connecting to the base server
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("Joined master server");
    }

    public void joinRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
        Debug.Log("Joined room: " + roomName);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("FAILED TO JOIN ROOM: " + roomName + "\nCreating new room.");
        CreateRoom();
    }

    // Create a new room rather than join. Called on failure to join
    private void CreateRoom()
    {
        Debug.Log("Creating a new room: " + roomName);

        // There is documentation on RoomOptions below, they are necessary for creating a new room.
        // https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_realtime_1_1_room_options.html
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };

        PhotonNetwork.CreateRoom(roomName, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room: " + roomName + "\nTrying again.");
        roomName = roomName + "1";
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        StartGame();
    }

    private void StartGame()
    {
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }


}