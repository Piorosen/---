#include "Bullet.h"
#include <string>

void Bullet::Initialize(ID3D11Device* device, HWND hwnd, Map* map)
{
	line = new LineClass;
	shader = new ShapeShaderClass;
	shader->Initialize(device, hwnd);

	m_map = map;
}

void Bullet::SetPosition(D3DXVECTOR3 player, D3DXVECTOR3 bullet)
{
	m_shoot = 0;
	m_canFire = false;

	playerPosition = player;
	bulletPosition = playerPosition;
	m = (playerPosition.y - bullet.y) / (playerPosition.x - bullet.x);

	float gak = atan2(bullet.y - playerPosition.y, bullet.x - playerPosition.x) * 180 / 3.141592f;

	if (-45 <= gak && gak <= 45) {
		bulletPosition.x += 50.0f;
		bulletPosition.y += 50.0f * m;
	}
	else if (45 <= gak && gak <= 135) {
		bulletPosition.x += 50.0f / m;
		bulletPosition.y += 50.0f;
	}
	else if (135 <= gak || -135 >= gak) {
		bulletPosition.x -= 50.0f;
		bulletPosition.y -= 50.0f * m;
	}
	else  if (-135 <= gak && gak <= -45) {
		bulletPosition.x -= 50.0f / m;
		bulletPosition.y -= 50.0f;
	}
}

D3DXVECTOR3 Bullet::GetBulletPosition() const {
	return (bulletPosition + playerPosition) / 2;
}

bool Bullet::canFire()
{
	return m_canFire;
}

void Bullet::SetShoot(int)
{
}

void Bullet::Shutdown()
{
	shader->Shutdown();
	line->Shutdown();
}


bool Bullet::Render(ID3D11Device* device, ID3D11DeviceContext* context,	float bulletSpeed, float bulletSize, D3DXMATRIX world, D3DXMATRIX view, D3DMATRIX ortho)
{
	

	// ¸Ê°úÀÇ ÃÑ¾Ë Ãæµ¹
	if (m_map->GetCollide(bulletPosition.x + screenWidth / 2 - screenWidth / SCREEN_X, screenHeight / 2 - bulletPosition.y,
		screenWidth / SCREEN_X, screenHeight / SCREEN_Y)){
		m_canFire = true;
		m_shoot = 1001;
		return false;
	}

	if (m_shoot < 1000) {
		float gak = atan2(bulletPosition.y - playerPosition.y, bulletPosition.x - playerPosition.x) * 180 / 3.1415f;

		if (-45 <= gak && gak <= 45) {

			bulletPosition.x += bulletSpeed;
			bulletPosition.y += bulletSpeed * m;
			playerPosition.x += bulletSpeed;
			playerPosition.y += bulletSpeed * m;
		}
		else if (45 <= gak && gak <= 135) {
			bulletPosition.x += bulletSpeed / m;
			bulletPosition.y += bulletSpeed;
			playerPosition.x += bulletSpeed / m;
			playerPosition.y += bulletSpeed;
		}
		else if (135 <= gak || -135 >= gak) {
			bulletPosition.x -= bulletSpeed;
			bulletPosition.y -= m * bulletSpeed;
			playerPosition.x -= bulletSpeed;
			playerPosition.y -= m * bulletSpeed;
		}
		else  if (-135 <= gak && gak <= -45) {


			bulletPosition.x -= bulletSpeed / m;
			bulletPosition.y -= bulletSpeed;
			playerPosition.x -= bulletSpeed / m;
			playerPosition.y -= bulletSpeed;
		}
		else {
			m_canFire = false;
			return true;
		}



		line->Initialize(device, D3DXVECTOR4(1, 0.8, 0.1, 0.3),
			playerPosition, bulletPosition, 5.0);
		line->Render(context);
		shader->Render(context, line->GetIndexCount(), world, view, ortho);
		line->Shutdown();
		
		m_shoot++;
		m_canFire = false;
		return true;
	}
	return false;
	/*line->Initialize(device, D3DXVECTOR4(1, 0, 0, 1), playerPosition, bulletPosition, 100);
	line->Render(context);
	shader->Render(context, line->GetIndexCount(), world, view, ortho);
	line->Shutdown();*/
}
