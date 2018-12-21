#include "GraphicClass.h"


GraphicClass::GraphicClass()
{
	m_D3D = 0;
	m_Camera = 0;
	m_Text = 0;
	m_map = 0;
	m_mapdata = 0;
	
	for (int i = 0; i < 100; i++) {
		m_bullet[i] = 0;
	}
		
	
	m_player = 0;
	for (int i = 0; i < 30; i++) {
		m_monster[i] = 0;
	}
	m_Block[0] = 0;
	m_Block[1] = 0;
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


	// Create the Direct3D object.
	m_D3D = new D3DClass;
	if (!m_D3D)
	{
		return false;
	}

	// Initialize the Direct3D object.
	result = m_D3D->Initialize(screenWidth, screenHeight, VSYNC_ENABLED, hwnd, FULL_SCREEN, SCREEN_DEPTH, SCREEN_NEAR);
	if (!result)
	{
		MessageBox(hwnd, L"Could not initialize Direct3D.", L"Error", MB_OK);
		return false;
	}

	m_sound = new SoundClass;
	m_sound->Initialize(hwnd, const_cast<char*>("C:\\Map\\Data\\sound02.wav"));

	// Create the camera object.
	m_Camera = new CameraClass;
	if (!m_Camera)
	{
		return false;
	}
	for (int i = 0; i < 100; i++) {
		m_bullet[i] = new Bullet;
		m_bullet[i]->Initialize(m_D3D->GetDevice(), hwnd, m_map);
	}

	for (int i = 0; i < 30; i++) {
		m_monster[i] = new Monster;
		m_monster[i]->Initialize(m_D3D->GetDevice(), m_map, hwnd);
	}
	std::wstring file = L"C:\\Map\\Block";
	for (int i = 0; i < 2; i++) {
		m_Block[i] = new BitmapClass;
		result = m_Block[i]->Initialize(m_D3D->GetDevice(), const_cast<WCHAR*>((file + to_wstring(i + 1) + L".jpg").c_str()), screenWidth / SCREEN_X, screenHeight / SCREEN_Y);
		if (!result) {
			MessageBox(hwnd, to_wstring(i).c_str(), L"Error", MB_OK);
		}
	}

	m_textureShader = new TextureShaderClass;
	m_textureShader->Initialize(m_D3D->GetDevice(), hwnd);
	

	m_Camera->SetPosition(0, 0, -10);
	m_Camera->Render();
	m_Camera->GetViewMatrix(baseViewMatrix);

	m_player = new Player;
	m_player->Initialize(m_D3D->GetDevice(), m_Camera, screenWidth, screenHeight, hwnd);

	m_color = new ShapeShaderClass;
	result = m_color->Initialize(m_D3D->GetDevice(), hwnd);

	m_Text = new TextClass;
	m_Text->Initialize(m_D3D->GetDevice(), m_D3D->GetDeviceContext(), hwnd, screenWidth, screenHeight, baseViewMatrix);

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

	for (int i = 0; i < 2; i++) {
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
	for (int i = 0; i < 100; i++) {
		if (m_bullet[i]) {
			m_bullet[i]->Shutdown();
			delete m_bullet[i];
			m_bullet[i] = 0;
		}
	}

	// Release the text object. 
	if(m_Text)
	{
		m_Text->Shutdown();
		delete m_Text;
		m_Text = 0;
	} 


	// Release the camera object.
	if (m_Camera)
	{
		delete m_Camera;
		m_Camera = 0;
	}

	// Release the D3D object.
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
	m_Text->SetMousePosition(mouse.x, mouse.y, m_D3D->GetDeviceContext());

	result = Render(i, mouse);
	if (!result)
	{
		return false;
	}

	return true;
}


bool GraphicClass::Render(int i, D3DXVECTOR2 mouse)
{
	if (i / 100 == 2) {
		for (int i = 0; i < 30; i++) {
			m_monster[i]->Recue();
		}
	}

	static D3DXVECTOR2 Position(0, 0);
	static D3DXVECTOR2 PrevPosition(0, 0);

	if (i % 10 == 1) {
		Position.x -= 10;
		if (m_map->GetCollide(Position.x + screenWidth / 2 - screenWidth / SCREEN_X,
			screenHeight / 2 - Position.y,
			screenWidth / SCREEN_X, screenHeight / SCREEN_Y)) {
			Position.x += 10;
		}
	}
	if (i % 10 == 2) {
		Position.x += 10;
		if (m_map->GetCollide(Position.x + screenWidth / 2 - screenWidth / SCREEN_X,
			screenHeight / 2 - Position.y,
			screenWidth / SCREEN_X, screenHeight / SCREEN_Y)) {
			Position.x -= 10;
		}
	}
	if (i % 100 / 10 == 1) {
		Position.y += 10;
		if (m_map->GetCollide(Position.x + screenWidth / 2 - screenWidth / SCREEN_X,
			screenHeight / 2 - Position.y,
			screenWidth / SCREEN_X, screenHeight / SCREEN_Y)) {
			Position.y -= 10;
		}
	}
	if (i % 100 / 10 == 2) {
		Position.y -= 10;
		if (m_map->GetCollide(Position.x + screenWidth / 2 - screenWidth / SCREEN_X,
			screenHeight / 2 - Position.y,
			screenWidth / SCREEN_X, screenHeight / SCREEN_Y)) {
			Position.y += 10;
		}
	}

	D3DXMATRIX worldMatrix, viewMatrix, projectionMatrix, orthoMatrix;

	m_D3D->BeginScene(0.0f, 0.0f, 0.0f, 1.0f);

	m_player->CameraMove(Position);
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
			if (m_mapdata[y][x].Move) {
				m_Block[0]->Render(m_D3D->GetDeviceContext(), x * screenWidth / SCREEN_X ,
				y * screenHeight / SCREEN_Y - screenHeight / SCREEN_Y);
				m_textureShader->Render(m_D3D->GetDeviceContext(), m_Block[0]->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix, m_Block[0]->GetTexture());
			}
			else {
				m_Block[1]->Render(m_D3D->GetDeviceContext(), x * screenWidth / SCREEN_X,
					y * screenHeight / SCREEN_Y - screenHeight / SCREEN_Y);
				m_textureShader->Render(m_D3D->GetDeviceContext(), m_Block[1]->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix, m_Block[1]->GetTexture());
			}
		}
	}

	for (int i = 0; i < 30; i++) {
		m_monster[i]->Move(m_D3D->GetDeviceContext(), Position, worldMatrix, viewMatrix, orthoMatrix);
	}

	if (i / 1000 == 1) {
		
		if (GetTickCount() - now >= 200) {
			int i;
			for (i = 0; i < 100; i++) {
				if (m_bullet[i]->canFire())
					break;
			}
			m_sound->PlayWaveFile(0, 0, 0);
			m_bullet[i]->SetPosition({ Position.x, Position.y, 0 }, { mouse.x - screenWidth / 2 + Position.x, -mouse.y + Position.y + screenHeight / 2, 0 });
			now = GetTickCount();
		}
	}
	for (int i = 0; i < 100; i++) {
		if (!m_bullet[i]->canFire()) {
			if (!m_bullet[i]->Render(m_D3D->GetDevice(), m_D3D->GetDeviceContext(), 50, 30, worldMatrix, viewMatrix, orthoMatrix)) {
				m_bullet[i]->SetShoot(1001);
			}
		}
		for (int w = 0; w < 30; w++) {
			if (!m_bullet[i]->canFire() && m_monster[w]->BulletCollide(m_bullet[i]->GetBulletPosition())) {
				OutputDebugString(L"잡았다.\n");
				m_bullet[i]->SetShoot(1001);
				m_monster[w]->Died();
				
			}
		}
	}
		

	
	
	static float jumpstack = -101;

	float speed = 30;
	float length = 2;

	// 점프 코드
	if (-speed <= jumpstack && jumpstack <= speed) {
		m_player->Move(m_D3D->GetDeviceContext(), D3DXVECTOR2(Position.x, Position.y - (1.0f / length * jumpstack * jumpstack - powf(speed, 2.0) / length))
			, worldMatrix, viewMatrix, orthoMatrix);
		jumpstack += 1;
	} // 캐릭터 충돌
	else {
		if (m_map->GetCollide(Position.x + screenWidth / 2 - screenWidth / SCREEN_X,
					screenHeight / 2 - Position.y, screenWidth / SCREEN_X, screenHeight / SCREEN_Y)) {
			m_player->CharacterMove(m_D3D->GetDeviceContext(), PrevPosition, worldMatrix, viewMatrix, orthoMatrix);
		}
		else {
			m_player->CharacterMove(m_D3D->GetDeviceContext(), Position, worldMatrix, viewMatrix, orthoMatrix);
			PrevPosition = Position;
		}

		if (i / 100 == 1) {
			jumpstack = -speed;
		}
	}

	

	m_Text->Render(m_D3D->GetDeviceContext(), worldMatrix, orthoMatrix);

	m_D3D->EndScene();
	m_D3D->TurnZBufferOn();

	PrevPosition = Position;
	return true;
}