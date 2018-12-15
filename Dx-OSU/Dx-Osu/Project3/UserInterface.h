#pragma once

/// LIB INCLDUE
#include <vector>

/// MY INCLDUE 
#include "BitmapClass.h"
#include "LineClass.h"
#include "RectClass.h"
#include "CircleClass.h"
#include "ShapeShaderClass.h"
#include "TextureShaderClass.h"


using namespace std;

class UserInterface {
private:
	D3DXMATRIX m_baseCameraMatrix;
	D3DXMATRIX m_worldMatrix;
	D3DXMATRIX m_orthoMatrix;

	ShapeShaderClass* m_shapeClass;
	TextureShaderClass* m_textureClass;

	vector<BitmapClass*> List_Bitmap;
	vector<LineClass*> List_Line;
	vector<RectClass*> List_Rect;
	vector<CircleClass*> List_Circle;

	
public:
	void DrawAdd(BitmapClass* val) {
		List_Bitmap.push_back(val);
	}

	void DrawAdd(LineClass* val) {
		List_Line.push_back(val);
	}
	void DrawAdd(RectClass* val) {
		List_Rect.push_back(val);
	}
	void DrawAdd(CircleClass* val) {
		List_Circle.push_back(val);
	}
	
	void Shutdown();


	bool Render(ID3D11DeviceContext *deviceContext, D3DMATRIX worldMatrix, D3DMATRIX viewMatrix, D3DMATRIX orthoMatrix);

	void Initialize(ID3D11Device*, HWND, D3DMATRIX);

};