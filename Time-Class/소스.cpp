#include <stdio.h>

class Time{
private:
	int Hour;
	int Min;
	int Second;
public:
	Time(){
		Hour = 0;
		Min = 0;
		Second = 0;
	}
	Time(int Hour, int Min, int Second){
		this->Hour = Hour;
		this->Min = Min;
		this->Second = Second;
	}
	const int GetHour() const {
		return Hour;
	}
	const int GetMin() const {
		return Min;
	}
	const int GetSecond() const {
		return Second;
	}
};

int main(){
	Time time(10,10,10);
	printf("%d %d %d",
		time.GetHour(), time.GetMin(), time.GetSecond());

	for (;;);
}

