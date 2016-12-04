
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
namespace TcpEchoClient
{
	class TcpEchoClient
	{

        static void Main(string[] args)
		{
            int recv;
            //int sendLenght;
            byte[] data = new byte[1024];
            byte[] outputData = new byte[1024];
            byte[] automaticData = new byte[1024];

            Console.WriteLine("Starting echo client...");

			int port = 1234;
			TcpClient client = new TcpClient("localhost", port);
			NetworkStream stream = client.GetStream();
			//StreamReader reader = new StreamReader(stream);
			//StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            

                while (true)
			{
                stream.Flush();
                data = new byte[1024];
                string lineReceived = "";
                Console.Write("Enter to send: ");
				string lineToSend = Console.ReadLine();
				Console.WriteLine("Sending to server: " + lineToSend);
                outputData = Encoding.ASCII.GetBytes(lineToSend);
                stream.Write(outputData, 0, outputData.Length);

                recv = stream.Read(data, 0, data.Length);
                lineReceived = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine("message received from server: {0}", lineReceived);

                if (lineReceived == "second policy")
                {
                    Inact.iInact = true;
                    Inact.inactSearch();
                    outputData = Encoding.ASCII.GetBytes(Inact.playerNumber.ToString());
                    stream.Write(outputData,0,outputData.Length);

                }
                if (lineReceived == "third policy")
                {
                    Inact.iInact = true;
                    Inact.inactPresidentialPick();
                    outputData = Encoding.ASCII.GetBytes(Inact.playerNumber.ToString());
                    stream.Write(outputData, 0, outputData.Length);

                }
                if (lineReceived == "fourth policy")
                {
                    Inact.iInact = true;
                    Inact.inactExecuteOrder66();
                    outputData = Encoding.ASCII.GetBytes(Inact.playerNumber.ToString());
                    stream.Write(outputData, 0, outputData.Length);

                }
                if (lineReceived == "fifth policy")
                {
                    Inact.iInact = true;
                    Inact.inactSecondExecution();
                    outputData = Encoding.ASCII.GetBytes(Inact.playerNumber.ToString());
                    stream.Write(outputData, 0, outputData.Length);

                }

            }
		}

	}
    public static class Inact
    {
        static string[] otherPlayersName = { "player1", "player2", "player3", "player4", "player5", "player6" };
        static string[] faction = { "Fascist", "Fascist", "Liberal", "Liberal", "Liberal", "Liberal" };
        static public int playerNumber;
        static public bool iInact = true;
        static string input;



        public static void inactSearch()
        {
            if (iInact == true)
            {
                Console.WriteLine("Inact search faction, who do you wish to seach {0}, {1}, {2}, {3}, {4} or {5} (remember it is case sensative)",
                                    otherPlayersName[0],
                                    otherPlayersName[1],
                                    otherPlayersName[2],
                                    otherPlayersName[3],
                                    otherPlayersName[4],
                                    otherPlayersName[5]);

                input = Console.ReadLine();

                #region assign playerNames -> numbers
                if (input == otherPlayersName[0])
                {
                    playerNumber = 0;
                }
                else if (input == otherPlayersName[1])
                {
                    playerNumber = 1;
                }
                else if (input == otherPlayersName[2])
                {
                    playerNumber = 2;
                }
                else if (input == otherPlayersName[3])
                {
                    playerNumber = 3;
                }
                else if (input == otherPlayersName[4])
                {
                    playerNumber = 4;
                }
                else if (input == otherPlayersName[5])
                {
                    playerNumber = 5;
                }
                #endregion

                //Console.WriteLine("You decided to search: {0} \n He is a: {1}", otherPlayersName[playerNumber], faction[playerNumber]);
                iInact = false;

            }
        }

        public static void inactPresidentialPick()
        {
            if (iInact == true)
            {
                Console.WriteLine("Who do you wish to become the next president: {0}, {1}, {2}, {3}, {4} or {5} (remember it is case sensative)",
                                    otherPlayersName[0],
                                    otherPlayersName[1],
                                    otherPlayersName[2],
                                    otherPlayersName[3],
                                    otherPlayersName[4],
                                    otherPlayersName[5]);
            }
            input = Console.ReadLine();

            #region assign playerNames -> numbers
            if (input == otherPlayersName[0])
            {
                playerNumber = 0;
            }
            else if (input == otherPlayersName[1])
            {
                playerNumber = 1;
            }
            else if (input == otherPlayersName[2])
            {
                playerNumber = 2;
            }
            else if (input == otherPlayersName[3])
            {
                playerNumber = 3;
            }
            else if (input == otherPlayersName[4])
            {
                playerNumber = 4;
            }
            else if (input == otherPlayersName[5])
            {
                playerNumber = 5;
            }
            #endregion

            //Console.WriteLine("You decided to make: {0} the president", otherPlayersName[playerNumber]);
            //make that guys varieble president or send player number to serv which does it
            iInact = false;
        }

        public static void inactExecuteOrder66()
        {
            if (iInact == true)
            {
                Console.WriteLine("Who do you wish to kill: {0}, {1}, {2}, {3}, {4} or {5} (remember it is case sensative)",
                                    otherPlayersName[0],
                                    otherPlayersName[1],
                                    otherPlayersName[2],
                                    otherPlayersName[3],
                                    otherPlayersName[4],
                                    otherPlayersName[5]);
            }
            input = Console.ReadLine();

            #region assign playerNames -> numbers
            if (input == otherPlayersName[0])
            {
                playerNumber = 0;
            }
            else if (input == otherPlayersName[1])
            {
                playerNumber = 1;
            }
            else if (input == otherPlayersName[2])
            {
                playerNumber = 2;
            }
            else if (input == otherPlayersName[3])
            {
                playerNumber = 3;
            }
            else if (input == otherPlayersName[4])
            {
                playerNumber = 4;
            }
            else if (input == otherPlayersName[5])
            {
                playerNumber = 5;
            }
            #endregion

            //Console.WriteLine("You decided to kill: {0}", otherPlayersName[playerNumber]);
            // send info to server to change his bool isAlive = false
            iInact = false;
        }

        public static void inactSecondExecution()
        {
            if (iInact == true)
            {
                Console.WriteLine("Who do you wish to kill: {0}, {1}, {2}, {3}, {4} or {5} (remember it is case sensative)",
                                    otherPlayersName[0],
                                    otherPlayersName[1],
                                    otherPlayersName[2],
                                    otherPlayersName[3],
                                    otherPlayersName[4],
                                    otherPlayersName[5]);
            }
            input = Console.ReadLine();

            #region assign playerNames -> numbers
            if (input == otherPlayersName[0])
            {
                playerNumber = 0;
            }
            else if (input == otherPlayersName[1])
            {
                playerNumber = 1;
            }
            else if (input == otherPlayersName[2])
            {
                playerNumber = 2;
            }
            else if (input == otherPlayersName[3])
            {
                playerNumber = 3;
            }
            else if (input == otherPlayersName[4])
            {
                playerNumber = 4;
            }
            else if (input == otherPlayersName[5])
            {
                playerNumber = 5;
            }
            #endregion

            //Console.WriteLine("You decided to kill: {0} \n now Veto power is also enabled", otherPlayersName[playerNumber]);
            //make that guys varieble president or send player number to serv which does it
            //activate veeto stage
            iInact = false;
        }
    }
}