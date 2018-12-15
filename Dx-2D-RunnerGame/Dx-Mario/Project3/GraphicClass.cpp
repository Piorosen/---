#include "GraphicClass.h"


GraphicClass::GraphicClass()
{
	m_D3D = 0;
	m_Camera = 0;
	m_Text = 0;
	m_map = 0;
	m_mapdata = 0;
	m_player = 0;
	m_Block[0] = 0;
	m_Block[1] = 0;
	m_Block[2] = 0;
	m_gameover = 0;
	m_textureShader = 0;
	m_sound = 0;
}


GraphicClass::GraphicClass(const GraphicClass& other)
{
}


GraphicClass::~GraphicClass()
{
}


bool GraphicClass::Initialize(HWND hwnd)
{
	m_hwnd = hwnd;
	bool result;
	D3DXMATRIX baseViewMatrix;

	m_map = new Map;
	m_map->Initialize(SIZE_X, SIZE_Y, "C:\\Map\\");
	m_map->MapReLoad("map.txt");
	m_map->GetMapData(m_mapdata);

	m_D3D = new D3DClass;
	if (!m_D3D)
	{
		return false;
	}

	result = m_D3D->Initialize(screenWidth, screenHeight, VSYNC_ENABLED, hwnd, FULL_SCREEN, SCREEN_DEPTH, SCREEN_NEAR);
	if (!result)
	{
		MessageBox(hwnd, L"Could not initialize Direct3D.", L"Error", MB_OK);
		return false;
	}

	m_sound = new SoundClass;
	m_sound->Initialize(hwnd, const_cast<char*>("C:\\Map\\Data\\sound02.wav"));

	m_Camera = new CameraClass;
	if (!m_Camera)
	{
		return false;
	}
	
	std::wstring file = L"C:\\Map\\Block";
	for (int i = 0; i < 3; i++) {
		m_Block[i] = new BitmapClass;
		result = m_Block[i]->Initialize(m_D3D->GetDevice(), const_cast<WCHAR*>((file + to_wstring(i + 1) + L".jpg").c_str()), screenWidth / SCREEN_X, screenHeight / SCREEN_Y);
		if (!result) {
			MessageBox(hwnd, to_wstring(i).c_str(), L"Error", MB_OK);
		}
	}

	m_gameover = new BitmapClass;
	m_gameover->Initialize(m_D3D->GetDevice(), const_cast<WCHAR*>(L"C:\\Map\\Lose.png"), 1600, 800);

	m_textureShader = new TextureShaderClass;
	m_textureShader->Initialize(m_D3D->GetDevice(), hwnd);
	

	m_Camera->SetPosition(0, 0, -10);
	m_Camera->Render();
	m_Camera->GetViewMatrix(baseViewMatrix);

	m_player = new Player;
	m_player->Initialize(m_D3D->GetDevice(), m_Camera, m_mapdata, hwnd);

	m_Text = new TextClass;
	m_Text->Initialize(m_D3D->GetDevice(), m_D3D->GetDeviceContext(), hwnd, baseViewMatrix);

	/*if (!m_Colormodel) {
		return false;
	}
	for (int y = 0; y < SIZE_Y; y++) {
		for (int x = 0; x < SIZE_X; x++) {
			m_Colormodel[y][x] = RectClass();

			D3DXVECTOR4 color;
			color.w = m_mapdata[y][x].Alpha;
			color.x = m_mapdata[y][x].Red;
			color.y = m_mapdata[y][x].Green;
			color.z = m_mapdata[y][x].Blue;
			
			D3DXVECTOR3 position;
			position.x = x * screenWidth / SCREEN_X - screenWidth / 2;
			position.y = -1 * y * screenHeight / SCREEN_Y + screenHeight / 2;
			position.z = 0.0f;
			D3DXVECTOR3 size;
			size.x = screenWidth / SCREEN_X;
			size.y = screenHeight / SCREEN_Y;
			size.z = 0.0f;
			result = m_Colormodel[y][x].Initialize(m_D3D->GetDevice(), color, position, size);
		}
	}*/

	return true;
}


void GraphicClass::Shutdown()
{
	if (m_textureShader) {
		m_textureShader->Shutdown();
		delete m_textureShader;
		m_textureShader = 0;
	}

	for (int i = 0; i < 3; i++) {
		if (m_Block[i]) {
			m_Block[i]->Shutdown();
			delete m_Block[i];
			m_Block[i] = 0;
		}
	}

	if (m_sound) {
		m_sound->Shutdown();
		delete m_sound;
		m_sound = 0;
	}

	if (m_color)
	{
		m_color->Shutdown();
		delete m_color;
		m_color = 0;
	}	

	if(m_Text)
	{
		m_Text->Shutdown();
		delete m_Text;
		m_Text = 0;
	} 


	if (m_Camera)
	{
		delete m_Camera;
		m_Camera = 0;
	}

	if (m_D3D)
	{
		m_D3D->Shutdown();
		delete m_D3D;
		m_D3D = 0;
	}

	return;
}


bool GraphicClass::Frame(int i, D3DXVECTOR2 mouse)
{
	
	
	bool result;
	m_Text->SetMousePosition((float)mouse.x, (float)mouse.y, m_D3D->GetDeviceContext());
	
	result = Render(i, mouse);
	if (!result)
	{
		return false;
	}

	return true;
}


bool GraphicClass::Render(int i, D3DXVECTOR2 mouse)
{
	static int score = 0;
	static D3DXVECTOR2 Position(screenWidth / 2.0f, screenHeight / 2.0f);
	static D3DXVECTOR2 CameraPosition(screenWidth / 2.0f, screenHeight / 2.0f);

	score++;

	const int UP = 1;
	const int DOWN = 2;
	const int LEFT = 1;
	const int RIGHT = 2;

	if (Position.x + screenWidth / SCREEN_X + screenWidth / 2 >= CameraPosition.x) {
		Position.y += 10;
		if (m_map->GetCollide(Position, m_player->GetCharacterSize())) {
			Position.y -= 10;
		}

		/*if (i % 10 == LEFT) {
			Position.x -= 10;
			if (m_map->GetCollide(Position, m_player->GetCharacterSize())) {
				Position.x += 10;
			}
		}
		if (i % 10 == RIGHT) {
			Position.x += 10;
			if (m_map->GetCollide(Position, m_player->GetCharacterSize())) {
				Position.x -= 10;
			}
		}*/
		if (CameraPosition.x >= (screenWidth / SCREEN_X * 110)) {
			Position.x -= (screenWidth / SCREEN_X * 100);
			CameraPosition.x -= (screenWidth / SCREEN_X * 100);
		}

		Position.x += 5;
		CameraPosition.x += 5;
		if (m_map->GetCollide(Position, m_player->GetCharacterSize())) {
			Position.x -= 5;
		}
	}
	//if (i % 100 / 10 == UP) {
	//	Position.y -= 10;
	//	if (m_map->GetCollide(Position, m_player->GetCharacterSize())) {
	//			Position.y += 10;
	//	}
	//}
	//if (i % 100 / 10 == DOWN) {
	//	Position.y += 10;
	//	if (m_map->GetCollide(Position, m_player->GetCharacterSize())) {
	//		Position.y -= 10;
	//	}
	//}

	D3DXMATRIX worldMatrix, viewMatrix, projectionMatrix, orthoMatrix;
	m_D3D->BeginScene(0.0f, 0.0f, 0.0f, 1.0f);
	m_player->CameraMove({ CameraPosition.x, screenHeight / 2.0f });
	m_Camera->Render();
	m_Camera->GetViewMatrix(viewMatrix);

	m_D3D->GetWorldMatrix(worldMatrix);
	m_D3D->GetProjectionMatrix(projectionMatrix);
	m_D3D->GetOrthoMatrix(orthoMatrix);
	m_D3D->TurnOnAlphaBlending();
	m_D3D->TurnZBufferOff();


	
	


	// 맵만듬
	for (int y = 0; y < SIZE_Y; y++) {
		for (int x = 0; x < SIZE_X; x++) {
			if (m_mapdata[y][x].TextureID == 0) {
				m_Block[0]->Render(m_D3D->GetDeviceContext(), x * screenWidth / SCREEN_X,
				y * screenHeight / SCREEN_Y	);
				m_textureShader->Render(m_D3D->GetDeviceContext(), m_Block[0]->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix, m_Block[0]->GetTexture());
			}
			else if (m_mapdata[y][x].TextureID == 1){
				m_Block[1]->Render(m_D3D->GetDeviceContext(), x * screenWidth / SCREEN_X,
					y * screenHeight / SCREEN_Y);
				m_textureShader->Render(m_D3D->GetDeviceContext(), m_Block[1]->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix, m_Block[1]->GetTexture());
			}
			else {
				m_Block[2]->Render(m_D3D->GetDeviceContext(), x * screenWidth / SCREEN_X,
					y * screenHeight / SCREEN_Y);
				m_textureShader->Render(m_D3D->GetDeviceContext(), m_Block[2]->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix, m_Block[2]->GetTexture());
			}
		}
	}
	for (int y = 0; y < SIZE_Y; y++) {
		for (int x = 0; x < SIZE_X; x++) {
			if (m_mapdata[y][x].TextureID == 0) {
				m_Block[0]->Render(m_D3D->GetDeviceContext(), (x + 100) * screenWidth / SCREEN_X,
					y * screenHeight / SCREEN_Y);
				m_textureShader->Render(m_D3D->GetDeviceContext(), m_Block[0]->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix, m_Block[0]->GetTexture());
			}
			else if (m_mapdata[y][x].TextureID == 1) {
				m_Block[1]->Render(m_D3D->GetDeviceContext(), (x + 100) * screenWidth / SCREEN_X,
					y * screenHeight / SCREEN_Y);
				m_textureShader->Render(m_D3D->GetDeviceContext(), m_Block[1]->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix, m_Block[1]->GetTexture());
			}
			else {
				m_Block[2]->Render(m_D3D->GetDeviceContext(), (x + 100) * screenWidth / SCREEN_X,
					y * screenHeight / SCREEN_Y);
				m_textureShader->Render(m_D3D->GetDeviceContext(), m_Block[2]->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix, m_Block[2]->GetTexture());
			}
		}
	}

	//// 마우스 다운업
	//if (i / 1000 == 1) {
	//}
		

	static float jumpstack = 1;

	float speed = 30;
	float length = 2;

	// 점프 코드
	if (-speed <= jumpstack && jumpstack <= speed) {
		Position.y += jumpstack > 0 ? +0 : -20;
		jumpstack += 1;

		if (m_map->GetCollide(Position, m_player->GetCharacterSize())) {
 			Position.y += 10;
			jumpstack = 31;
		}
	}
	else {
		if (i / 100 == 1 && jumpstack == 31) {
			jumpstack = -speed;
		}
	}

	m_player->CharacterMove(m_D3D->GetDeviceContext(), D3DXVECTOR2(Position.x, Position.y)
		, worldMatrix, viewMatrix, orthoMatrix);
	

	if (Position.x + screenWidth / SCREEN_X + screenWidth / 2 < CameraPosition.x) {
		m_gameover->Render(m_D3D->GetDeviceContext(), CameraPosition.x - 800, screenHeight / 2 - 400);
		m_textureShader->Render(m_D3D->GetDeviceContext(), m_gameover->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix, m_gameover->GetTexture());
		i = 0;
	}
	else {
		m_Text->SetScore(score, m_D3D->GetDeviceContext());
	}
	m_Text->Render(m_D3D->GetDeviceContext(), worldMatrix, orthoMatrix);

	m_D3D->EndScene();
	m_D3D->TurnZBufferOn();
	return true;
}