#pragma once
#include <Windows.h>
#include <time.h>

#include "InputClass.h"
#include "GraphicClass.h"

class SystemClass
{
private:
	bool Frame();

	/// <param id="a"> けいしけいしけい</param>
	void InitializeWindows(int& a, int&);
	void ShutdownWindows();


	LPCWSTR m_applicationName;
	HINSTANCE m_hinstance;
	HWND m_hwnd;

	InputClass* m_Input;
	GraphicClass* m_Graphic;

	
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