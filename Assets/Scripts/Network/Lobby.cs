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

		defaultLobby = new TypedLobby ("m", LobbyType.Default);
		// #NotImportant
		// Force LogLevel
		PhotonNetwork.logLevel = Loglevel;

		// #Critical
		// we don't join the lobby. There is no need to join a lobby to get the list of rooms.
		PhotonNetwork.autoJoinLobby = true;
			
			
		// #Critical
		// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
		PhotonNetwork.automaticallySyncScene = true;
	}

	void Start()
	{
		Connect ();
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

	public RoomInfo[] GetRoomList()
	{
		/*RoomInfo[] rooms = PhotonNetwork.GetRoomList ();
		print("Rooms available");
		print (rooms.Length);
		foreach(RoomInfo room in rooms){

			print (room.Name);
		}
		return PhotonNetwork.GetRoomList();*/
		RoomInfo[] rooms = new RoomInfo[3];
		rooms[0] = new RoomInfo ("Lo", new ExitGames.Client.Photon.Hashtable());
		rooms[1] = new RoomInfo ("Lol", new ExitGames.Client.Photon.Hashtable());
		rooms[2] = new RoomInfo ("Lolo", new ExitGames.Client.Photon.Hashtable());
		return rooms;
	}
		
			
	public override void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");        
	}

	public void CreateRoom()
	{
		Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
		// #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
		PhotonNetwork.CreateRoom(Random.Range(0,25555).ToString(), new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, defaultLobby);
	}
		
	public override void OnJoinedRoom()
	{
		Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
		GetRoomList ();
	}
		
		
	#endregion
		
}