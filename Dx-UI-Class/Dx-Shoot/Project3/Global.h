#pragma once
#include <Windows.h>

const int SIZE_X = 32;
const int SIZE_Y = 9;

const int SCREEN_X = 16;
const int SCREEN_Y = 9;

const int screenWidth = GetSystemMetrics(SM_CXSCREEN);;
const int screenHeight = GetSystemMetrics(SM_CYSCREEN);

const int LEFT_POSITION = 800;

const int BULLET_COUNT = 4;

#define Lib_DIRECTXTOWINDOWX(var) (float)((screenWidth / 2 * -1) + (float)var)
#define Lib_DIRECTXTOWINDOWY(var) (float)((screenHeight / 2) - (float)var)

#define Lib_WINDOWTODIRECTXX(var) (float)((screenWidth / 2 * -1) - (float)var)
#define Lib_WINDOWTODIRECTXY(var) (float)((screenHeight / 2) + (float)var)

//(float)(screenHeight / 2) - (float)positionY;
#define Lib_WINDOWSIZEX(var, size) (var + (float)size)
#define Lib_WINDOWSIZEY(var, size) (var - (float)size)

#define RoundInt(var) ((int)round(var))
