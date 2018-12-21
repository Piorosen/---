#pragma once

#include <time.h>

#include "BitmapClass.h"
#include "TextureShaderClass.h"
#include "Bullet.h"

#include "Character.h"
#include "Global.h"

class Monster : public Character {
private:
	BitmapClass * m_bitmap;
	TextureShaderClass* m_texture;
	Map* m_map;
	D3DXVECTOR2 position;
	D3DXVECTOR2 MovedPosition;

	bool Draw = true;

public:
	virtual void Move(ID3D11DeviceContext*, D3DXVECTOR2 data,
		D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o);

	bool BulletCollide(D3DXVECTOR3 bullet);

	void Recue();

	void Died();

	void Shutdown();
	void Initialize(ID3D11Device * m_device, Map* map, HWND hwnd);


protected:
	D3DXVECTOR2 Position;
	int HealthPoint;
};