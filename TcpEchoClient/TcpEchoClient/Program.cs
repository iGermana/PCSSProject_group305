
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

            Console.WriteLine("Type and send [R] for rules or [Start] to begin the game");
            //rules
			Inact.rulesVoid();

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
					stream.Write(outputData, 0, outputData.Length);

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
        
        // Rules
        static string rules;


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

        //Rules
		public static void rulesVoid()
		{
            //Rules
            bool ruleBool = true;
			while (ruleBool == true)
			{
				#region Rules
				rules = Console.ReadLine();

				if (rules == "r" || rules == "R" || rules == "return" || rules == "Return")
				{
					//parties + chancellor + hitler
					Console.WriteLine("###################\nWelcome to Secret Hitler - to view more information on anything encased in [brackets], simply type the encased word and press 'enter'.\n----------------\n" +
									  "There are two teams: the [Liberals] and the [Facists]\n\n[Liberals] don't know each other, but are the majority." +
									  "\n[Liberals] win when -5- liberal policies are enacted or [Hitler] is executed.\n[Facists] all know who each other are and also know who [Hitler] is.\n[Facists] win" +
									  " when -6- facist policies are enacted or when -3- or more facist policies enacted AND Hitler is elected " +
									  "[Chancellor].\n[Hitler] doesn't know who the [Facists] or the [Liberals] are.");
					//roles 
					Console.WriteLine("----------------\nBefore the game starts, players will be given the role of either [Facist], [Liberal] or [Hitler] after which the [Facists] will be informed of who the other [Facist] players are, and who [Hitler] is");
					//+ what is chancellor and president ingame.
					Console.WriteLine("----------------\nOnce the game starts, player1 will start with the role of [President] and have this role for one turn.\nThe [President] has to nominate a player for the role of [Chancellor]," +
									  " again only for one turn.\nA vote is then cast in order to determine if the [Chancellor] gets voted in by the other players.\nIf the vote fails, the role of [President] will move on to the next " +
									  "player in line, and a new vote for a new [Chancellor] will be cast\nIf a vote passes, the [President] receives -3- [policies] of which -1- of these is discarded;" +
									  " the last policies (2) will then be given to the chancellor. ");
					//Chancellor functionality
					Console.WriteLine("----------------\nFrom the -2- policies given by the [President], the [Chancellor] has to put one in play and discard the other." +
									  "\nIf confronted by other players, lying, telling the truth or pleading the fifth (invoking your right to remain silent) are all valid options in this case.");
					//Policy played
					Console.WriteLine("----------------\nIf a [Facist] policy is played, the [President] may have to perform one of the following actions:" +
									  "\n -Investigate: the [President] secretly gains information on selected player's political orientation.\n -Special Election: the [President]" +
									  " picks a player to become the next [President].\n -Execute: the [President] has to execute a player." +
									  " If that player is [Hitler], [Liberals] win.");
					//Veto
					Console.WriteLine("----------------\nIf -5- [Facist] policies have already been enacted, the [Chancellor] can agree with the [President] to [Veto]." +
									  " \nIf the [Veto] goes through, another election is run and no policies are enacted that turn.");
					//Remember to lie!
					Console.WriteLine("----------------\nSecret Hitler is a sociopolitical game, so lying and deceiving isn't simply allowed - it's encouraged!\n###################");



				}
				else if (rules == "brackets" || rules == "Brackets")
				{
					Console.WriteLine("###################\nBrackets are semi-squares typically used for programming;\nthese are sometimes referred to as 'Burger King' brackets by Mr. Hamulic." +
									  "\n\n----------------\nType [r] or [return] to return to the general rules.\nType [Clear] to clear the chat.\n###################");
				}
				else if (rules == "Liberals" || rules == "liberals" || rules == "liberal" || rules == "Liberal")
				{
					Console.WriteLine("###################\nGeneral information:\nLiberals believe in liberty and equality above all.\nLiberals support ideas such as freedom of speech, gender equality and religious freedom." +
									  "\n\nGameplay:\nLiberals DON'T know each other, but are the majority.\nLiberals win when -5- liberal policies are enacted or [Hitler] is executed.\n\n----------------\nType [r] or [return] " +
									  "to return to the general rules.\nType [Clear] to clear the chat.\n###################");
				}
				else if (rules == "Hitler" || rules == "hitler")
				{
					Console.WriteLine("###################\nGeneral Information:\nHitler was the head of the Nazi Party of NSDAP and the chancellor of Germany. He was later appointed " +
									  "the title of 'Führer' of Nazi Germany." +
									  "\n\nGameplay:\nHitler is allied with the [Facists], but isn't aware of who the [Facists] are\n\n----------------\nType " +
									  "[r] or [return] to return to the general rules.\nType [Clear] to clear the chat.\n###################");
				}
				else if (rules == "Facists" || rules == "facists" || rules == "facist" || rules == "Facist")
				{
					Console.WriteLine("###################\nGeneral Information:\nFacists believe that liberal democracy is obsolete and wish to unite people under a totalitarian one-party state led by a single leader - " +
									  "a dictator.\n\nGameplay:\nFacists know who the other facists are and who's [Hitler], but are the minority.\nFacists win when -6- facist policies are " +
									  "enacted or when -3- or more facist policies enacted AND Hitler is elected [Chancellor]." +
									  "\n\n----------------\nType [r] or [return] to return to the general rules.\nType [Clear] to clear the chat.\n###################");
				}
				else if (rules == "Chancellor" || rules == "chancellor")
				{
					Console.WriteLine("###################\nGeneral Information:\nThe title of chancellor is used to describe many types of officers in various settings, typically the head of" +
									  " a government.\n\nGameplay:\nThe [Chancellor] is nominated by the [President]" +
									  "and potentially elected by the players through votation.\nOnce elected, the [Chancellor] receives -2- policies from the [President] of which -1- is " +
									  "chosen and played.\nIf confronted by other players, lying, telling the truth or remaining silent " +
									  "are all valid options.\nIf [Hitler] is elected chancellor and -3- [Facist] policies are enacted, [Facists] win.\n----------------\nType [r] or [return] " +
									  "to return to the general rules.\nType [Clear] to clear the chat.\n###################");
				}
				else if (rules == "veto" || rules == "Veto")
				{
					Console.WriteLine("###################\nGameplay:\nA Veto agreed upon by the [President] and the [Chancellor] disqualifies the need for enacting policies for one turn and prompts" +
									  " a new election.\n\n----------------\nType [r] or [return] to return to the general " +
									  "rules.\nType [Clear] to clear the chat.\n###################\n");
				}

				else if (rules == "policies" || rules == "Policies" || rules == "policy" || rules == "Policy")
				{
					Console.WriteLine("###################\nGameplay:\nPolicies are enacted each turn by the [Chancellor] and are given to him by the [President].\n-2- policies are" +
									  " chosen from when enacted; these policies can be either [Facist], [Liberal] or both.\n[Facist] " +
									  "policies may trigger additional abilities only usable by the [President], depending on the amount of policies in play.\n----------------\nType" +
									  " [r] or [return] to return to the general rules.\nType [Clear] to clear the chat.\n###################");
				}

				else if (rules == "president" || rules == "President")
				{
					Console.WriteLine("###################\nGeneral Information:\nThe president is the elected head of state and government and is the leader of a country or a republic." +
									  "\n\nGameplay:\nThe title and function of President is given to a new player every turn " +
									  "(ordinally).\nThe President has to nominate a [Chancellor] every turn.\nIf a [Chancellor] is voted in, the President has to receive -3- policies of which" +
									  " -1- is discarded; the remaining (2) policies are given to the [Chancellor].\nThe President or" +
									  " [Chancellor] that enacted the last policy cannot be nominated until the first round has been played.\n----------------\nType [r] or [return] to return " +
									  "to the general rules.\nType [Clear] to clear the chat.\n###################");

				}

				else if (rules == "Clear" || rules == "clear")
				{
					Console.Clear();
				}
				else if (rules == "Start" || rules == "start")
				{
					return;
               
				}
				else
				{
					Console.WriteLine("###################\nIncorrect input. Word not found.\n###################");
				}
			}
			#endregion

		}
	}
}