#include "Main.h"

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPWSTR	lpCmdLine,
	_In_ int nCmdShow) {
	
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

	SystemClass* System = new SystemClass();
	if (!System) {
		return 0;
	}
	
	if (System->Initialize(TEXT("DirectX GameMake : Aoi Kazto"), screenWidth, screenHeight)) {
		System->Run();
	}

	System->Shutdown();
	delete System;
	System = 0;

	return 0;
}