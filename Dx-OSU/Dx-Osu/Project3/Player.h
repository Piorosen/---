#pragma once

#include "ModelClass.h"
#include "TextureShaderClass.h"
#include "Character.h"
#include "CameraClass.h"
#include "LightClass.h"
#include "LightShaderClass.h"


class Player {
private:
	ModelClass* m_model;
	LightClass* m_light;
	LightShaderClass* m_lightshader;

	CameraClass* m_camera;
	D3DXVECTOR2 SetPosition;
	D3DXVECTOR2 Position;
	

public:
	Player() {
		m_model = 0;
		m_light = 0;
		m_lightshader = 0;
		SetPosition = D3DXVECTOR2(0,0);
	}

	void CameraMove(D3DXVECTOR2 data);
	bool CharacterMove(ID3D11DeviceContext* context, D3DXVECTOR2 data,
		D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o, D3DXMATRIX p);

	D3DXVECTOR2 GetCharacterPosition() const;
	D3DXVECTOR2 GetCharacterSize() const;

	void Initialize(ID3D11Device* device, CameraClass* cam, HWND hwnd);

	void Shutdown();
};