#include <stdio.h>
#include <conio.h>
#include <Windows.h>


int main(){
	system("title Aoi IP New or Cut");

	while (true){
		printf("Aoi Kazto�� ������ ���ͳ� ����/���� ���α׷��Դϴ�.\n");
		printf("�������� ��α� : http://blog.naver.com/aoikazto\n");
		printf("��Ű : F1 -> IP���� | F2 : IP ����\n\n");

		int ch = 0;
		for (;;){
			if (_kbhit()){
				fflush(stdin);
				ch = _getch();
				if (ch == 59){
					printf("\n\nIP������ �õ� �մϴ�. ��ø� ��ٷ� �ּ���!\n\n\n\n\n\n\n");
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