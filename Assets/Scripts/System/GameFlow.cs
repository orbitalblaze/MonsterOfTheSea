using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameFlow : Photon.PunBehaviour, IPunObservable {
	public Dictionary<string, Role> dealedRoles;
	public List<Role> roles;
	public static GameFlow current;

	void Awake()
	{
		current = this;
	}

	// Use this for initialization
	void Start () {
		if (PhotonNetwork.isMasterClient) {
			shuffleRole ();
		}
		CreatePlayer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreatePlayer()
	{
		Player player = PhotonNetwork.Instantiate ("Player", Vector3.zero, Quaternion.identity, 0).GetComponent<Player> ();
		player.name = PhotonNetwork.playerName;
		Role role = GameFlow.current.getRole ();
		player.token = role.token;
		player.color = role.color;
		player.roleName = role.name;
	}

	void shuffleRole()
	{
		dealedRoles = new Dictionary<string, Role> ();
		foreach(PhotonPlayer player in PhotonNetwork.playerList)
		{
			int index = Random.Range(0,roles.Count);
			dealedRoles.Add(player.NickName, roles[index]);
			roles.RemoveAt(index);
		}
	}

	public Role getRole()
	{
		return dealedRoles [PhotonNetwork.playerName];
	}

	 #region IPunObservable implementation
		
	public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(roles);
		}else{
			// Network player, receive data
			this.roles = (List<Role>)stream.ReceiveNext();
		}
	}
	
	#endregion


}
