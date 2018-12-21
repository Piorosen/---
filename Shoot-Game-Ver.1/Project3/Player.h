#pragma once

#include "BitmapClass.h"
#include "TextureShaderClass.h"
#include "Character.h"
#include "CameraClass.h"

class Player : public Character {
private:
	

	BitmapClass* m_bitmap;
	TextureShaderClass* m_texture;
	CameraClass* m_camera;

public:
	Player() {
		m_bitmap = 0;
		m_texture = 0;
		HealthPoint = 100;
		Position = D3DXVECTOR2(0, 0);
	}

	void CameraMove(D3DXVECTOR2 data);
	void CharacterMove(ID3D11DeviceContext* context, D3DXVECTOR2 data,
		D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o);

	void Initialize(ID3D11Device* device, CameraClass* cam, int screenWidth, int screenHeight, HWND hwnd);

	void Shutdown();

	virtual void Move(ID3D11DeviceContext*, D3DXVECTOR2 data, 
		D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o);


};