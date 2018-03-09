package protocol.stmp.server;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Vector;


public final class EmailWriter {

	public static void writeToFile(Vector<String> emails,String email) {
		//save email to file.
		FileWriter fw = null;
		BufferedWriter bw = null;
		
		//run over each email and save the email content.
		for (String string : emails) {
			synchronized(EmailWriter.class){
				//open special file for each Email.
				try {
					fw = new FileWriter(string+".txt",true);
				} catch (IOException e) {
					System.out.println("Error: " + e.getMessage());
					e.printStackTrace();
				}
				bw = new BufferedWriter(fw);
				//write the content of the email to the file.
				try {
					bw.write(email + "<!--@END OF EMAIL@--!>" + '\n' + '\n');
					bw.flush();
				} catch (IOException e) {
					System.out.println("Error: " + e.getMessage());
				}
				finally {
					try {
						bw.close();
						fw.close();
					} catch (IOException e) {
						e.printStackTrace();
					}
					
				}
			}
		}
	}
}
