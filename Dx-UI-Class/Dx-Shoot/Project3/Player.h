#pragma once

#include "BitmapClass.h"
#include "TextureShaderClass.h"
#include "Character.h"
#include "CameraClass.h"
#include "Map.h"


class Player {
private:
	MapData** m_map;
	BitmapClass* m_bitmap;
	TextureShaderClass* m_texture;
	CameraClass* m_camera;
	D3DXVECTOR2 SetPosition;
	D3DXVECTOR2 Position;
	

public:
	Player() {
		m_bitmap = 0;
		m_texture = 0;
		SetPosition = D3DXVECTOR2(0,0);
	}

	void CameraMove(D3DXVECTOR2 data);
	bool CharacterMove(ID3D11DeviceContext* context, D3DXVECTOR2 data,
		D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o);

	D3DXVECTOR2 GetCharacterPosition() const;
	D3DXVECTOR2 GetCharacterSize() const;

	void Initialize(ID3D11Device* device, CameraClass* cam, MapData** map, HWND hwnd);

	void Shutdown();
};