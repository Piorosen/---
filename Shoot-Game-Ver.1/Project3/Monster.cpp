#include "Monster.h"
#include <string>

void Monster::Move(ID3D11DeviceContext *context, D3DXVECTOR2 data, D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o)
{
	if (Draw) {

		static int count = 11;
		static int move = 0;
		if (count < 5) {
			switch (move) {
			case 0:
				Position.x += 1;
				break;
			case 1:
				Position.x -= 1;
				break;
			case 2:
				Position.y += 1;
				break;
			case 3:
				Position.y -= 1;
				break;
			}
			count++;
		}
		else {
			move = rand() % 4;
			count = 0;
		}

		if (0 > Position.x) {
			Position.x = 0;
		}
		if (Position.x >= 29) {
			Position.x = 28;
		}
		if (0 > Position.y) {
			Position.y = 0;
		}
		if (Position.y >= 29) {
			Position.y = 28;
		}

		if (m_map->GetCollide((int)Position.x, (int)Position.y + 1)) {
			switch (move) {
			case 0:
				Position.x -= 1;
				break;
			case 1:
				Position.x += 1;
				break;
			case 2:
				Position.y -= 1;
				break;
			case 3:
				Position.y += 1;
				break;
			}
		}
	

		m_bitmap->Render(context, screenWidth / SCREEN_X * Position.x,
			screenHeight / SCREEN_Y * Position.y);
		m_texture->Render(context, m_bitmap->GetIndexCount(), w, v, o, m_bitmap->GetTexture());
	}
}

bool Monster::BulletCollide(D3DXVECTOR3 bullet)
{
	if (Draw) {
		// x ��ǥ üũ
		float startX = Position.x * (screenWidth / SCREEN_X) - (screenWidth / 2);
		float startY = (screenHeight / 2) - (Position.y + 1) * (screenHeight / SCREEN_Y);

		// OutputDebugString((std::to_wstring(startY) + L" " + std::to_wstring(bullet.y) + L" " + std::to_wstring(startY + (screenHeight / SCREEN_Y)) + L'\n').c_str());

		if (startX <= bullet.x && bullet.x <= startX + (screenWidth / SCREEN_X)) {
			// y ��ǥ üũ	
			if (startY <= bullet.y && bullet.y <= startY + (screenHeight / SCREEN_Y)) {

				return true;

			}
		}
	}
	return false;
}

void Monster::Recue()
{
	Draw = true;
	Position = { (float)(rand() % SIZE_X), (float)(rand() % SIZE_Y) };

}



void Monster::Died()
{
	Draw = false;
}

void Monster::Shutdown()
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

void Monster::Initialize(ID3D11Device * m_device, Map* map, HWND hwnd)
{
	m_map = map;
	srand(time(NULL));

	Position = { (float)(rand() % SIZE_X), (float)(rand() % SIZE_Y) };

	m_bitmap = new BitmapClass;
	m_bitmap->Initialize(m_device, const_cast<WCHAR*>(L"C:\\Map\\monster.png"), screenWidth / SCREEN_X, screenHeight / SCREEN_Y);

	m_texture = new TextureShaderClass;
	m_texture->Initialize(m_device, hwnd);
}
