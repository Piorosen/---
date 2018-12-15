#pragma once
#include <Windows.h>
#include <time.h>

#include "InputClass.h"
#include "GraphicClass.h"
#include "CpuClass.h"
#include "TimerClass.h"
#include "FpsClass.h"

class SystemClass
{
private:
	bool Frame();

	void InitializeWindows(int& a, int&);
	void ShutdownWindows();


	LPCWSTR m_applicationName;
	HINSTANCE m_hinstance;
	HWND m_hwnd;

	InputClass* m_Input;
	GraphicClass* m_Graphic;

	CpuClass* m_cpu;
	TimerClass* m_timer;
	FpsClass* m_fps;

public:
	SystemClass();
	virtual ~SystemClass();

	LRESULT CALLBACK MessageHandler(HWND, UINT, WPARAM, LPARAM);	

	bool Initialize(LPCWSTR AppName, int Width, int Height);

	void Shutdown();
	void Run();
	
};

static LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

static SystemClass* ApplicationHandle = 0;