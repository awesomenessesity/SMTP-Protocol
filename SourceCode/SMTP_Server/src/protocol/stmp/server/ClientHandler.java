package protocol.stmp.server;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.SocketException;
import java.util.Vector;


public class ClientHandler extends Thread {

	//the client socket
	Socket clientConnection;
	public ClientHandler(Socket clientConnection){
		super();
		this.clientConnection = clientConnection;
	}
	
	
	@Override
	public void run(){
		//save client email and name
		String client = null;
		String emailData = "";
		
		// vector to hold all the recipients
		Vector<String> emails = new Vector<>();
		
		//stream out and in.
		BufferedReader brIn = null;
		PrintWriter pwOut = null;
		try {
			System.out.println("Got new connection from client: "+ clientConnection.getRemoteSocketAddress().toString());
			//initialize the streams.
			brIn = new BufferedReader(new InputStreamReader(clientConnection.getInputStream()));
			pwOut = new PrintWriter(clientConnection.getOutputStream());
			
			// @@@@@@@@ start STMP protocol @@@@@@@@@@@@//////////////////////////////////////////////////////////////////////
			
			//////// 220 - server ready ///////////////////////////////////////////////////////////////////////////////////////
			pwOut.println("220 STMP Server Ready");
			pwOut.flush();
			
			//// wait for hello /////////////////////////////////////////////////////////////////////////////////////////
			String recievedString = brIn.readLine().trim();		
			if ( recievedString.startsWith("HELO"))
			{
				//if received helo reply hello "domain name".
				String[] domain = recievedString.split(" ", 2);
				client = domain[1];
				System.out.println("250 Hello " + domain[1]);
				pwOut.println("250 Hello " + domain[1]);
				pwOut.flush();
			}
			else {
				//wrong protocol word
				System.out.println("Protocol Error: 500");
				pwOut.println("500 command not recognized");
				pwOut.flush();
			}
			
			///// wait for mail from /////////////////////////////////////////////////////////////////////////////////////
			recievedString = brIn.readLine().trim();		
			if ( recievedString.startsWith("MAIL FROM"))
			{
				//if received "mail from" reply ok
				System.out.println("250 OK");
				pwOut.println("250 OK");
				pwOut.flush();
			}
			else {
				//wrong protocol word
				System.out.println("Protocol Error: 500");
				pwOut.println("500 command not recognized");
				pwOut.flush();
			}
			
			///// start a loop of "rcpt to" ////////////////////////////////////////////////////////////////////////////////
			while((recievedString = brIn.readLine().trim()).startsWith("RCPT TO")) {
				// save the forwarding msg to.
		        emails.add(recievedString.substring(recievedString.indexOf("<")+1, recievedString.lastIndexOf(">")));
		        //send OK
		        System.out.println("250 OK");
				pwOut.println("250 OK");
				pwOut.flush();
			}
			
			//// if while didnt match "rcpt to", check if "data" started //////////////////////////////////////////////////
			if(recievedString.equals("DATA")) {
				System.out.println("354 Send message content");
				pwOut.println("354 Send message content");
				pwOut.flush();
			}
			else {
				//wrong protocol word
				System.out.println("500 command not recognized");
				pwOut.println("500 command not recognized");
				pwOut.flush();
			}
			
			//// receive the entire data /////////////////////////////////////////////////////////////////////////////////////
			while(!(recievedString = brIn.readLine().trim()).equals(".")){	
				//check for dots in a string
				if(recievedString.startsWith(".")) {
					emailData += recievedString.substring(1) + "\n";
				}
				else {
					emailData += recievedString + "\n";
				}
				System.out.println(recievedString);
			}
			System.out.println("Received the Email Data (not part of protocol)");
			
			// check if received dot "." /////////////////////////////////////////////////////////////////////////////
			if(recievedString.equals(".")) {
				//received empty email.
				System.out.println("250 OK, message accepted for delivery");
				pwOut.println("250 OK, message accepted for delivery");
				pwOut.flush();
			}
			else {
				//wrong protocol word
				System.out.println("500 command not recognized");
				pwOut.println("500 command not recognized");
				pwOut.flush();
			}
			
			
			////// wait for QUIT ///////////////////////////////////////////////////////////////////////////////////////////
			recievedString = brIn.readLine().trim();
			if(recievedString.equals("QUIT")) {  
				System.out.println("221 Bye");
				pwOut.println("221 Bye");
				pwOut.flush();
			}
			else {
				System.out.println("Error in protocol QUIT.");
				pwOut.println("221 Bye");
				pwOut.flush();
			}
		
			// @@@@@@@ PROTOCOL ENDED @@@@@@@@@!!/////////////////////////////////////////////////////////////////////////
			
			Thread.sleep(200);
			clientConnection.close();
			
			//save email to file.
			EmailWriter.writeToFile(emails, emailData);			
			
		}
		catch(NumberFormatException nfe){
			System.out.println("Failed to parse double, ilegal number.");	
		}
		catch(NullPointerException npe){
			System.out.println("Connection with " + client + "terminated");
		}
		catch(SocketException se){
			System.out.println("Client " + clientConnection.getRemoteSocketAddress().toString() + " disconnected.");
		}
		catch(Exception e){
			e.printStackTrace();
		}

	}
}
