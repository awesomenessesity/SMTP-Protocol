package protocol.stmp.server;

import java.net.ServerSocket;
import java.net.Socket;

public class ClientReceiver extends Thread {
	
	//listen to the server socket
	ServerSocket listeningSocket;
	
	public ClientReceiver(ServerSocket listeningSocket){
		super();
		this.listeningSocket = listeningSocket;
	}
	
	@Override
	public void run(){
		try{
			while(true){
				
				//wait for a client to connect
				Socket clientConnection = listeningSocket.accept();
				
				//client connected, create client handler thread to deal with him
				ClientHandler handleClient = new ClientHandler(clientConnection);
				handleClient.start();
				
			}
		}catch(Exception e){}
	}
}
