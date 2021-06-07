using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;



public class SocketIn : MonoBehaviour
{
	#region private members 	
	private TcpClient socketConnection;
	private Thread clientReceiveThread;
	#endregion
	// Use this for initialization 	
	public string pos;

	public string joint1;
	public string joint2;
	public string joint3;
	public string joint4;
	public string joint5;
	public string joint6;
	public string joint7;

	void Start()
	{
		ConnectToTcpServer();
	}
	// Update is called once per frame
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.Space))
		//{
		//	SendMessage(modeToSend.mode.ToString());
		//}
	}
	/// <summary> 	
	/// Setup socket connection. 	
	/// </summary> 	
	private void ConnectToTcpServer()
	{
		try
		{
			clientReceiveThread = new Thread(new ThreadStart(ListenForData));
			clientReceiveThread.IsBackground = true;
			clientReceiveThread.Start();
		}
		catch (Exception e)
		{
			Debug.Log("On client connect exception " + e);
		}
	}
	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>    
	/// 




	public void ListenForData()
	{
		try
		{
			socketConnection = new TcpClient("192.168.1.105", 8045);
			Byte[] bytes = new Byte[1024];
			while (true)
			{
				// Get a stream object for reading 				
				using (NetworkStream stream = socketConnection.GetStream())
				{
					int length = 0;

                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        // Convert byte array to string message. 						
                        string serverMessage = Encoding.ASCII.GetString(incommingData);
                        //dynamic data1 = JsonConvert.DeserializeObject(serverMessage);
                        //string numbers = serverMessage;
                        serverMessage = serverMessage.Replace("[", string.Empty);//.Replace("]", string.Empty);
                                                                                 //Debug.Log(serverMessage);

                        String[] lines = serverMessage.Split(']');//new String[] { Environment.NewLine }, StringSplitOptions.None);

                        foreach (String line in lines)
                        {
                            if (line != "")
                            {
                                string[] joints = line.Split(',');
								//Debug.Log(joints.Length + ": " +length);
								if (joints.Length > 6)
                                {
                                    //Debug.Log(joints.Length);

										joint1 = joints[0];
										joint2 = joints[1];
										joint3 = joints[2];
										joint4 = joints[3];
										joint5 = joints[4];
										joint6 = joints[5];
										joint7 = joints[6];
										//Debug.Log(joints[0]);

								}
                            }
                        }

                    }
				}
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}
	/// <summary> 	
	/// Send message to server using socket connection. 	
	/// </summary> 	
	public void SendMessage(String messageGet)
	{
		if (socketConnection == null)
		{
			return;
		}
		try
		{
			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream();
			if (stream.CanWrite)
			{
				string clientMessage = messageGet;
				// Convert string message to byte array.                 
				byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
				Debug.Log("Client sent his message - should be received by server");
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}
}