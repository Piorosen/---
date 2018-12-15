#pragma once



#include <time.h>
#include <string>

#include "Global.h"
#include "D3DClass.h"
#include "CameraClass.h"
#include "InputClass.h"

#include "RectClass.h"	
#include "TextClass.h"

#include "SoundClass.h"

#include "FpsClass.h"
#include "CpuClass.h"
#include "TimerClass.h"

#include "UserInterface.h"

#include "RectClass.h"
#include "CircleClass.h"

#include "ShapeShaderClass.h"


#include "MusicReader.h"

const bool FULL_SCREEN = false;
const bool VSYNC_ENABLED = true;
const float SCREEN_DEPTH = 1000.0f;
const float SCREEN_NEAR = 0.1f;


class GraphicClass
{
public:

	bool Initialize(HWND);
	void Shutdown();
	bool Frame(int, D3DXVECTOR2, int, int, float);

private:
	bool Render(int, D3DXVECTOR2);

private:
	time_t now = clock();

	D3DClass * m_D3D = new D3DClass;
	CameraClass* m_Camera = new CameraClass;

	SoundClass* m_sound = new SoundClass;
	TextClass* m_Text = new TextClass;

	std::vector<CircleClass*> m_rect;
	ShapeShaderClass* m_shapeshader = new ShapeShaderClass;

	HWND m_hwnd;

	std::vector<Data> list;
	MusicReader m_mr;

	time_t start = clock();
	time_t flow = 0;

};
