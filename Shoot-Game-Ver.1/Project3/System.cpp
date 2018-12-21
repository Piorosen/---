#include "System.h"



bool SystemClass::Frame()
{
	bool result;
	int mouseX = 0, mouseY = 0;
	m_Input->GetMousePosition(mouseX, mouseY);
	int data = 0;

	if (m_Input->IsKeyDown(VK_ESCAPE)) {
		return false;
	}

	if (m_Input->IsMouseDown(0)) {
		data += 1000;
	}
	if (m_Input->IsKeyDown('W')) {
		data += 10;
	}
	if (m_Input->IsKeyDown('S')) {
		data += 20;
	}
	if (m_Input->IsKeyDown('A')) {
		data += 1;
	}
	if (m_Input->IsKeyDown('D')) {
		data += 2;
	}
	if (m_Input->IsKeyDown(VK_SPACE)) {
		data += 100;
	}if (m_Input->IsKeyDown('C')) {
		data += 200;
	}

	result = m_Graphic->Frame(data, D3DXVECTOR2(mouseX, mouseY));
	if (!result)
		return false;

	return true;
}

void SystemClass::InitializeWindows(int &Width, int &Height)
{
	WNDCLASSEX wc;

	int posX, posY;

	ApplicationHandle = this;
	m_hinstance = GetModuleHandle(NULL);

	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = WndProc;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hInstance = m_hinstance;
	wc.hIcon = LoadIcon(NULL, IDI_WINLOGO);
	wc.hIconSm = wc.hIcon;
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = m_applicationName;
	wc.cbSize = sizeof(WNDCLASSEX);

	RegisterClassEx(&wc);

	posX = (GetSystemMetrics(SM_CXSCREEN) - Width) / 2;
	posY = (GetSystemMetrics(SM_CYSCREEN) - Height) / 2;

	/*
	m_hwnd = CreateWindowEx(WS_EX_APPWINDOW, m_applicationName, m_applicationName,
		WS_CLIPSIBLINGS | WS_CLIPCHILDREN | WS_POPUP,
		posX, posY, Width, Height, NULL, NULL, m_hinstance, NULL);
	*/

	m_hwnd = CreateWindowEx(WS_EX_APPWINDOW, m_applicationName, m_applicationName,
		WS_OVERLAPPEDWINDOW,
		posX, posY, Width, Height, NULL, NULL, m_hinstance, NULL);

	ShowWindow(m_hwnd, SW_SHOW);
	SetForegroundWindow(m_hwnd);
	SetFocus(m_hwnd);
}

void SystemClass::ShutdownWindows()
{
	DestroyWindow(m_hwnd);
	m_hwnd = NULL;

	UnregisterClass(m_applicationName, m_hinstance);
	m_hinstance = NULL;
	ApplicationHandle = nullptr;
}


LRESULT SystemClass::MessageHandler(HWND hwnd, UINT umsg, WPARAM wparam, LPARAM lparam)
{
	switch (umsg)
	{
	case WM_KEYDOWN:
		m_Input->KeyDown((unsigned int)wparam);
		break;
	case WM_KEYUP:
		m_Input->KeyUp((unsigned int)wparam);
		break;

	case WM_MOUSEMOVE:
		m_Input->SetMousePosition(LOWORD(lparam), HIWORD(lparam));
		break;


	case WM_LBUTTONDOWN:
		m_Input->SetMouseDown(0);
		break;

	case WM_LBUTTONUP:
		m_Input->SetMouseUp(0);
		break;

	default:
		return DefWindowProc(hwnd, umsg, wparam, lparam); 
		break;
	}
	return 0;
}

SystemClass::SystemClass()
{
	m_Input = 0;
	m_Graphic = 0;
}

bool SystemClass::Initialize(LPCWSTR AppName, int Width, int Height)
{
	m_applicationName = AppName;
	bool result; 
	

	m_Input = new InputClass;
	if(!m_Input)
		return false;
	m_Input->Initialize();

	InitializeWindows(Width, Height);

	m_Graphic = new GraphicClass;
	if(!m_Graphic)
		return false;
	result = m_Graphic->Initialize(m_hwnd);

	if(!result) 
		return false; 
	return true;
}

void SystemClass::Shutdown()
{
	if (m_Graphic) {
		m_Graphic->Shutdown();
		delete m_Graphic;
		m_Graphic = 0;
	}

	if (m_Input) {
		delete m_Input;
		m_Input = 0;
	}
	ShutdownWindows();
}

void SystemClass::Run()
{
	MSG msg;
	bool done, result;

	ZeroMemory(&msg, sizeof(MSG));

	done = false;
	while (!done) {
		if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE)) {
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}

		if (msg.message == WM_QUIT) {

			done = true;
		}
		else {
			result = Frame();
			if (!result) done = true;
		}
	}

}
SystemClass::~SystemClass()
{
}


LRESULT CALLBACK WndProc(HWND hwnd, UINT umessage, WPARAM wparam, LPARAM lparam) 
{
	switch (umessage)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
		break;

	case WM_CLOSE:
		PostQuitMessage(0);
		return 0;
	default:
		return ApplicationHandle->MessageHandler(hwnd, umessage, wparam, lparam);
	}
}