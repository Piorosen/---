#pragma once
#include "Global.h"
#include "LineClass.h"
#include "ShapeShaderClass.h"
#include "Map.h"


class Bullet {
private:
	LineClass * line;
	ShapeShaderClass* shader;
	
	D3DXVECTOR3 bulletPosition;
	D3DXVECTOR3 playerPosition;

	ID3D11Device* m_device;
	Map* m_map;

	float m = 0;
	bool m_canFire = true;
	int m_shoot = 0;
public:
	void Initialize(ID3D11Device* device, HWND hwnd, Map* m_map);
	void SetPosition(D3DXVECTOR3 player, D3DXVECTOR3 bullet);

	D3DXVECTOR3 GetBulletPosition() const;

	bool canFire();
	void SetShoot(int);

	void Shutdown();
	bool Render(ID3D11Device* device, ID3D11DeviceContext* context, float bulletSpeed, float bulletSize, D3DXMATRIX world, D3DXMATRIX view, D3DMATRIX ortho);

};