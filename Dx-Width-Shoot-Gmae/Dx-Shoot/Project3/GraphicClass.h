////////////////////////////////////////////////////////////////////////////////
// Filename: GraphicClass.h
////////////////////////////////////////////////////////////////////////////////
#pragma once



#include <time.h>
#include <string>



#include "Global.h"
#include "D3DClass.h"
#include "CameraClass.h"
#include "InputClass.h"
#include "ShapeShaderClass.h"

#include "RectClass.h"	
#include "TextClass.h"
#include "MapLoader.h"

#include "Player.h"
#include "Map.h"
#include "Bullet.h"
#include "SoundClass.h"

#include "FpsClass.h"
#include "CpuClass.h"
#include "TimerClass.h"


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

	Player* m_player = new Player;

	ShapeShaderClass* m_color = new ShapeShaderClass;

	BitmapClass* m_gameover = new BitmapClass;
	BitmapClass* m_Block[4];
	TextureShaderClass* m_textureShader = new TextureShaderClass;

	SoundClass* m_sound = new SoundClass;
	TextClass* m_Text = new TextClass;

	Map* m_map = new Map;

	HWND m_hwnd;
	
	MapData** m_mapdata;
	Bullet* m_bullet[BULLET_COUNT];

};
