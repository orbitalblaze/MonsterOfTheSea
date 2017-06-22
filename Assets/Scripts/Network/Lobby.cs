using UnityEngine;


public class Lobby : Photon.PunBehaviour
{
	#region Public Variables
	/// <summary>
	/// The PUN loglevel. 
	/// </summary>
	public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;

	/// <summary>
	/// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
	/// </summary>   
	[Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
	public byte MaxPlayersPerRoom = 4;
	TypedLobby defaultLobby;
	public PhotonPlayer[] playersInRoom;
	public ListPlayers displayPlayers;
		
		
	#endregion
		
		
	#region Private Variables
		
		
	/// <summary>
	/// This client's version number. Users are separated from each other by gameversion (which allows you to make breaking changes).
	/// </summary>
	string _gameVersion = "0.1";
		
		
	#endregion
		
		
	#region MonoBehaviour CallBacks
		
		
	/// <summary>
	/// MonoBehaviour method called on GameObject by Unity during early initialization phase.
	/// </summary>
	void Awake()
	{

		// #NotImportant
		// Force LogLevel
		PhotonNetwork.logLevel = Loglevel;

		// #Critical
		// we don't join the lobby. There is no need to join a lobby to get the list of rooms.
		PhotonNetwork.autoJoinLobby = false;
			
			
		// #Critical
		// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
		PhotonNetwork.automaticallySyncScene = true;
	}

	void Start()
	{
		Connect ();
	}

	void Update()
	{
		if(PhotonNetwork.isMasterClient && PhotonNetwork.room.PlayerCount == PhotonNetwork.room.MaxPlayers)
		{
			print ("lel");
			LetUsStartTheGame();
		}
	}
			
	#endregion
		
		
	#region Public Methods

	/// <summary>
	/// Start the connection process. 
	/// - If already connected, we attempt joining a random room
	/// - if not yet connected, Connect this application instance to Photon Cloud Network
	/// </summary>
	public void Connect()
	{
		// we check if we are connected or not, we join if we are , else we initiate the connection to the server.
		if (!PhotonNetwork.connected)
		{
			// #Critical, we must first and foremost connect to Photon Online Server.
			PhotonNetwork.ConnectUsingSettings(_gameVersion);
		}
	}


	#endregion

	#region Photon.PunBehaviour CallBacks
		
		
	public override void OnConnectedToMaster()
	{
		Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
			
	}

	public void JoinRoom()
	{
		PhotonNetwork.JoinRandomRoom();
	}
		
			
	public override void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");        
	}

	public void CreateRoom()
	{
		Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
		// #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
		PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
	}
		
	public override void OnJoinedRoom()
	{
		ListPlayers ();
		Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
	}

	public override void OnPhotonRandomJoinFailed (object[] codeAndMsg)
	{
		Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
		
		// #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
		PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
	}

	public override void OnPhotonPlayerConnected( PhotonPlayer other)
	{
		ListPlayers ();
		Debug.Log( "OnPhotonPlayerConnected() " + other.name ); // not seen if you're the player connecting
	}

	public override void OnPhotonPlayerDisconnected( PhotonPlayer other)
	{
		ListPlayers ();
		Debug.Log( "OnPhotonPlayerConnected() " + other.name ); // not seen if you're the player connecting
	}
	
	public void ListPlayers()
	{
		playersInRoom = PhotonNetwork.playerList;
		displayPlayers.showPlayers (playersInRoom);
	}

	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
	}

	private void LetUsStartTheGame(){
		PhotonNetwork.LoadLevel("Net - Game");
	}

		
	#endregion
		
}