
#include "Player.h"
#include "Global.h"


void Player::CameraMove(D3DXVECTOR2 data)
{
	m_camera->SetPosition(data.x, data.y, -1);

}

void Player::CharacterMove(ID3D11DeviceContext* context, D3DXVECTOR2 data,
	D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o)
{
	m_bitmap->Render(context, screenWidth / 2 + data.x - screenWidth / (SCREEN_X * 2), screenHeight / 2 - data.y - screenHeight / (SCREEN_Y * 2));
	m_texture->Render(context, m_bitmap->GetIndexCount(), w, v, o, m_bitmap->GetTexture());
}

void Player::Initialize(ID3D11Device * m_device, CameraClass* cam, int screenWidth, int screenHeight, HWND hwnd)
{
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

void Player::Move(ID3D11DeviceContext* context, D3DXVECTOR2 data, D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o)
{
	CharacterMove(context, data, w, v, o);
	CameraMove(data);
}