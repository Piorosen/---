#include <stdio.h>
#include <conio.h>
#include <Windows.h>


int main(){
	system("title Aoi IP New or Cut");

	while (true){
		printf("Aoi Kazto가 개발한 인터넷 연결/끊기 프로그램입니다.\n");
		printf("개발자의 블로그 : http://blog.naver.com/aoikazto\n");
		printf("핫키 : F1 -> IP연결 | F2 : IP 끊기\n\n");

		int ch = 0;
		for (;;){
			if (_kbhit()){
				fflush(stdin);
				ch = _getch();
				if (ch == 59){
					printf("\n\nIP연결을 시도 합니다. 잠시만 기다려 주세요!\n\n\n\n\n\n\n");
					system("ipconfig/renew");
					break;
				}
				else if (ch == 60){
					system("ipconfig/release");
					break;
				}
				else{
					continue;
				}
			}
		}
		system("cls");
	}

}