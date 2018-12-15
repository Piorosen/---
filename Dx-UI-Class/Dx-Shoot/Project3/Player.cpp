
#include "Player.h"
#include "Global.h"


void Player::CameraMove(D3DXVECTOR2 data)
{
	
	if (Position.x + LEFT_POSITION <= screenWidth / 2) {
		data.x = screenWidth / 2;
	}
	//else if (Position.x + LEFT_POSITION >= (SIZE_X - SCREEN_X / 2) * screenWidth / SCREEN_X) {
	//	data.x = (SIZE_X - SCREEN_X / 2) * screenWidth / SCREEN_X;
	//}
	else {
		data.x += LEFT_POSITION;
	}
	
	if (Position.y <= screenHeight / 2) {
		data.y = screenHeight / 2;
	}else if (Position.y >= (SIZE_Y - SCREEN_Y / 2.0f) * screenHeight / SCREEN_Y) {
		data.y = (SIZE_Y - SCREEN_Y / 2.0f) * (screenHeight / SCREEN_Y);
	}
	m_camera->SetPosition(data.x, data.y, -1);
}

bool Player::CharacterMove(ID3D11DeviceContext* context, D3DXVECTOR2 data,
	D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o)
{
	float x = data.x + SetPosition.x * (screenWidth / SCREEN_X);
	float y = data.y + SetPosition.y * (screenHeight / SCREEN_Y);

	m_bitmap->Render(context, x, y);
	m_texture->Render(context, m_bitmap->GetIndexCount(), w, v, o, m_bitmap->GetTexture());

	Position = { x,y };
	return true;
}

D3DXVECTOR2 Player::GetCharacterPosition() const
{
	return Position;
}

D3DXVECTOR2 Player::GetCharacterSize() const
{
	return D3DXVECTOR2(screenWidth / SCREEN_X, screenHeight / SCREEN_Y);
}

void Player::Initialize(ID3D11Device * m_device, CameraClass* cam, MapData** map, HWND hwnd)
{
	Position =D3DXVECTOR2(screenWidth / 2.0f, screenHeight / 2.0f);
	m_map = map;
	m_camera = cam;
	m_bitmap = new BitmapClass;
	m_bitmap->Initialize(m_device, const_cast<WCHAR*>(L"C:\\Map\\Image.png"), screenWidth / SCREEN_X, screenHeight / SCREEN_Y);

	m_texture = new TextureShaderClass;
	m_texture->Initialize(m_device, hwnd);
}

void Player::Shutdown()
{
	if (m_bitmap) {
		m_bitmap->Shutdown();
		delete m_bitmap;
		m_bitmap = 0;
	}
	if (m_texture) {
		m_texture->Shutdown();
		delete m_texture;
		m_texture = 0;
	}
}