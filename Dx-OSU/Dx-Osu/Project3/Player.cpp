
#include "Player.h"
#include "Global.h"


void Player::CameraMove(D3DXVECTOR2 data)
{
	//
	//if (Position.x + LEFT_POSITION <= screenWidth / 2) {
	//	data.x = screenWidth / 2;
	//}
	////else if (Position.x + LEFT_POSITION >= (SIZE_X - SCREEN_X / 2) * screenWidth / SCREEN_X) {
	////	data.x = (SIZE_X - SCREEN_X / 2) * screenWidth / SCREEN_X;
	////}
	//else {
	//	data.x += LEFT_POSITION;
	//}
	//
	//if (Position.y <= screenHeight / 2) {
	//	data.y = screenHeight / 2;
	//}else if (Position.y >= (SIZE_Y - SCREEN_Y / 2.0f) * screenHeight / SCREEN_Y) {
	//	data.y = (SIZE_Y - SCREEN_Y / 2.0f) * (screenHeight / SCREEN_Y);
	//}
	m_camera->SetPosition(0.0f, 5.0f, -20.0f);
}

bool Player::CharacterMove(ID3D11DeviceContext* context, D3DXVECTOR2 data,
	D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o, D3DXMATRIX p)
{

	m_model->Render(context);

	m_lightshader->Render(context, m_model->GetIndexCount(), w, v, p, m_model->GetTexture(), m_light->GetDirection(), m_light->GetDiffuseColor());

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

void Player::Initialize(ID3D11Device * m_device, CameraClass* cam, HWND hwnd)
{
	Position = D3DXVECTOR2(screenWidth / 2.0f, screenHeight / 2.0f);
	m_camera = cam;
	m_model = new ModelClass;
	m_model->Initialize(m_device, const_cast<char*>("C:\\Map\\Data\\model.txt"), const_cast<WCHAR*>(L"C:\\Map\\Data\\Bastion.jpg"));

	m_light = new LightClass;

	m_light->SetDiffuseColor(1.0f, 1.0f, 1.0f, 1.0f);
	m_light->SetDirection(0.0f, 0.0f, 1.0f);

	m_lightshader = new LightShaderClass;
	m_lightshader->Initialize(m_device, hwnd);

}

void Player::Shutdown()
{
	if (m_light)
	{
		delete m_light;
		m_light = 0;
	}
	if (m_model) {
		m_model->Shutdown();
		delete m_model;
		m_model = 0;
	}
	if (m_lightshader) {
		m_lightshader->Shutdown();
		delete m_lightshader;
		m_lightshader = 0;
	}
}