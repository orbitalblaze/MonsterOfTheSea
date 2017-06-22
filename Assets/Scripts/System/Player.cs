using UnityEngine;
using System.Collections;

public class Player : Photon.PunBehaviour, IPunObservable{

	public Color color;
	public Token token;
	public string name;
	public string roleName;

	public void Awake()
	{
	}

	#region IPunObservable implementation

	public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(name);
			stream.SendNext(token);
			stream.SendNext(color);
			stream.SendNext(roleName);

		}else{
			// Network player, receive data
			this.name = (string)stream.ReceiveNext();
			this.token = (Token)stream.ReceiveNext();
			this.color = (Color)stream.ReceiveNext();
			this.roleName = (string)stream.ReceiveNext();
		}
	}

	#endregion
}
