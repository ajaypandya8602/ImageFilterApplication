#undef UNICODE

#define WIN32_LEAN_AND_MEAN

#include <windows.h>
#include <winsock2.h>
#include <ws2tcpip.h>
#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include <opencv2/opencv.hpp>
#include<vector>
#include<sstream>

#include <vector>
#include <string>
#include <sstream>
#include <iostream>

#include <string.h>


#include <chrono>
#include <ctime>



// Need to link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
// #pragma comment (lib, "Mswsock.lib")

#define DEFAULT_BUFLEN 512
#define DEFAULT_PORT "8088"

using namespace cv;

Mat setBrightness(Mat img, int brightness)
{
	Mat l_Laplacian;

	Laplacian(img, l_Laplacian, -1, 1, 1.0, 0, BORDER_DEFAULT);
	return l_Laplacian;
}

int __cdecl main(int argc, char * argv[])
{
	std::string Path;
	std::string g_tempFolderPath;
	WSADATA wsaData;
	int iResult;


	SOCKET ListenSocket = INVALID_SOCKET;
	SOCKET ClientSocket = INVALID_SOCKET;

	struct addrinfo *result = NULL;
	struct addrinfo hints;

	int iSendResult;
	char recvbuf[DEFAULT_BUFLEN];
	int recvbuflen = DEFAULT_BUFLEN;

	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0) {
		printf("WSAStartup failed with error: %d\n", iResult);
		return 1;
	}

	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_INET;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;
	hints.ai_flags = AI_PASSIVE;

	// Resolve the server address and port
	iResult = getaddrinfo(NULL, DEFAULT_PORT, &hints, &result);
	if (iResult != 0) {
		printf("getaddrinfo failed with error: %d\n", iResult);
		WSACleanup();
		return 1;
	}

	// Create a SOCKET for connecting to server
	ListenSocket = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
	if (ListenSocket == INVALID_SOCKET) {
		printf("socket failed with error: %ld\n", WSAGetLastError());
		freeaddrinfo(result);
		WSACleanup();
		return 1;
	}

	// Setup the TCP listening socket
	iResult = bind(ListenSocket, result->ai_addr, (int)result->ai_addrlen);
	if (iResult == SOCKET_ERROR) {
		printf("bind failed with error: %d\n", WSAGetLastError());
		freeaddrinfo(result);
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	freeaddrinfo(result);

	iResult = listen(ListenSocket, SOMAXCONN);
	if (iResult == SOCKET_ERROR) {
		printf("listen failed with error: %d\n", WSAGetLastError());
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	// Accept a client socket
	ClientSocket = accept(ListenSocket, NULL, NULL);
	if (ClientSocket == INVALID_SOCKET) {
		printf("accept failed with error: %d\n", WSAGetLastError());
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	// No longer need server socket
	closesocket(ListenSocket);

	// Receive until the peer shuts down the connection
	do {

		iResult = recv(ClientSocket, recvbuf, recvbuflen, 0);
		if (iResult > 0) {
			printf("Bytes received: %d\n", iResult);
			
			String str = recvbuf;
			String recevedData = str.substr(0, iResult);

			std::vector<String> v;

			std::stringstream ss(recevedData);

			while (ss.good()) 
			{
				String substr;
				getline(ss, substr, ',');
				v.push_back(substr);
			}
			if (v[0] == "setTempFolderPath")
			{
				g_tempFolderPath = v[1];
				Path = "";
			}
			else if (v[0] == "setBlackandWhite")
			{
				Mat l_img = imread(v[1], IMREAD_GRAYSCALE);
				Mat BlackandWhite = l_img > 128;

				auto timenow = std::chrono::system_clock::to_time_t(std::chrono::system_clock::now());

				std::cout << timenow << std::endl;

				//std::cout << argv[0];
				//std::cin.get();
				Path = g_tempFolderPath + (std::string)"img" + std::to_string(timenow) + (std::string)".jpg";

				std::string s = Path;
				std::replace(s.begin(), s.end(), '~', '\\'); // replace all 'x' to 'y'

				imwrite(s, BlackandWhite);
			}
			else if (v[0] == "AddTextOnImage")
			{
				Mat l_img = imread(v[1]);

				putText(l_img, v[2], Point(stod(v[4]), stod(v[5])), FONT_HERSHEY_COMPLEX, stod(v[3]), Scalar(stod(v[6]), stod(v[7]), stod(v[8])));

				auto timenow = std::chrono::system_clock::to_time_t(std::chrono::system_clock::now());

				std::cout << timenow << std::endl;

				//std::cout << argv[0];
				//std::cin.get();
				Path = g_tempFolderPath + (std::string)"img" + std::to_string(timenow) + (std::string)".jpg";

				std::string s = Path;
				std::replace(s.begin(), s.end(), '~', '\\'); // replace all 'x' to 'y'

				imwrite(s, l_img);
			}
			else if(v[0] == "setEdgeImage")
			{
				Mat l_img = imread(v[1], IMREAD_GRAYSCALE);

				Mat adaptive_gaussian;

				adaptiveThreshold(l_img, adaptive_gaussian, 255, ADAPTIVE_THRESH_GAUSSIAN_C, THRESH_BINARY, 9, 11);
				
				auto timenow = std::chrono::system_clock::to_time_t(std::chrono::system_clock::now());

				std::cout << timenow << std::endl;

				//std::cout << argv[0];
				//std::cin.get();
				Path = g_tempFolderPath + (std::string)"img" + std::to_string(timenow) + (std::string)".jpg";

				std::string s = Path;
				std::replace(s.begin(), s.end(), '~', '\\'); // replace all 'x' to 'y'

				imwrite(s, adaptive_gaussian);
			}

			else if (v[0] == "setBrightness")
			{
				Mat l_img = imread(v[1]);
				Mat img_higher_brightness;
				l_img.convertTo(img_higher_brightness, -1, 1, stoi(v[2]));
				
				auto timenow =
					std::chrono::system_clock::to_time_t(std::chrono::system_clock::now());

				std::cout << timenow << std::endl;

				//std::cout << argv[0];
				//std::cin.get();
				Path = g_tempFolderPath + (std::string)"img" + std::to_string(timenow) + (std::string)".jpg";
				
				std::string s = Path;
				std::replace(s.begin(), s.end(), '~', '\\'); // replace all 'x' to 'y'

				imwrite(s, img_higher_brightness);
				
				std::cout << "setBrightness : " << v[2] << std::endl;
			}
			else if (v[0] == "setContrast")
			{
				Mat l_img = imread(v[1]);
				Mat imageContrastHigh2;
				l_img.convertTo(imageContrastHigh2, -1, stod(v[2]), 0); //increase the contrast by 2

				auto timenow =
					std::chrono::system_clock::to_time_t(std::chrono::system_clock::now());

				std::cout << timenow << std::endl;

				//std::cout << argv[0];
				//std::cin.get();
				Path = g_tempFolderPath + (std::string)"img" + std::to_string(timenow) + (std::string)".jpg";

				std::string s = Path;
				std::replace(s.begin(), s.end(), '~', '\\'); // replace all 'x' to 'y'

				imwrite(s, imageContrastHigh2);

					   
				std::cout << "setContrast : " << v[2] << std::endl;

			}
			else if (v[0] == "setBlur")
			{
				Mat l_img = imread(v[1]);
				Mat imageblur;
			

				blur(l_img, imageblur, Size(stoi(v[2]), stoi(v[2])));


				auto timenow =
					std::chrono::system_clock::to_time_t(std::chrono::system_clock::now());

				std::cout << timenow << std::endl;

				//std::cout << argv[0];
				//std::cin.get();
				Path = g_tempFolderPath + (std::string)"img" + std::to_string(timenow) + (std::string)".jpg";

				std::string s = Path;
				std::replace(s.begin(), s.end(), '~', '\\'); // replace all 'x' to 'y'

				imwrite(s, imageblur);


				std::cout << "setBlur : " << v[2] << std::endl;

			}
			
		
			std::cout << "Received Data : " << recevedData << std::endl;
			// Echo the buffer back to the sender
			std::string sss = ("Success," + Path);
			const char* c = sss.c_str();
			std::cout <<"Value of c "<< c << std::endl;
			std::cout << "Value of sss " << sss << std::endl;

			
			iSendResult = send(ClientSocket, c , str.length(), 0);
			if (iSendResult == SOCKET_ERROR) {
				printf("send failed with error: %d\n", WSAGetLastError());
				closesocket(ClientSocket);
				WSACleanup();
				return 1;
			}
			printf("Bytes sent: %d\n", iSendResult);
		}
		else if (iResult == 0)
			printf("Connection closing...\n");
		else {
			printf("recv failed with error: %d\n", WSAGetLastError());
			closesocket(ClientSocket);
			WSACleanup();
			return 1;
		}

	} while (iResult > 0);

	// shutdown the connection since we're done
	iResult = shutdown(ClientSocket, SD_SEND);
	if (iResult == SOCKET_ERROR) {
		printf("shutdown failed with error: %d\n", WSAGetLastError());
		closesocket(ClientSocket);
		WSACleanup();
		return 1;
	}

	// cleanup
	closesocket(ClientSocket);
	WSACleanup();

	return 0;
}