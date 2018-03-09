package protocol.stmp.server;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.SocketException;


public class ServerMain {

	public static void main(String[] args) {
		
		int port = 25;
		
		//Initializing the buffered reader from keyboard.
		BufferedReader brIn = new BufferedReader(new InputStreamReader(System.in));
		
		try{
			//get the IP address to listen to
			InetAddress ipAddr = InetAddress.getByName("0.0.0.0");
			//create server socket on that IP
			ServerSocket serverSocket = new ServerSocket(port,10,ipAddr);
					
			//set the client receiver thread to wait for new clients.
			ClientReceiver listener = new ClientReceiver(serverSocket);
			listener.start();
			
			//Address we are listening on.
			System.out.println("Listening on: "+ serverSocket.getLocalSocketAddress());
			
			//close server on "close"
			while(true){
				String answer = brIn.readLine().trim().toLowerCase();
				if(answer.equals("close")){
					serverSocket.close();
					System.out.println("Bye bye!!!!");	
					return;
				}
			}		
		}
		catch(NumberFormatException nfe){
			System.out.println("Failed to parse, ilegal number.");	
		}
		catch(SocketException se){
			System.out.println("Failed to listen on the port.");
		}
		catch(Exception e){
			e.printStackTrace();
		}
	}

}
